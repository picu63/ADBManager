using AdbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AdbLibrary.Android
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
        /// <param name="device">The device.</param>
        /// <returns>The device model name.</returns>
        public static async Task<string> GetDeviceModelAsync(Device device)
        {
            string output = await AdbWrapper.GetAdbOutputAsync($"shell getprop ro.product.model", device);
            return output.Trim();
        }
        /// <summary>
        /// Gets the device manufacturer.
        /// </summary>
        /// <param name="device">The device ID.</param>
        /// <returns>The device manufacturer.</returns>
        public static async Task<string> GetDeviceManufacturerAsync(Device device)
        {
            string output = await AdbWrapper.GetAdbOutputAsync($"shell getprop ro.product.manufacturer", device);
            return output.Trim();
        }

        /// <summary>
        /// Gets connected and authorized devices Ids.
        /// </summary>
        /// <returns>A list of devices.</returns>
        public static async Task<List<Device>> GetAuthorizedDevicesIdAsync()
        {
            try
            {
                AdbWrapper.StartServer();
                List<Device> devices = new List<Device>();
                string output = await AdbWrapper.GetAdbOutputAsync("devices -l");
                string[] lines = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1).Where(l => l.Contains("device")).ToArray();
                foreach (string line in lines)
                {
                    string deviceId = line.Substring(0, line.IndexOf("device")).Trim();
                    string[] prop = line.Substring(line.IndexOf("device")).Split(' ');

                    Device device = new Device(deviceId);
                    device.Product = prop[1].Split(':')[1];
                    device.Model = prop[2].Split(':')[1];
                    device.DeviceName = prop[3].Split(':')[1];
                    device.TransportId = int.Parse(prop[4].Split(':')[1]);

                    devices.Add(device);
                }
                return devices;
            }
            catch (Exception)
            {

                throw;
            }
                
        }

        /// <summary>
        /// Gets the all infomation from android device.
        /// </summary>
        /// <param name="device">Device id.</param>
        /// <returns>Device object.</returns>
        public static async Task<Device> GetAuthorizedDevice(string deviceId)
        {
            Device device = new Device(deviceId);
            device.Description = $"{await GetDeviceManufacturerAsync(device)} {await GetDeviceModelAsync(device)}";
            return device;
        }

        /// <summary>
        /// Gets all the authorized devices.
        /// </summary>
        /// <returns></returns>
        public static List<Device> GetAuthorizedDevices()
        {
            List<Device> devices = GetAuthorizedDevicesIdAsync().Result;
            foreach (var device in devices)
            {
                devices.Add(GetAuthorizedDevice(device.ID).Result);
            }
            return devices;
        }

        /// <summary>
        /// Gets all the authorized devices asynchrously.
        /// </summary>
        /// <returns>List of all devices.</returns>
        public static async Task<List<Device>> GetAuthorizedDevicesAsync()
        {
            List<Device> devices = await GetAuthorizedDevicesIdAsync();
            Task<Device>[] tasks = new Task<Device>[devices.Count];
            for (int i = 0; i < devices.Count; i++)
            {
                tasks[i] = Task.Run(() => GetAuthorizedDevice(devices[i].ID));
            }
            devices.AddRange(await Task.WhenAll(tasks));
            return devices;
        }
        
        /// <summary>
        /// Gets the ip of choosen device.
        /// </summary>
        /// <param name="device">Device Id.</param>
        /// <returns>Ip of wifi address.</returns>
        public static async Task<IPAddress> GetIpOfCurrentWiFiConnection(Device device)
        {
            string output = await AdbWrapper.GetAdbOutputAsync("shell ip addr show wlan0", device);
            if (output.Contains("inet"))
            {
                int startIp = output.IndexOf("inet")+5;
                output = output.Substring(startIp);
                int endIp = output.IndexOf('/');
                output = output.Substring(0, endIp);
            }
            else if (output.Contains("NO-CARRIER"))
            {
                throw new Exception("Device is no connected to wifi.");
            }
            return IPAddress.Parse(output);
        }

        /// <summary>
        /// Gets the andoid API/SDK version.
        /// </summary>
        /// <param name="device">Device Id.</param>
        /// <returns>Api version number.</returns>
        public static async Task<AdbWrapper.AndroidVersion> GetAndroidVersionAsync(Device device)
        {
            string output = await AdbWrapper.GetAdbOutputAsync("shell getprop ro.build.version.sdk", device);
            output = output.Trim();
            return (AdbWrapper.AndroidVersion)int.Parse(output);
        }
    }
}
