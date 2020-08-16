using AdbLibrary.Android;
using AdbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdbLibrary.Android
{
    public static class FileExplorer
    {
        /// <summary>
        /// Get all the files and directories in from path.
        /// </summary>
        /// <param name="device">Device Id</param>
        /// <param name="directoryPath">Path of directory.</param>
        /// <returns></returns>
        public static async Task<List<string>> GetFilesInDirectory(string directoryPath, string device)
        {
            string output = await AdbWrapper.GetAdbOutputAsync($"shell ls {directoryPath}", device);
            string[] allLines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            if (allLines.Length == 0)
            {
                throw new Exception("No files in given directory.");
            }
            return allLines.ToList();
        }

        /// <summary>
        /// Pushing all files from list to device.
        /// </summary>
        /// <param name="files"></param>
        /// <param name="destination"></param>
        /// <param name="device"></param>
        /// <returns>List of files pushed.</returns>
        public static async Task<List<string>> PushAllFilesToDevice(List<string> files, string destination, Device device)
        {
            List<string> filesPushed = new List<string>();
            foreach (var file in files)
            {
                bool pushed = await PullFileFromDevice(file, destination, device);

                if (pushed)
                {
                    filesPushed.Add(file);
                }
            }
            return filesPushed;
        }
        /// <summary>
        /// Pushing file into device.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="destination"></param>
        /// <param name="device"></param>
        /// <returns>True if file pushed succesfull.</returns>
        public static async Task<bool> PushFileToDevice(string file, string destination, string device)
        {
            try
            {
                bool pushed = false;
                string cmd = $"push \"{file}\" \"{destination}\"";
                string output = await AdbWrapper.GetAdbOutputAsync(cmd, device);
                if (output.Contains("No such file or directory"))
                {
                    return false;
                }
                else if (output.Contains("pushed"))
                {
                    pushed = true;
                }
                return pushed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Pushing file into device.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="destination"></param>
        /// <param name="device"></param>
        /// <returns>True if file pushed succesfull.</returns>
        public static async Task<bool> PushFileToDevice(string file, string destination, Device device)
        {
            try
            {
                bool pushed = false;
                string cmd = $"push \"{file}\" \"{destination}\"";
                string output = await AdbWrapper.GetAdbOutputAsync(cmd, device);
                if (output.Contains("No such file or directory"))
                {
                    return false;
                }
                else if (output.Contains("pushed"))
                {
                    pushed = true;
                }
                return pushed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Pull all files from list of files to destination folder.
        /// </summary>
        /// <param name="device">Device id.</param>
        /// <param name="files">All files paths on device.</param>
        /// <param name="destination">Path of direcotry on PC.</param>
        /// <returns>List of files pulled.</returns>
        public static async Task<List<string>> PullAllFilesFromDevice(List<string> files, string destination, Device device)
        {
            List<string> filesPulled = new List<string>();
            foreach (var file in files)
            {
                bool pulled = await PullFileFromDevice(file, destination, device);

                if (pulled)
                {
                    filesPulled.Add(file); 
                }
            }
            return filesPulled;
        }

        /// <summary>
        /// Pull file from device and copy it to directory on widnows.
        /// </summary>
        /// <param name="file">Full file path on device.</param>
        /// <param name="destination">Path of direcotry on PC.</param>
        /// <param name="device">Device id.</param>
        /// <returns>Returns true if file pulled.</returns>
        public static async Task<bool> PullFileFromDevice(string file, string destination, Device device)
        {
            try
            {
                bool pulled = false;
                string cmd = $"pull \"{file}\" \"{destination}\"";
                string output = await AdbWrapper.GetAdbOutputAsync(cmd, device);
                if (output.Contains("No such file or directory"))
                {
                    pulled = false;
                }
                else if (output.Contains("pulled"))
                {
                    pulled = true;
                }
                return pulled;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
