// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Threading.Tasks;
using NetExtender.Types.Monads;
using NetExtender.Windows.Types;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.ViewModels.Vision.Bindings;

namespace ShellShockLive.ViewModels.Vision
{
    public class VisionAnalyzer
    {
        public GameVisionAnalyzer Game { get; }
        public PlayerVisionAnalyzer Player { get; }
        public WeaponVisionAnalyzer Weapon { get; }
        public WindVisionAnalyzer Wind { get; }
        public FuelVisionAnalyzer Fuel { get; }

        public VisionAnalyzer()
            : this(null, null, null, null, null)
        {
        }

        public VisionAnalyzer(GameVisionAnalyzer? game, PlayerVisionAnalyzer? player, WeaponVisionAnalyzer? weapon, WindVisionAnalyzer? wind, FuelVisionAnalyzer? fuel)
        {
            Game = game ?? new GameVisionAnalyzer();
            Player = player ?? new PlayerVisionAnalyzer();
            Weapon = weapon ?? new WeaponVisionAnalyzer();
            Wind = wind ?? new WindVisionAnalyzer();
            Fuel = fuel ?? new FuelVisionAnalyzer();
        }
        
        public virtual async Task<VisionResult> AnalyzeAsync(VisionType type, Rectangle screen, DirectBitmap bitmap, VisionBinding binding)
        {
            Maybe<Boolean> game = await Game.AnalyzeAsync(screen, bitmap, binding).ConfigureAwait(false);

            if (!game || !game.Value)
            {
                return default;
            }
            
            Task<Maybe<Point>> player = type.HasFlag(VisionType.Player) ? Player.AnalyzeAsync(screen, bitmap, binding) : Task.FromResult<Maybe<Point>>(default);
            Task<Maybe<IWeapon>> weapon = type.HasFlag(VisionType.Weapon) ? Weapon.AnalyzeAsync(screen, bitmap, binding) : Task.FromResult<Maybe<IWeapon>>(default);
            Task<Maybe<Int16>> wind = type.HasFlag(VisionType.Wind) ? Wind.AnalyzeAsync(screen, bitmap, binding) : Task.FromResult<Maybe<Int16>>(default);
            Task<Maybe<UInt16>> fuel = type.HasFlag(VisionType.Fuel) ? Fuel.AnalyzeAsync(screen, bitmap, binding) : Task.FromResult<Maybe<UInt16>>(default);

            await Task.WhenAll(player, weapon, wind, fuel).ConfigureAwait(false);
            return new VisionResult(await player.ConfigureAwait(false), await weapon.ConfigureAwait(false), await wind.ConfigureAwait(false), await fuel.ConfigureAwait(false));
        }
    }
}