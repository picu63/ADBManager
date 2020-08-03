﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SuperAdbLibrary.Android
{
    /// <summary>
    /// Wraps scrcpy functionality.
    /// </summary>
    public static class ScrcpyWrapper
    {
        /// <summary>
        /// Gets scrcpy process start information for the specified device.
        /// </summary>
        /// <param name="device">The device ID.</param>
        /// <param name="maxSize">The maximum size of the video feed.</param>
        /// <returns>Relevant process start information.</returns>
        public static ProcessStartInfo GetStartInfo(string device, int? maxSize)
        {
            StringBuilder launchArgs = new StringBuilder();
            launchArgs.Append("-s ");
            launchArgs.Append(device);

            if (maxSize.HasValue)
            {
                launchArgs.Append(" -m ");
                launchArgs.Append(maxSize.Value);
            }

            ProcessStartInfo psi = new ProcessStartInfo()
            {
                WorkingDirectory = ToolingPaths.Root,
                FileName = ToolingPaths.ScrcpyPath,
                Arguments = launchArgs.ToString(),
            };
            return psi;
        }

        public static void KillScrcpy()
        {

        }
    }
}
