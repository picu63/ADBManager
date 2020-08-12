using SuperADBLibrary.Android;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AdbLibrary.Android
{
    public static class AaptWrapper
    {
        public static async Task<bool> PushAaptToDevice(string device)
        {
            string cpuVersion = await AdbWrapper.GetAdbOutputAsync("shell getprop ro.product.cpu.abi", device);
            bool pushed = false;
            if (cpuVersion.Contains("arm"))
            {
                pushed = await FileExplorer.PushFileToDevice(ToolingPaths.AaptArmPath, ToolingPaths.TmpDirectory, device);
            }
            else if(cpuVersion.Contains("x86"))
            {
                pushed = await FileExplorer.PushFileToDevice(ToolingPaths.Aaptx86Path, ToolingPaths.TmpDirectory, device);
            }
            AdbWrapper.RunAdbCommand($"shell chmod 0755 \"{ToolingPaths.AaptPathOnDevice}\"", device);
            return pushed;
        }

        public static async Task<string> RunAaptCommand(string device)
        {
            string output = await AdbWrapper.GetAdbOutputAsync("shell \"/data/local/tmp/aapt.a\" dump badging \"/data/app/com.google.android.calendar-cMQvji6ZR0gf2cFHjBp7Kw==/base.apk\" | findstr /R /C:\"icon\"");
            string output2 = await AaptWrapper.GetAaptOutputAsync("dump badging \"/data/app/com.google.android.calendar-cMQvji6ZR0gf2cFHjBp7Kw==/base.apk\" | findstr /R /C:\"icon\"");
            return null;
        }

        private static Task<string> GetAaptOutputAsync(string arguments, string device)
        {
            string cmd = $"shell \"{ToolingPaths.AaptPathOnDevice}\" {arguments}";

        }
    }
}
