using SuperAdbLibrary.Models;
using SuperAdbLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using JCore.JLog;
using System.Runtime.CompilerServices;

namespace SuperAdbLibrary.Android
{
    /// <summary>
    /// Wraps ADB functionality.
    /// </summary>
    public static class AdbWrapper
    {
        /// <summary>
        /// Key sended to device.
        /// </summary>
        public enum KeyEvent
        {
            UNKNOWN = 0,
            MENU = 1,
            SOFT_RIGHT = 2,
            HOME = 3,
            BACK = 4,
            CALL = 5,
            ENDCALL = 6,
            KEYCODE_0 = 7,
            KEYCODE_1 = 8,
            KEYCODE_2 = 9,
            KEYCODE_3 = 10,
            KEYCODE_4 = 11,
            KEYCODE_5 = 12,
            KEYCODE_6 = 13,
            KEYCODE_7 = 14,
            KEYCODE_8 = 15,
            KEYCODE_9 = 16,
            STAR = 17,
            POUND = 18,
            DPAD_UP = 19,
            DPAD_DOWN = 20,
            DPAD_LEFT = 21,
            DPAD_RIGHT = 22,
            DPAD_CENTER = 23,
            VOLUME_UP = 24,
            VOLUME_DOWN = 25,
            POWER_BUTTON = 26,
            CAMERA = 27,
            CLEAR = 28,
            A = 29,
            B = 30,
            C = 31,
            D = 32,
            E = 33,
            F = 34,
            G = 35,
            H = 36,
            I = 37,
            J = 38,
            K = 39,
            L = 40,
            M = 41,
            N = 42,
            O = 43,
            P = 44,
            Q = 45,
            R = 46,
            S = 47,
            T = 48,
            U = 49,
            V = 50,
            W = 51,
            X = 52,
            Y = 53,
            Z = 54,
            COMMA = 55,
            PERIOD = 56,
            ALT_LEFT = 57,
            ALT_RIGHT = 58,
            SHIFT_LEFT = 59,
            SHIFT_RIGHT = 60,
            TAB = 61,
            SPACE = 62,
            SYM = 63,
            EXPLORER = 64,
            ENVELOPE = 65,
            ENTER = 66,
            DEL = 67,
            GRAVE = 68,
            MINUS = 69,
            EQUALS = 70,
            LEFT_BRACKET = 71,
            RIGHT_BRACKET = 72,
            BACKSLASH = 73,
            SEMICOLON = 74,
            APOSTROPHE = 75,
            SLASH = 76,
            AT = 77,
            NUM = 78,
            HEADSETHOOK = 79,
            FOCUS = 80,
            PLUS = 81,
            MENU2 = 82,
            NOTIFICATION = 83,
            SEARCH = 84,
            TAG_LAST_KEYCODE = 85,
        }

        /// <summary>
        /// Sending keycode to android
        /// </summary>
        /// <param name="keyEvent">Keycode for adb.</param>
        public static void SendKeycode(KeyEvent keyEvent)
        {
            RunAdbCommand($"shell input keyevent {(int)keyEvent}");
        }

        /// <summary>
        /// Kills the ADB server.
        /// </summary>
        public static void KillServer()
        {
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                WorkingDirectory = ToolingPaths.Root,
                FileName = ToolingPaths.AdbPath,
                Arguments = "kill-server",
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process adb = Process.Start(psi);
            adb.WaitForExit();
        }

        /// <summary>
        /// Sends to adb commandline coommands.
        /// </summary>
        /// <param name="arguments">Command line arguments.</param>
        public static Process RunAdbCommand(string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                WorkingDirectory = ToolingPaths.Root,
                FileName = ToolingPaths.AdbPath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            return Process.Start(psi);
        }

        /// <summary>
        /// Runs ADB with the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments to run against ADB.</param>
        /// <returns>The output of ADB.</returns>
        public static Task<string> GetAdbOutputAsync(string arguments)
        {
            var output = Task.Run(async () =>
            {
                var adb = RunAdbCommand(arguments);
                adb.WaitForExit();
                return await adb.StandardOutput.ReadToEndAsync();
            });
            return output;
        }

        /// <summary>
        /// Runs ADB with the specified arguments to concrete device.
        /// </summary>
        /// <param name="arguments">The arguments to run against ADB.</param>
        /// <returns>The output of ADB.</returns>
        public static Task<string> GetAdbOutputAsync(string arguments, string device)
        {
            if (!string.IsNullOrEmpty(device))
            {
                arguments = $"-s {device} {arguments}";
            }
            var output = GetAdbOutputAsync(arguments);
            return output;
        }
    }
}
