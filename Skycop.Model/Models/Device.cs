using System;

namespace Skycop.Model.Models
{
    public class Device
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IP{ get; set; }
        public int Port { get; set; }
        public string HardDrive { get; set; }
        public int CameraNumber{get;set;}
        public string Recording { get; set; }
        public string VideoLoss { get; set; }
        public DateTime Date { get; set; }
        public string DeviceType { get; set; }
        public string Version { get; set; }
        public int Web { get; set; }
        public DateTime DVRTime { get; set; }
    }
}
