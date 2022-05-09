// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using Tesseract;

namespace ShellShockLive.ViewModels.Vision
{
    public abstract class DigitVisionAnalyzer<T> : TextVisionAnalyzer<T>
    {
        protected override Boolean Initialize(TesseractEngine engine)
        {
            return engine.SetVariable("tessedit_char_whitelist", "0123456789");
        }
    }
}