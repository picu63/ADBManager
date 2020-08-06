using NUnit.Framework;
using SuperAdbLibrary.Android;
using System;
using System.Collections.Generic;

namespace SuperAdbLibrary.Test
{
    public class FilesExplorer
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfGettingAllFiles()
        {
            List<string> filesAndDirs = SuperAdbLibrary.Android.AdbWrapper.GetFilesInDirectory(Properties.deviceId,"sdcard").Result;
            foreach (var file in filesAndDirs)
            {
                Console.WriteLine(file);
            }
            Assert.Contains("Android",filesAndDirs);
        }

        [Test]
        public void PullingOneFile()
        {
            string destination = @"C:\ADB";
            string output = AdbWrapper.PullFileFromDevice(Properties.deviceId, "sdcard/Android/ANDROID.PERMISSION.TEST", destination).Result;
            Console.WriteLine(output, destination);
        }

        [Test]
        public void PullingMultipleFiles()
        {
            string destination = @"C:\ADB\Test";
            List<string> files = new List<string>() { "sdcard/Habitbull.apk", "sdcard/GRID.apk", "sdcard/JMobileInw.apk" };
            List<string> output = AdbWrapper.PullAllFilesFromDeviceAsync(Properties.deviceId, files, destination).Result;
            foreach (var line in output)
            {
                Console.WriteLine(line);
            }
        }
    }
}