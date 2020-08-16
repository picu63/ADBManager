using NUnit.Framework;
using AdbLibrary.Android;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AdbLibrary.Models;

namespace AdbLibrary.Test
{
    public class DeviceManagerTests
    {
        [TestCase("172.29.1.102")]
        public void CheckIp(string ipAddressToCheck)
        {
            IPAddress ip = DeviceManager.GetIpOfCurrentWiFiConnection(new Device(Constant.DeviceId)).Result;
            Console.WriteLine("Ip from device: " + ip.ToString());
            Assert.That(ip.ToString() == ipAddressToCheck);
        }

        [TestCase(AdbWrapper.AndroidVersion.Android10)]
        public void CheckAndroidVersion(AdbWrapper.AndroidVersion androidVersion)
        {
            AdbWrapper.AndroidVersion version = DeviceManager.GetAndroidVersionAsync(new Device(Constant.DeviceId)).Result;
            Console.WriteLine($"{version}");
            Assert.That(version == androidVersion);
        }
    }
}