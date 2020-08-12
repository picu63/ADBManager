using AdbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdbLibrary.Android
{
    public static class ProgramManager
    {
        public static async Task<App> GetApp(string packageName, string device)
        {
            App app = new App();
            string output = await AdbWrapper.GetAdbOutputAsync($"shell pm list packages -f {packageName}", device);
            string baseApkPath = output.Substring(0, output.LastIndexOf('=')).Substring(output.IndexOf(':')+1);
            string appName = await AdbWrapper.GetAdbOutputAsync($"shell /data/local/tmp/aapt-arm-pie", device);
            return app;
        }
        public static async Task<List<App>> GetAllApps(string device)
        {
            throw new NotImplementedException();
        }
    }
}
