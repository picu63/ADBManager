using SuperAdbLibrary.Android;
using SuperAdbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperADBLibrary.Android
{
    /// <summary>
    /// Methods getting info from device
    /// </summary>
    public static class DeviceManager
    {
        /// <summary>
        /// Gets the parameters of android screen.
        /// </summary>
        /// <returns>Width, Height, Density</returns>
        public static async Task<Display> GetDisplayInfoAsync(Device device)
        {
            try
            {
                Display display = new Display();
                string[] resolution = (await AdbWrapper.GetAdbOutputAsync($"shell wm size", device.ID)).Split(' ')[2].Trim().Split('x'); //adb output: Physical size: {width}x{height}\r\n
                string physicalDensity = (await AdbWrapper.GetAdbOutputAsync($"shell wm density", device.ID)).Split(' ')[2].Split('\r')[0];
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
        /// Gets the device model.
        /// </summary>
        /// <param name="device">The device ID.</param>
        /// <returns>The device model name.</returns>
        public static async Task<string> GetDeviceModelAsync(string device)
        {
            string output = await AdbWrapper.GetAdbOutputAsync($"shell getprop ro.product.model", device);
            return output.Trim();
        }
        /// <summary>
        /// Gets the device manufacturer.
        /// </summary>
        /// <param name="device">The device ID.</param>
        /// <returns>The device manufacturer.</returns>
        public static async Task<string> GetDeviceManufacturerAsync(string device)
        {
            string output = await AdbWrapper.GetAdbOutputAsync($"shell getprop ro.product.manufacturer", device);
            return output.Trim();
        }
        /// <summary>
        /// Gets connected and authorized devices.
        /// </summary>
        /// <returns>A list of device IDs.</returns>
        public static async Task<List<string>> GetAuthorizedDevicesAsync()
        {
            string output = await AdbWrapper.GetAdbOutputAsync("devices");

            return output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(s => s.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries))
                .Where(d => d[1] == "device")
                .Select(d => d[0])
                .ToList();
        }
    }
}
