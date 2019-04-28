﻿using NTMiner.Core;
using NTMiner.Vms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NTMiner {
    public partial class AppContext {
        public class PoolViewModels : ViewModelBase {
            private readonly Dictionary<Guid, PoolViewModel> _dicById = new Dictionary<Guid, PoolViewModel>();
            public PoolViewModels() {
                NTMinerRoot.Instance.OnContextReInited += () => {
                    _dicById.Clear();
                    Init();
                };
                NTMinerRoot.Instance.OnReRendContext += () => {
                    OnPropertyChanged(nameof(AllPools));
                };
                Init();
            }

            private void Init() {
                VirtualRoot.On<PoolAddedEvent>("添加矿池后刷新VM内存", LogEnum.DevConsole,
                    action: (message) => {
                        _dicById.Add(message.Source.GetId(), new PoolViewModel(message.Source));
                        OnPropertyChanged(nameof(AllPools));
                        CoinViewModel coinVm;
                        if (AppContext.Current.CoinVms.TryGetCoinVm(message.Source.CoinId, out coinVm)) {
                            coinVm.CoinProfile.OnPropertyChanged(nameof(CoinProfileViewModel.MainCoinPool));
                            coinVm.CoinProfile.OnPropertyChanged(nameof(CoinProfileViewModel.DualCoinPool));
                            coinVm.OnPropertyChanged(nameof(CoinViewModel.Pools));
                            coinVm.OnPropertyChanged(nameof(CoinViewModel.OptionPools));
                        }
                    }).AddToCollection(NTMinerRoot.Instance.ContextHandlers);
                VirtualRoot.On<PoolRemovedEvent>("删除矿池后刷新VM内存", LogEnum.DevConsole,
                    action: (message) => {
                        _dicById.Remove(message.Source.GetId());
                        OnPropertyChanged(nameof(AllPools));
                        CoinViewModel coinVm;
                        if (AppContext.Current.CoinVms.TryGetCoinVm(message.Source.CoinId, out coinVm)) {
                            coinVm.CoinProfile.OnPropertyChanged(nameof(CoinProfileViewModel.MainCoinPool));
                            coinVm.CoinProfile.OnPropertyChanged(nameof(CoinProfileViewModel.DualCoinPool));
                            coinVm.OnPropertyChanged(nameof(CoinViewModel.Pools));
                            coinVm.OnPropertyChanged(nameof(CoinViewModel.OptionPools));
                        }
                    }).AddToCollection(NTMinerRoot.Instance.ContextHandlers);
                VirtualRoot.On<PoolUpdatedEvent>("更新矿池后刷新VM内存", LogEnum.DevConsole,
                    action: (message) => {
                        _dicById[message.Source.GetId()].Update(message.Source);
                    }).AddToCollection(NTMinerRoot.Instance.ContextHandlers);
                foreach (var item in NTMinerRoot.Instance.PoolSet) {
                    _dicById.Add(item.GetId(), new PoolViewModel(item));
                }
            }

            public bool TryGetPoolVm(Guid poolId, out PoolViewModel poolVm) {
                return _dicById.TryGetValue(poolId, out poolVm);
            }

            public List<PoolViewModel> AllPools {
                get {
                    return _dicById.Values.ToList();
                }
            }
        }
    }
}