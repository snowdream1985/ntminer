﻿using System;
using System.Text;

namespace NTMiner.MinerServer {
    public class ColumnsShowData : IDbEntity<Guid>, IColumnsShow, IGetSignData {
        public static readonly Guid PleaseSelectId = Guid.Parse("197f19e8-0c1b-4018-875d-2f5e56a02491");

        public Guid GetId() {
            return this.Id;
        }

        public Guid Id { get; set; }

        public string ColumnsShowName { get; set; }

        public bool Work { get; set; }

        public bool MinerName{ get; set; }

        public bool MinerIp{ get; set; }

        public bool MinerGroup{ get; set; }

        public bool MainCoinCode{ get; set; }

        public bool MainCoinSpeedText{ get; set; }

        public bool GpuTableTrs { get; set; }

        public bool MainCoinWallet{ get; set; }

        public bool MainCoinPool{ get; set; }

        public bool Kernel{ get; set; }

        public bool DualCoinCode{ get; set; }

        public bool DualCoinSpeedText{ get; set; }

        public bool DualCoinWallet{ get; set; }

        public bool DualCoinPool{ get; set; }

        public bool LastActivedOnText{ get; set; }

        public bool Version{ get; set; }

        public bool WindowsLoginNameAndPassword{ get; set; }

        public bool WindowsPassword{ get; set; }

        public bool GpuInfo{ get; set; }

        public bool MainCoinRejectPercentText { get; set; }

        public bool DualCoinRejectPercentText { get; set; }

        public bool BootTimeSpanText { get; set; }

        public bool MineTimeSpanText { get; set; }

        public bool IncomeMainCoinPerDayText { get; set; }

        public bool IncomeDualCoinPerDayText { get; set; }

        public bool IsAutoBoot { get; set; }

        public bool IsAutoStart { get; set; }

        public bool OSName { get; set; }

        public bool OSVirtualMemoryGbText { get; set; }

        public bool GpuType { get; set; }

        public bool GpuDriver { get; set; }

        public bool TotalPowerText { get; set; }

        public bool MaxTempText { get; set; }

        public string GetSignData() {
            StringBuilder sb = new StringBuilder();
            sb.Append(nameof(Id)).Append(Id)
                .Append(nameof(Work)).Append(Work)
                .Append(nameof(MinerName)).Append(MinerName)
                .Append(nameof(MinerIp)).Append(MinerIp)
                .Append(nameof(MinerGroup)).Append(MinerGroup)
                .Append(nameof(MainCoinCode)).Append(MainCoinCode)
                .Append(nameof(MainCoinSpeedText)).Append(MainCoinSpeedText)
                .Append(nameof(MainCoinWallet)).Append(MainCoinWallet)
                .Append(nameof(MainCoinPool)).Append(MainCoinPool)
                .Append(nameof(Kernel)).Append(Kernel)
                .Append(nameof(DualCoinCode)).Append(DualCoinCode)
                .Append(nameof(DualCoinSpeedText)).Append(DualCoinSpeedText)
                .Append(nameof(DualCoinWallet)).Append(DualCoinWallet)
                .Append(nameof(DualCoinPool)).Append(DualCoinPool)
                .Append(nameof(LastActivedOnText)).Append(LastActivedOnText)
                .Append(nameof(Version)).Append(Version)
                .Append(nameof(WindowsLoginNameAndPassword)).Append(WindowsLoginNameAndPassword)
                .Append(nameof(WindowsPassword)).Append(WindowsPassword)
                .Append(nameof(GpuInfo)).Append(GpuInfo)
                .Append(nameof(MainCoinRejectPercentText)).Append(MainCoinRejectPercentText)
                .Append(nameof(DualCoinRejectPercentText)).Append(DualCoinRejectPercentText)
                .Append(nameof(BootTimeSpanText)).Append(BootTimeSpanText)
                .Append(nameof(MineTimeSpanText)).Append(MineTimeSpanText)
                .Append(nameof(IncomeMainCoinPerDayText)).Append(IncomeMainCoinPerDayText)
                .Append(nameof(IncomeDualCoinPerDayText)).Append(IncomeDualCoinPerDayText)
                .Append(nameof(IsAutoBoot)).Append(IsAutoBoot)
                .Append(nameof(IsAutoStart)).Append(IsAutoStart)
                .Append(nameof(OSName)).Append(OSName)
                .Append(nameof(OSVirtualMemoryGbText)).Append(OSVirtualMemoryGbText)
                .Append(nameof(GpuType)).Append(GpuType)
                .Append(nameof(GpuDriver)).Append(GpuDriver)
                .Append(nameof(TotalPowerText)).Append(TotalPowerText)
                .Append(nameof(MaxTempText)).Append(MaxTempText);
            return sb.ToString();
        }
    }
}
