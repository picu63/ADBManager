using AdbLibrary.Android;
using AdbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// Gets the string 
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        public static async Task<string> GetAaptOutput(string arguments, Device device)
        {
            if (string.IsNullOrEmpty(arguments))
            {
                throw new Exception($"{nameof(arguments)} cannot be null or empty");
            }
            string cmd = $"shell \"{ToolingPaths.AaptPathOnDevice}\" {arguments}";
            string output = await AdbWrapper.GetAdbOutputAsync(cmd, device);

            return output;
        }
    }
}
