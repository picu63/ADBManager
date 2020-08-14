using NUnit.Framework;
using AdbLibrary.Android;
using AdbLibrary.Android;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AdbLibrary.Test
{
    public class DeviceManagerTests
    {
        [TestCase("172.29.1.102")]
        public void CheckIp(string ipAddressToCheck)
        {
            IPAddress ip = DeviceManager.GetIpOfCurrentWiFiConnection(Constant.deviceId).Result;
            Console.WriteLine("Ip from device: " + ip.ToString());
            Assert.That(ip.ToString() == ipAddressToCheck);
        }

        [TestCase(AdbWrapper.AndroidVersion.Oreo_8_1)]
        public void CheckAndroidVersion(AdbWrapper.AndroidVersion androidVersion)
        {
            AdbWrapper.AndroidVersion version = DeviceManager.GetAndroidVersionAsync(Constant.deviceId).Result;
            Console.WriteLine($"{version}");
            Assert.That(version == androidVersion);
        }
        
    }
}