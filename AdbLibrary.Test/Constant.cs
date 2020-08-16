using AdbLibrary.Android;
using AdbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdbLibrary.Test
{
    public static class Constant
    {
        static Constant()
        {
            DeviceId = DeviceManager.GetAuthorizedDevicesIdAsync().Result.First().ID;
            Device = DeviceManager.GetAuthorizedDevice(DeviceId).Result;
        }
        public static string DeviceId;
        public static Device Device { get; set; }
    }
}
