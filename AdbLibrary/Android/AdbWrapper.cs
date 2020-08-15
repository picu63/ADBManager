using AdbLibrary.Models;
using AdbLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using JCore.JLog;
using System.Runtime.CompilerServices;

namespace AdbLibrary.Android
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
        /// Android API versions.
        /// </summary>
        public enum AndroidVersion
        {
            Android10 = 29,
            Pie9 = 28,
            Oreo_8_1 = 27,
            Oreo_8_0 =  26,
            Nougat_7_1 = 25,
            Nougat_7_0 = 24,
            Marshmallow_6 = 23,
            Lollipop_5_1 = 22,
            Lollipop_5_0 = 21,
            KitKat_4_4 = 19,
            JellyBean_4_3 = 18,
            JellyBean_4_2 = 17,
            JellyBean_4_1 = 16,
            ICS_4_0_4 = 15,
            ICS_4_0_2 = 14,
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
        /// Ensure that there is a server running
        /// </summary>
        public static void StartServer()
        {
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                WorkingDirectory = ToolingPaths.Root,
                FileName = ToolingPaths.AdbPath,
                Arguments = "start-server",
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process adb = Process.Start(psi);
            adb.WaitForExit();
        }

        /// <summary>
        /// Unlocking adb via tcpip.
        /// </summary>
        /// <param name="device">Device Id.</param>
        /// <param name="port">Port for unlocking device.</param>
        public static void UnlockTcpip(string device, int port = 5555)
        {
            RunAdbCommand($"tcpip {port}", device);
        }
        /// <summary>
        /// Unlocking adb via tcpip.
        /// </summary>
        /// <param name="device">Device Id.</param>
        /// <param name="port">Port for unlocking device.</param>
        public static void UnlockTcpip(int device, int port = 5555)
        {
            RunAdbCommand($"tcpip {port}", device);
        }



        /// <summary>
        /// Sends the command to reboot to recovery
        /// </summary>
        /// <param name="device">Device Id.</param>
        public static void RebootRecovery(string device)
        {
            RunAdbCommand("reboot recovery", device);
        }        
        /// <summary>
        /// Sends the command to reboot to recovery
        /// </summary>
        /// <param name="transportId">Device transport id.</param>
        public static void RebootRecovery(int transportId)
        {
            RunAdbCommand("reboot recovery", transportId);
        }



        /// <summary>
        /// Connecting to device by its ipAddress
        /// </summary>
        /// <param name="ipAddress">Wlan Ip of device.</param>
        /// <returns>True if Connection succeded, false if connection couldn't start.</returns>
        public static bool ConnectToDevice(string ipAddress)
        {
            Task<string> t = GetAdbOutputAsync($"connect {ipAddress}");
            if (t.Wait(10000))
            {
                return t.Result.Contains("connected");
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Runs ADB with the specified arguments to certain device.
        /// </summary>
        /// <param name="arguments">The arguments to run against ADB.</param>
        /// <returns>The output of ADB.</returns>
        public static async Task<string> GetAdbOutputAsync(string arguments, string device)
        {
            if (!string.IsNullOrEmpty(device))
            {
                arguments = $"-s {device} {arguments}";
            }
            else
            {
                throw new Exception("Device id cannot be null or empty");
            }
            if (!string.IsNullOrEmpty(arguments))
            {
                var output = await GetAdbOutputAsync(arguments);
                if (output.Contains($"not found"))
                {
                    throw new Exception("Device not found.");
                }
                else if (output.Contains($"more than one"))
                {
                    throw new Exception("error: more than one device/emulator");
                }
                return output;
            }
            else
            {
                throw new ArgumentNullException(arguments);
            }
        }        
        /// <summary>
        /// Runs ADB with the specified arguments to certain device.
        /// </summary>
        /// <param name="arguments">The arguments to run against ADB.</param>
        /// <returns>The output of ADB.</returns>
        public static async Task<string> GetAdbOutputAsync(string arguments, int transportId)
        {
            if (transportId > 0)
            {
                arguments = $"-t {transportId} {arguments}";
            }
            else
            {
                throw new Exception("Device transport id must be greater than 0");
            }
            if (!string.IsNullOrEmpty(arguments))
            {
                var output = await GetAdbOutputAsync(arguments);
                if (output.Contains($"not found"))
                {
                    throw new Exception("Device not found.");
                }
                else if (output.Contains($"more than one"))
                {
                    throw new Exception("error: more than one device/emulator");
                }
                return output;
            }
            else
            {
                throw new ArgumentNullException(arguments);
            }
        }
        /// <summary>
        /// Runs ADB with the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments to run against ADB.</param>
        /// <returns>The output of ADB.</returns>
        public static async Task<string> GetAdbOutputAsync(string arguments)
        {
            if (!string.IsNullOrEmpty(arguments))
            {
                try
                {
                    // First Method
                    var process = CreateAdbProcess(arguments);
                    process.Start();
                    string output = await process.StandardOutput.ReadToEndAsync();

                    if (!string.IsNullOrEmpty(output))
                    {
                        return output;
                    }
                    else
                    {
                        // Second Method if first failed
                        var sb = new StringBuilder();
                        while (process.StandardOutput.Peek() > -1)
                        {
                            sb.AppendLine(process.StandardOutput.ReadLine());
                        }
                        while (process.StandardError.Peek() > -1)
                        {
                            sb.AppendLine(process.StandardError.ReadLine());
                        }
                        process.WaitForExit();
                        string combindedString = sb.ToString();
                        return combindedString;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }


        /// <summary>
        /// Sends to adb commandline coommands to certain device id.
        /// </summary>
        /// <param name="arguments">Command line arguments.</param>
        /// <param name="device">Device id.</param>
        public static void RunAdbCommand(string arguments, string device)
        {
            if (!string.IsNullOrEmpty(device))
            {
                arguments = $"-s {device} {arguments}";
                RunAdbCommand(arguments);
            }
            else
            {
                throw new Exception("Device cannot be null");
            }
        }
        /// <summary>
        /// Run adb command by transport id.
        /// </summary>
        /// <param name="arguments">Command line arguments.</param>
        /// <param name="transportId">Transport id.</param>
        public static void RunAdbCommand(string arguments, int transportId)
        {
            try
            {
                if (transportId > 0)
                {
                    arguments = $"-t {transportId} {arguments}";
                    RunAdbCommand(arguments);
                }
                else
                {
                    throw new Exception("Invalid transport id");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Sends to adb commandline coommands.
        /// </summary>
        /// <param name="arguments">Command line arguments.</param>
        private static void RunAdbCommand(string arguments)
        {
            try
            {
                var process = CreateAdbProcess(arguments);
                process.Start();
                process.WaitForExit();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Create a process of adb.
        /// </summary>
        /// <param name="arguments">All of the arguments for adb.</param>
        /// <returns></returns>
        private static Process CreateAdbProcess(string arguments)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {

                WorkingDirectory = ToolingPaths.Root,
                FileName = ToolingPaths.AdbPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            return process;
        }

    }
}
