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

namespace SuperAdbLibrary.Android
{
    /// <summary>
    /// Wraps ADB functionality.
    /// </summary>
    public static class AdbWrapper
    {
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
        /// Gets connected and authorized devices.
        /// </summary>
        /// <returns>A list of device IDs.</returns>
        public static async Task<List<string>> GetAuthorizedDevicesAsync()
        {
            string output = await GetAdbOutputAsync("devices");

            return output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(s => s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries))
                .Where(d => d[1] == "device")
                .Select(d => d[0])
                .ToList();
        }

        /// <summary>
        /// Gets the device manufacturer.
        /// </summary>
        /// <param name="device">The device ID.</param>
        /// <returns>The device manufacturer.</returns>
        public static async Task<string> GetDeviceManufacturerAsync(string device)
        {
            string output = await GetAdbOutputAsync($"-s {device} shell getprop ro.product.manufacturer");
            return output.Trim();
        }

        /// <summary>
        /// Gets the device model.
        /// </summary>
        /// <param name="device">The device ID.</param>
        /// <returns>The device model.</returns>
        public static async Task<string> GetDeviceModelAsync(string device)
        {
            string output = await GetAdbOutputAsync($"-s {device} shell getprop ro.product.model");
            return output.Trim();
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
        public static void RunAdbCommand(string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                WorkingDirectory = ToolingPaths.Root,
                FileName = ToolingPaths.AdbPath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process adb = Process.Start(psi);
        }

        /// <summary>
        /// Runs ADB with the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments to run against ADB.</param>
        /// <returns>The output of ADB.</returns>
        private static Task<string> GetAdbOutputAsync(string arguments, string deviceId = "")
        {
            return Task.Run(async () =>
            {
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    WorkingDirectory = ToolingPaths.Root,
                    FileName = ToolingPaths.AdbPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };

                Process adb = Process.Start(psi);
                adb.WaitForExit();
                string output = await adb.StandardOutput.ReadToEndAsync();
                return output;
            });
        }

        /// <summary>
        /// Gets the parameters of android screen.
        /// </summary>
        /// <returns>Width, Height, Density</returns>
        public static async Task<Display> GetDisplayInfoAsync(Device device)
        {
            try
            {
                Display display = new Display();
                string[] resolution = (await GetAdbOutputAsync($"-s {device.ID} shell wm size")).Split(' ')[2].Trim().Split('x'); //adb output: Physical size: {width}x{height}\r\n
                string physicalDensity = (await GetAdbOutputAsync($"-s {device.ID} shell wm density")).Split(' ')[2].Split('\r')[0];
                display.Width = int.Parse(resolution[0]);
                display.Height = int.Parse(resolution[1]);
                display.Density = int.Parse(physicalDensity);
                return display;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Get all the files and directories in from path.
        /// </summary>
        /// <param name="device">Device Id</param>
        /// <param name="directoryPath">Path of directory.</param>
        /// <returns></returns>
        public static async Task<List<string>> GetFilesInDirectory(string device, string directoryPath)
        {
            string[] output = (await GetAdbOutputAsync($"-s {device} shell ls {directoryPath}"))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            return output.ToList();
        }

        /// <summary>
        /// Pull all files from list of files to destination folder.
        /// </summary>
        /// <param name="device">Device id.</param>
        /// <param name="files">All files paths on device.</param>
        /// <param name="destination">Path of direcotry on PC.</param>
        /// <returns></returns>
        public static async Task<List<string>> PullAllFilesFromDeviceAsync(string device, List<string> files, string destination)
        {
            List<Task<string>> tasks = new List<Task<string>>();
            foreach (var file in files)
            {
                tasks.Add(PullFileFromDevice(device, file, destination));
            }
            Task.WaitAll(tasks.ToArray());
            List<string> output = tasks.Select(s => s.Result).ToList();
            return output;
        }

        /// <summary>
        /// Pull file from device and copy it to directory on widnows.
        /// </summary>
        /// <param name="device">Device id.</param>
        /// <param name="file">Full file path on device.</param>
        /// <param name="destination">Path of direcotry on PC.</param>
        /// <returns></returns>
        public static Task<string> PullFileFromDevice(string device, string file, string destination)
        {
            string cmd = $"-s {device} pull \"{file}\" \"{destination}\"";
            return GetAdbOutputAsync(cmd);
        }
    }
}
