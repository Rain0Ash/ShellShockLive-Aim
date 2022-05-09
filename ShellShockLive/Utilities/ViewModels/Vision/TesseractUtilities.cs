// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Tesseract;

namespace ShellShockLive.Utilities.ViewModels.Vision
{
    public static class TesseractUtilities
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Page> ProcessAsync(this TesseractEngine engine, Bitmap bitmap)
        {
            return ProcessAsync(engine, bitmap, CancellationToken.None);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Page> ProcessAsync(this TesseractEngine engine, Bitmap bitmap, CancellationToken token)
        {
            if (engine is null)
            {
                throw new ArgumentNullException(nameof(engine));
            }

            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }
            
            return Task.Run(() => engine.Process(bitmap), token);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Page> ProcessAsync(this TesseractEngine engine, Bitmap bitmap, PageSegMode mode)
        {
            return ProcessAsync(engine, bitmap, mode, CancellationToken.None);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Page> ProcessAsync(this TesseractEngine engine, Bitmap bitmap, PageSegMode mode, CancellationToken token)
        {
            if (engine is null)
            {
                throw new ArgumentNullException(nameof(engine));
            }

            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            return Task.Run(() => engine.Process(bitmap, mode), token);
        }
    }
}