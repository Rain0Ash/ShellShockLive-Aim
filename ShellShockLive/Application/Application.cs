// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Immutable;
using NetExtender.Domains.WindowsPresentation.Initializer;
using NetExtender.Utilities.UserInterface;

namespace ShellShockLive.Application
{
    public sealed class ShellShockLiveApplication : WindowsPresentationApplicationInitializer<ShellShockLiveWindow, ShellShockLiveApplication.Builder>
    {
        public new class Builder : WindowsPresentationApplicationInitializer<ShellShockLiveWindow, Builder>.Builder
        {
            public override ShellShockLiveWindow Build(ImmutableArray<String> arguments)
            {
                ConsoleWindowUtilities.IsConsoleVisible = false;
                return new ShellShockLiveWindow(arguments);
            }
        }
    }
}