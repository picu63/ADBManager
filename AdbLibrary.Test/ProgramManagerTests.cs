using AdbLibrary.Android;
using AdbLibrary.Models;
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
            App app = ProgramManager.GetApp(packageName, Constant.Device).Result;
            Console.WriteLine(app.PackagePath);
        }
        [Test]
        public void GetAllApps()
        {
            List<App> apps = ProgramManager.GetAllApps(Constant.Device).Result;
            foreach (var app in apps)
            {
                Console.WriteLine(app);
            }
        }
    }
}
