﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NetExtender.Types.Transactions.Interfaces;

namespace ShellShockLive.ViewModels.History.Interfaces
{
    public interface IHistoryTransaction : ITransaction
    {
        public Boolean Successful { get; }
    }
}