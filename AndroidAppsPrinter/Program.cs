using System;
using System.Collections.Generic;
using AdbLibrary.Android;
using AdbLibrary.Models;

namespace AndroidAppsPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Device> devices = DeviceManager.GetAuthorizedDevicesIdAsync().Result;
            Console.WriteLine("List of connected devices:");
            foreach (var device in devices)
            {
                Console.WriteLine(device.ID);
                Console.WriteLine(device.TransportId);
            }
        }
    }
}
