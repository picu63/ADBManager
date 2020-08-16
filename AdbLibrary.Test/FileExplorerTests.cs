using NUnit.Framework;
using AdbLibrary.Android;
using System;
using System.Collections.Generic;

namespace AdbLibrary.Test
{
    public class FilesExplorerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfGettingAllFiles()
        {
            List<string> filesAndDirs = FileExplorer.GetFilesInDirectory("sdcard", Constant.DeviceId).Result;
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
            bool output = FileExplorer.PullFileFromDevice("sdcard/Android/ANDROID.PERMISSION.TEST", destination, Constant.Device).Result;
            Assert.IsTrue(output);
        }

        [Test]
        public void PullingMultipleFiles()
        {
            string destination = @"C:\ADB\Test";
            List<string> files = new List<string>() { "sdcard/Habitbull.apk", "sdcard/GRID.apk", "sdcard/JMobileInw.apk" };
            List<string> output = FileExplorer.PullAllFilesFromDevice(files, destination, Constant.Device).Result;
            foreach (var line in output)
            {
                Console.WriteLine(line);
            }
        }
    }
}