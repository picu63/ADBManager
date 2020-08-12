using SuperADBLibrary.Android;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdbLibrary.Android
{
    public static class AaptWrapper
    {
        public static async void PushAaptToDevice(string device)
        {
            string output = await AdbWrapper.GetAdbOutputAsync("shell getprop ro.product.cpu.abi", device);
            if (output.Contains("arm"))
            {
                FileExplorer.PushFileToDevice(ToolingPaths.AaptArmPath, "/data/local/tmp", device);
                AdbWrapper.RunAdbCommand($"adb shell chmod 0755 \"/data/local/tmp/{ToolingPaths.AaptArmName}\"");
            }
            else if(output.Contains("x86"))
            {

            }
        }
    }
}
