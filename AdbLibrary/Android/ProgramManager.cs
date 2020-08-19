using AdbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdbLibrary.Android
{
    public static class ProgramManager
    {
        public static async Task<App> GetApp(string packageName, Device device)
        {
            App app = new App();
            string output = await AdbWrapper.GetAdbOutputAsync($"shell pm list packages -f {packageName}", device);
            string baseApkPath = output.Substring(0, output.LastIndexOf('=')).Substring(output.IndexOf(':') + 1);
            var aaptOutput = (await AaptWrapper.GetAaptOutput($"dump badging \"{baseApkPath}\"", device));
            if (aaptOutput.Contains("application-label:"))
            {
                List<string> aaptOutputList = aaptOutput.ToList();
                var appName = aaptOutputList.First(s => s.Contains("application-label")).Split(':')[1].Split('\'')[1];
                if (!string.IsNullOrEmpty(appName))
                {
                    app.Name = appName;
                }
            }
            app.PackagePath = baseApkPath;
            return app;
        }

        /// <summary>
        /// Gets all of the apps from selected device
        /// </summary>
        /// <param name="device">Device.</param>
        /// <returns>List of all app on device.</returns>
        public static async Task<List<App>> GetAllApps(Device device)
        {

            List<App> apps = new List<App>();
            var lines = (await AdbWrapper.GetAdbOutputAsync($"shell pm list packages", device)).ToList();
            //lines.RemoveRange(20, lines.Count - 20);
            int size = lines.Count;
            Task<App>[] tasks = new Task<App>[size];
            for (int i = 0; i < lines.Count; i++)
            {
                string packageName = lines[i].Split(':')[1];
                tasks[i] = Task.Run(() => GetApp(packageName, device));
            }
            apps.AddRange(await Task.WhenAll(tasks));
            //foreach (var line in lines)
            //{
            //    apps.Add(await GetApp(line.Split(':')[1], device));
            //}
            return apps;
        }
    }
}
