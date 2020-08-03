using NUnit.Framework;
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
        public void Test1()
        {
            List<string> filesAndDirs = SuperAdbLibrary.Android.AdbWrapper.GetFilesInDirectory("sdcard").Result;
            foreach (var file in filesAndDirs)
            {
                Console.WriteLine(file);
            }
            Assert.Contains("Android",filesAndDirs);
        }
    }
}