using System;
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
        public static void PushAaptToDevice()
        {
            AaptWrapper.PushAaptToDevice(Constant.deviceId);
        }

        [Test]
        public static void GetOutputFromAapt()
        {
            string output = AaptWrapper.GetAaptOutput("dump badging \"/data/app/com.google.android.calendar-cMQvji6ZR0gf2cFHjBp7Kw==/base.apk\"", Constant.deviceId);
            Assert.IsTrue(output.Contains("Calendar"));
        }
    }
}
