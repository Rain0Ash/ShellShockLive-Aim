// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading.Tasks;
using NetExtender.Domains.WindowsPresentation.Initializer;

namespace ShellShockLive
{
    public class Program : WindowsPresentationApplicationInitializer
    {
        [STAThread]
        public static Task<Int32> Main(String[] args)
        {
            return Async(args);
        }
    }
}