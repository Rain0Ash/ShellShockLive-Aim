// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NetExtender.Types.Transactions;
using NetExtender.Types.Transactions.Interfaces;
using ShellShockLive.ViewModels.History.Interfaces;
using ShellShockLive.ViewModels.Render;

namespace ShellShockLive.Utilities.ViewModels.History
{
    public static class HistoryUtilities
    {
        public static ITransaction Render(this IHistoryTransaction history)
        {
            return new RenderHistoryTransaction(history);
        }
        
        public static ITransaction Render(this IHistoryTransaction history, RenderViewModel render)
        {
            return new RenderHistoryTransaction(render, history);
        }

        private sealed class RenderHistoryTransaction : ITransaction
        {
            public RenderViewModel Model { get; }
            public IHistoryTransaction History { get; }

            public Boolean? IsCommit
            {
                get
                {
                    return History.IsCommit;
                }
            }

            public TransactionCommitPolicy Policy
            {
                get
                {
                    return History.Policy;
                }
            }

            public RenderHistoryTransaction(IHistoryTransaction history)
                : this(RenderViewModel.Instance, history)
            {
            }

            public RenderHistoryTransaction(RenderViewModel model, IHistoryTransaction history)
            {
                Model = model ?? throw new ArgumentNullException(nameof(model));
                History = history ?? throw new ArgumentNullException(nameof(history));
            }

            public Boolean Commit()
            {
                return History.Commit();
            }

            public Boolean Rollback()
            {
                return History.Rollback();
            }

            public void Dispose()
            {
                History.Dispose();

                if (History.IsCommit == true)
                {
                    Model.Render();
                }
            }
        }
    }
}