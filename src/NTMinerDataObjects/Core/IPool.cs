﻿using System;

namespace NTMiner.Core {
    public interface IPool : ILevelEntity<Guid> {
        Guid CoinId { get; }
        Guid BrandId { get; }
        string Name { get; }
        string Server { get; }
        string Url { get; }
        string Website { get; }
        int SortNumber { get; }
        bool IsUserMode { get; }
        string UserName { get; }
        string Password { get; }
        string Notice { get; }
    }
}
