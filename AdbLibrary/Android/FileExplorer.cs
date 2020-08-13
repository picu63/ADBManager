using AdbLibrary.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperADBLibrary.Android
{
    public static class FileExplorer
    {
        /// <summary>
        /// Get all the files and directories in from path.
        /// </summary>
        /// <param name="device">Device Id</param>
        /// <param name="directoryPath">Path of directory.</param>
        /// <returns></returns>
        public static async Task<List<string>> GetFilesInDirectory(string device, string directoryPath)
        {
            string[] output = (await AdbWrapper.GetAdbOutputAsync($"shell ls {directoryPath}", device))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            return output.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="destination"></param>
        /// <param name="device"></param>
        /// <returns>True if file pushed succesfull.</returns>
        public static async Task<bool> PushFileToDevice(string file, string destination, string device)
        {
            string cmd = $"push \"{file}\" \"{destination}\"";
            string output = await AdbWrapper.GetAdbOutputAsync(cmd, device);
            return output.Contains("pushed");
        }

        /// <summary>
        /// Pull all files from list of files to destination folder.
        /// </summary>
        /// <param name="device">Device id.</param>
        /// <param name="files">All files paths on device.</param>
        /// <param name="destination">Path of direcotry on PC.</param>
        /// <returns></returns>
        public static List<string> PullAllFilesFromDevice(string device, List<string> files, string destination)
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
            try
            {
                string cmd = $"pull \"{file}\" \"{destination}\"";
                return AdbWrapper.GetAdbOutputAsync(cmd, device);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
