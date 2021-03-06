﻿using System;
using System.Runtime.InteropServices;

namespace NTMiner.Windows {
    public static class Power {
        [DllImport("kernel32.dll")]
        internal static extern uint SetThreadExecutionState(ExecutionFlag flags);
        [Flags]
        internal enum ExecutionFlag : uint {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            Awaymode = 0x00000040,
            System = 0x00000001,
            Display = 0x00000002,
            Continus = 0x80000000,
        }

        public static void Restart() {
            Cmd.RunClose("shutdown", "-r -f -t 0");
        }

        public static void Shutdown() {
            Cmd.RunClose("shutdown", "-s -f -t 0");
        }

        /// <summary>
        /// 阻止windows系统休眠，该方法需周期性调用
        /// </summary>
        public static void PreventWindowsSleep() {
            SetThreadExecutionState(ExecutionFlag.System | ExecutionFlag.Display | ExecutionFlag.Continus);
        }

        public static bool PowerCfgOff() {
            try {
                int exitcode = -1;
                Cmd.RunClose("powercfg", "-h off", ref exitcode);
                bool r = exitcode == 0;
                if (r) {
                    Logger.OkDebugLine("powercfg -h off ok");
                }
                else {
                    Logger.WarnDebugLine("powercfg -h off failed, exitcode=" + exitcode);
                }
                return r;
            }
            catch (Exception e) {
                Logger.ErrorDebugLine("powercfg -h off failed，因为异常", e);
                return false;
            }
        }
    }
}
