using NUnit.Framework;
using SuperAdbLibrary.Android;
using System;
using System.Collections.Generic;

namespace SuperAdbLibrary.Test
{
    public class FilesExplorer
    {
        const string deviceId = "d5f27533";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test01()
        {
            List<string> filesAndDirs = SuperAdbLibrary.Android.AdbWrapper.GetFilesInDirectory(deviceId,"sdcard").Result;
            foreach (var file in filesAndDirs)
            {
                Console.WriteLine(file);
            }
            Assert.Contains("Android",filesAndDirs);
        }

        [Test]
        public void Test02()
        {
            string destination = @"C:\ADB";
            string output = AdbWrapper.PullFileFromDevice(deviceId, "sdcard/Android/ANDROID.PERMISSION.TEST", destination).Result;
            Console.WriteLine(output, destination);
        }

        [Test]
        public void Test03()
        {
            string destination = @"C:\ADB\Test";
            List<string> files = new List<string>() { "sdcard/Habitbull.apk", "sdcard/GRID.apk", "sdcard/JMobileInw.apk" };
            List<string> output = AdbWrapper.PullAllFilesFromDeviceAsync(deviceId, files, destination).Result;
            foreach (var line in output)
            {
                Console.WriteLine(line);
            }
        }
    }
}