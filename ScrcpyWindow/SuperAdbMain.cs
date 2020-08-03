using SuperAdbLibrary.Android;
using SuperAdbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperAdbUI
{
    public partial class SuperAdbMain : Form
    {
        ScrcpyWin scrcpyFrm;
        private Device currentDevice;
        private List<Device> connectedDevices;

        public SuperAdbMain()
        {
            InitializeComponent();
            connectedDevices = new List<Device>();
        }

        private void SuperAdbMain_Load(object sender, EventArgs e)
        {
            GetDevicesAsync();
            LoadScrcpyFrm();
        }

        /// <summary>
        /// Loading scrcpy form.
        /// </summary>
        private void LoadScrcpyFrm()
        {
            scrcpyFrm = new ScrcpyWin() { TopLevel = false, TopMost = true };
            scrcpyFrm.Size = scrcpyMainPanel.Size;
            this.scrcpyMainPanel.Controls.Add(scrcpyFrm);
            scrcpyFrm.Show();
        }

        private void scrcpyMainPanel_Resize(object sender, EventArgs e)
        {
            scrcpyFrm.Size = this.scrcpyMainPanel.Size;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            scrcpyFrm.RunScrcpy(currentDevice);
        }

        /// <summary>
        /// When click on another device this method will load device parameters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void devicesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentDevice = (Device)devicesCB.SelectedItem;
            AdbWrapper.DisplaySize().ContinueWith(UpdateAspectRatio, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets the connected Android devices Id and Manufacturer Name.
        /// </summary>
        public async void GetDevicesAsync()
        {
            var devicesTasks = (await AdbWrapper.GetAuthorizedDevicesAsync())
                .Select(async s => new Device(s, $"{await AdbWrapper.GetDeviceManufacturerAsync(s)} {await AdbWrapper.GetDeviceModelAsync(s)}"))
                .ToList();
            Device[] devicesT = await Task.WhenAll(devicesTasks);
            if (devicesT.Length != connectedDevices.Count)
            {
                devicesCB.Items.AddRange(devicesT);
                connectedDevices = new List<Device>(devicesT);
                devicesCB.DisplayMember = nameof(Device.Description);
                devicesCB.SelectedItem = connectedDevices.First();
            }
        }

        /// <summary>
        /// Aktualizuje rozmiar okna
        /// </summary>
        /// <param name="task"></param>
        /// <param name="arg2"></param>
        private void UpdateAspectRatio(Task<Display> task)
        {
            currentDevice.Display = task.Result;
        }
    }
}
