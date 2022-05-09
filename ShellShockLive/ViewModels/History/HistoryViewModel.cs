// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NetExtender.WindowsPresentation.ReactiveUI.Types.Models;
using ShellShockLive.ViewModels.History.Interfaces;

namespace ShellShockLive.ViewModels.History
{
    public class HistoryViewModel : ReactiveViewModelSingleton<HistoryViewModel>
    {
        public HistoryManager Manager { get; } = new HistoryManager();
        
        public IHistoryTransaction Transaction()
        {
            return Manager.Transaction();
        }
    }
}