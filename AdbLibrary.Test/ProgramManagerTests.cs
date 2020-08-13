using AdbLibrary.Android;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdbLibrary.Test
{
    public class ProgramManagerTests
    {
        [Test]
        public void GetAppFromPackage()
        {
            string packageName = "com.google.android.calendar";
            Task.WaitAll(ProgramManager.GetApp(packageName, Constant.deviceId));
        }
    }
}
