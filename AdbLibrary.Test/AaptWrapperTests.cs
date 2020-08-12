using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
