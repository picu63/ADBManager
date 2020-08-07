using NUnit.Framework;
using SuperAdbLibrary.Android;
using SuperADBLibrary.Android;
using System;
using System.Collections.Generic;

namespace SuperAdbLibrary.Test
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
            List<string> filesAndDirs = FileExplorer.GetFilesInDirectory(Properties.deviceId, "sdcard").Result;
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
            string output = FileExplorer.PullFileFromDevice(Properties.deviceId, "sdcard/Android/ANDROID.PERMISSION.TEST", destination).Result;
            Console.WriteLine(output, destination);
        }

        [Test]
        public void PullingMultipleFiles()
        {
            string destination = @"C:\ADB\Test";
            List<string> files = new List<string>() { "sdcard/Habitbull.apk", "sdcard/GRID.apk", "sdcard/JMobileInw.apk" };
            List<string> output = FileExplorer.PullAllFilesFromDevice(Properties.deviceId, files, destination);
            foreach (var line in output)
            {
                Console.WriteLine(line);
            }
        }
    }
}