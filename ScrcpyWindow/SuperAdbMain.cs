using SuperAdbLibrary.Android;
using SuperAdbLibrary.Models;
using SuperADBLibrary.Android;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperAdbUI
{
    public partial class SuperAdbMain : Form
    {
        /// <summary>
        /// Object of scrcpyFrm.
        /// </summary>
        ScrcpyWin scrcpyFrm;

        /// <summary>
        /// Current selected device from ComboBox.
        /// </summary>
        private Device currentDevice;

        /// <summary>
        /// List of all detected devices.
        /// </summary>
        private List<Device> connectedDevices;
        private object deviceLock = new object();

        /// <summary>
        /// Frame around scrcpyMainPanel.
        /// </summary>
        int scrcpyFrmMargin = 6;

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
        /// Loading scrcpy form into scrcpyMainPanel.
        /// </summary>
        private void LoadScrcpyFrm()
        {
            scrcpyFrm = new ScrcpyWin() { TopLevel = false, TopMost = true };
            scrcpyFrm.Size = new Size(scrcpyMainPanel.Size.Width - scrcpyFrmMargin, scrcpyMainPanel.Height - scrcpyFrmMargin);
            this.scrcpyMainPanel.Controls.Add(scrcpyFrm);
            scrcpyFrm.Location = new Point(3, 3);
            scrcpyFrm.Show();
        }

        /// <summary>
        /// Positioning of <c>scrcpyMainPanel</c>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scrcpyMainPanel_Resize(object sender, EventArgs e)
        {
            RefreshLayout();
        }

        /// <summary>
        /// Layout setting size of panels. Manual.
        /// </summary>
        private void RefreshLayout()
        {
            var ratio = (currentDevice.Display == null) ? (float)16/9 : currentDevice.Display.AspectRatio;
            float width = (float)this.scrcpyMainPanel.Size.Height / ratio;
            int height = this.scrcpyMainPanel.Size.Height;
            scrcpyFrm.Size = new Size((int)width - scrcpyFrmMargin, (int)height - scrcpyFrmMargin);
            scrcpyMainPanel.Size = new Size((int)width, (int)height);
            scrcpyMainPanel.Location = new Point(this.Width - scrcpyMainPanel.Size.Width - 30 /*TODO poprawić margines boczny*/, scrcpyMainPanel.Location.Y);
            tabControl.Size = new Size(this.Width - scrcpyMainPanel.Size.Width - 50 /*TODO dać jako parametr*/, tabControl.Height);
        }

        /// <summary>
        /// When click on another device this method will load device parameters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void devicesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock (deviceLock)
            {
                currentDevice = (Device)devicesCB.SelectedItem;
            }
        }

        /// <summary>
        /// Gets the connected Android devices Id and Manufacturer Name.
        /// </summary>
        public async void GetDevicesAsync()
        {
            var devicesTasks = (await DeviceManager.GetAuthorizedDevicesAsync())
                .Select(async s => new Device(s, $"{await DeviceManager.GetDeviceManufacturerAsync(s)} {await DeviceManager.GetDeviceModelAsync(s)}"))
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

        private void refreshDevicesBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if window is in correctly aspect ratio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuperAdbMain_ResizeEnd(object sender, EventArgs e)
        {
            if ((float)this.Height/this.Width > 1)
            {
                this.Size = this.MinimumSize;
            }
        }

        /// <summary>
        /// Connect with device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectBt_Click(object sender, EventArgs e)
        {
            var selectedItemFromCb = (Device)devicesCB.SelectedItem;
            if (currentDevice != selectedItemFromCb)
            {
                currentDevice = selectedItemFromCb;
            }
            RunScrcpyWindowAsync();
        }

        /// <summary>
        /// Connect with currentdevice
        /// </summary>
        private async void RunScrcpyWindowAsync()
        {
            currentDevice.Display = await DeviceManager.GetDisplayInfoAsync(currentDevice);
            RefreshLayout();
            if (scrcpyFrm.proc != null)
            {
                scrcpyFrm.proc.Kill();
            }
            scrcpyFrm.RunScrcpy(currentDevice);
        }
        private void getDirBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
