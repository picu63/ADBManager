using AdbLibrary.Android;
using AdbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AdbLibrary.Android
{
    /// <summary>
    /// 
    /// </summary>
    public static class AaptWrapper
    {
        /// <summary>
        /// Pushing binaries of aapt for selected device.
        /// </summary>
        /// <param name="device">Transport id.</param>
        /// <returns>True if pushing aapt to device success.</returns>
        public static async Task<bool> PushAaptToDevice(Device device)
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


        public static string GetAaptOutput(string arguments, string device)
        {
            if (string.IsNullOrEmpty(device))
            {
                throw new Exception($"{nameof(device)} cannot be null or empty");
            }
            if (string.IsNullOrEmpty(arguments))
            {
                throw new Exception($"{nameof(arguments)} cannot be null or empty");
            }

            string cmd = $"shell \"{ToolingPaths.AaptPathOnDevice}\" {arguments}";
            string output = AdbWrapper.GetAdbOutputAsync(cmd, device).Result;

            return output;
        }
    }
}
