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
        [TestCase("172.29.1.102")]
        public void CheckIp(string ipAddressToCheck)
        {
            IPAddress ip = DeviceManager.GetIpOfCurrentWiFiConnection(Constant.deviceId).Result;
            Assert.That(ip.ToString() == ipAddressToCheck);
        }

        [Test]
        public void CheckAndroidVersion()
        {
            AdbWrapper.AndroidVersion version = DeviceManager.GetAndroidVersionAsync(Constant.deviceId).Result;
            Assert.That(version == AdbWrapper.AndroidVersion.Android10);
        }
        
    }
}