﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopBridge;

namespace WinDynamicDesktop
{
    abstract class PlatformHelper
    {
        public abstract string GetCurrentDirectory();

        public abstract void CheckStartOnBoot();

        public abstract void ToggleStartOnBoot();

        public abstract void OpenUpdateLink();
    }

    class UwpDesktop
    {
        private static bool? _isRunningAsUwp;
        private static PlatformHelper helper;

        public static bool IsRunningAsUwp()
        {
            if (!_isRunningAsUwp.HasValue)
            {
                Helpers helpers = new Helpers();
                _isRunningAsUwp = helpers.IsRunningAsUwp();
            }

            return _isRunningAsUwp.Value;
        }

        public static PlatformHelper GetHelper()
        {
            if (helper == null)
            {
                if (!IsRunningAsUwp())
                {
                    helper = new DesktopHelper();
                }
                else
                {
                    helper = new UwpHelper();
                }
            }

            return helper;
        }
    }
}
