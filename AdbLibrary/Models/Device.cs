using AdbLibrary.Android;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdbLibrary.Models
{
    public class Device
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        /// <param name="id">The device ID.</param>
        /// <param name="description">The device description.</param>
        public Device(string id, string description)
        {
            ID = id;
            Description = description;
        }

        /// <summary>
        /// Gets the device identifier.
        /// </summary>
        public string ID { get; }

        /// <summary>
        /// Gets the device description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Parameters of display of android.
        /// </summary>
        public Display Display { get; set; }

        /// <summary>
        /// Status is battery charging.
        /// </summary>
        public bool IsCharging { get; set; }

        /// <summary>
        /// Battery of device level.
        /// </summary>
        public int BatteryLevel { get; set; }

        /// <summary>
        /// Gets or sets the value of android api version.
        /// </summary>
        public AdbWrapper.AndroidVersion Version { get; set; }

    }
}
