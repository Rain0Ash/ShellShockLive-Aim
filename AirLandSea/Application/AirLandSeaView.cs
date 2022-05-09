// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NetExtender.Domains;
using NetExtender.Domains.View;

namespace AirLandSea.Application
{
    public class AirLandSeaView : WindowsPresentationView
    {
        protected override void Initialize()
        {
            Domain.ShutdownMode = ApplicationShutdownMode.OnMainWindowClose;
        }

        public AirLandSeaView()
            : base(new AirLandSeaWindow())
        {
        }
    }
}