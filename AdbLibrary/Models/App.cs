using System;
using System.Collections.Generic;
using System.Text;

namespace AdbLibrary.Models
{
    public class App
    {
        /// <summary>
        /// Name of the app visible in android launcher.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of main android application id (for example: <c>com.google.android.calendar</c>)
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// Base apk path on device.
        /// </summary>
        public string PackagePath { get; set; }

        /// <summary>
        /// Convert app to string.
        /// </summary>
        /// <returns>The name of the app visible in launcher.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
