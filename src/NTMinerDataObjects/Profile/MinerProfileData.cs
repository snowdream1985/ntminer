﻿using System;
using System.Text;

namespace NTMiner.Profile {
    public class MinerProfileData : IMinerProfile, IDbEntity<Guid>, IGetSignData {
        public static MinerProfileData CreateDefaultData(Guid coinId) {
            return new MinerProfileData {
                Id = Guid.Parse("7d9eec49-2d1f-44fa-881e-571a78661ca0"),
                CoinId = coinId
            };
        }

        public MinerProfileData() {
            this.MinerName = string.Empty;
            this.IsAutoRestartKernel = true;
            this.AutoRestartKernelTimes = 10;
            this.IsNoShareRestartKernel = false;
            this.NoShareRestartKernelMinutes = 30;
            this.IsPeriodicRestartKernel = false;
            this.PeriodicRestartKernelHours = 12;
            this.IsPeriodicRestartComputer = false;
            this.PeriodicRestartComputerHours = 24;
            this.IsSpeedDownRestartComputer = false;
            this.IsTempHighStopMine = false;
            this.RestartComputerSpeedDownPercent = 0;
            this.StartMineTempLow = 50;
            this.StopMineTempHigh = 88;
            this.IsEChargeEnabled = true;
            this.EPrice = 0.3;
        }

        public MinerProfileData(IMinerProfile data) {
            this.Id = data.CoinId;
            this.MinerName = data.MinerName;
            this.CoinId = data.CoinId;
            this.IsAutoRestartKernel = data.IsAutoRestartKernel;
            this.AutoRestartKernelTimes = data.AutoRestartKernelTimes;
            this.IsNoShareRestartKernel = data.IsNoShareRestartKernel;
            this.NoShareRestartKernelMinutes = data.NoShareRestartKernelMinutes;
            this.IsPeriodicRestartKernel = data.IsPeriodicRestartKernel;
            this.PeriodicRestartKernelHours = data.PeriodicRestartKernelHours;
            this.IsPeriodicRestartComputer = data.IsPeriodicRestartComputer;
            this.PeriodicRestartComputerHours = data.PeriodicRestartComputerHours;
            this.IsSpeedDownRestartComputer = data.IsSpeedDownRestartComputer;
            this.IsTempHighStopMine = data.IsTempHighStopMine;
            this.RestartComputerSpeedDownPercent = data.RestartComputerSpeedDownPercent;
            this.StartMineTempLow = data.StartMineTempLow;
            this.StopMineTempHigh = data.StopMineTempHigh;
            this.IsEChargeEnabled = data.IsEChargeEnabled;
            this.EPrice = data.EPrice;
        }

        public Guid GetId() {
            return this.Id;
        }
        public Guid Id { get; set; }
        public string MinerName { get; set; }
        public bool IsAutoRestartKernel { get; set; }
        public int AutoRestartKernelTimes { get; set; }
        public Guid CoinId { get; set; }
        public bool IsNoShareRestartKernel { get; set; }
        public int NoShareRestartKernelMinutes { get; set; }
        public bool IsPeriodicRestartKernel { get; set; }
        public int PeriodicRestartKernelHours { get; set; }
        public bool IsPeriodicRestartComputer { get; set; }
        public int PeriodicRestartComputerHours { get; set; }

        public bool IsSpeedDownRestartComputer { get; set; }

        public int RestartComputerSpeedDownPercent { get; set; }

        public bool IsTempHighStopMine { get; set; }

        public int StopMineTempHigh { get; set; }

        public int StartMineTempLow { get; set; }

        public bool IsEChargeEnabled { get; set; }

        public double EPrice { get; set; }

        public override string ToString() {
            return $"{Id}{MinerName}{IsAutoRestartKernel}{CoinId}{IsNoShareRestartKernel}{NoShareRestartKernelMinutes}{IsPeriodicRestartKernel}{PeriodicRestartKernelHours}{IsPeriodicRestartComputer}{PeriodicRestartComputerHours}{IsSpeedDownRestartComputer}{RestartComputerSpeedDownPercent}{IsTempHighStopMine}{StopMineTempHigh}{StartMineTempLow}{IsEChargeEnabled}{EPrice}";
        }

        public StringBuilder GetSignData() {
            return new StringBuilder(this.ToString());
        }
    }
}
