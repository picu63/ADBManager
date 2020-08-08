using NUnit.Framework;
using AdbLibrary.Android;
using SuperADBLibrary.Android;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AdbLibrary.Test
{
    public class DeviceManagerTests
    {
        [TestCase]
        public void GetIp()
        {
            IPAddress ip = DeviceManager.GetIpOfCurrentWiFiConnection(Properties.deviceId).Result;
            Console.WriteLine(ip.ToString());
        }

        [TestCase]
        public void CheckAndroidVersion()
        {
            AdbWrapper.AndroidVersion version = DeviceManager.GetAndroidVersionAsync(Properties.deviceId).Result;
            Console.WriteLine(version.ToString());
            Console.WriteLine((int)version);
        }
    }
}