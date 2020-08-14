using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AdbLibrary.Android
{
    /// <summary>
    /// Maintains paths for scrcpy.
    /// </summary>
    internal static class ToolingPaths
    {
        /// <summary>
        /// Initializes static members of <see cref="ToolingPaths"/>.
        /// </summary>
        static ToolingPaths()
        {
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Root = Path.Combine(exeDirectory, ToolingDirectory);

            AdbPath = Path.Combine(Root, AdbName);
            ScrcpyPath = Path.Combine(Root, ScrcpyNoConsoleName);
            Aaptx86Path = Path.Combine(Root, Aaptx86Directory, AaptName);
            AaptArmPath = Path.Combine(Root, AaptArmDirectory, AaptName);
        }

        /// <summary>
        /// Temporary directory on device.
        /// </summary>
        internal const string TmpDirectory = "/data/local/tmp";

        /// <summary>
        /// The name of the ADB executable.
        /// </summary>
        private const string AdbName = "adb.exe";

        /// <summary>
        /// The name of the scrcpy executable.
        /// </summary>
        private const string ScrcpyNoConsoleName = "scrcpy-noconsole.exe";

        /// <summary>
        /// The name of the directory containing android executables.
        /// </summary>
        private const string ToolingDirectory = "android-lib";

        /// <summary>
        /// The name of the aapt for x86 cpu architecture.
        /// </summary>
        private const string Aaptx86Directory = "aapt-x86";

        /// <summary>
        /// The name of the aapt for arm cpu architecture.
        /// </summary>
        private const string AaptArmDirectory = "aapt-arm";

        /// <summary>
        /// The name of aapt to send to device.
        /// </summary>
        private const string AaptName = "aapt.jar";
        /// <summary>
        /// Gets the path of the directory containing Android tools.
        /// </summary>
        public static string Root { get; }

        /// <summary>
        /// Gets the path to the adb executable.
        /// </summary>
        public static string AdbPath { get; }

        /// <summary>
        /// Gets the path to the scrcpy executable.
        /// </summary>
        public static string ScrcpyPath { get; }

        /// <summary>
        /// Gets the path on desktop to the aapt for x86 cpu architecture.
        /// </summary>
        public static string Aaptx86Path { get; }

        /// <summary>
        /// Gets the path on desktop to the aapt for arm cpu architecture.
        /// </summary>
        public static string AaptArmPath { get; }

        /// <summary>
        /// Gets the full path from Aapt on device.
        /// </summary>
        public static string AaptPathOnDevice { get {return TmpDirectory + "/" + AaptName; }}

        /// <summary>
        /// Path of file for temporary output.
        /// </summary>
        public static string TmpFile { get { return $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\tmp.txt"; } }
    }
}
