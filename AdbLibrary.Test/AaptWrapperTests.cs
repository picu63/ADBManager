﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AdbLibrary.Android;
using NUnit.Framework;

namespace AdbLibrary.Test
{
    public class AaptWrapperTests
    {

        [Test]
        public static void GetOutputFromAapt()
        {
            string apkPath = ProgramManager.GetApp("com.google.android.calendar", Constant.DeviceId).Result.PackagePath;
            string output = AaptWrapper.GetAaptOutput($"dump badging {apkPath}", Constant.DeviceId);
            Assert.IsTrue(output.Contains("Calendar"));
        }
    }
}
