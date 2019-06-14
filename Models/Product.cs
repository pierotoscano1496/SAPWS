using System;

namespace SAPWS.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string SapProduct { get; set; }
        public string SapVersion { get; set; }
        public string SapSupportPackage { get; set; }
        public string SapServerOperatingSystem { get; set; }
        public string SapServerIp { get; set; }
        public string DatabaseProduct { get; set; }
        public string DatabaseVersion { get; set; }
        public string DatabaseSupportPackage { get; set; }
        public string DatabaseServerOperatingSystem { get; set; }
        public string DatabaseServerIp { get; set; }
        public int CustomerId { get; set; }
    }
}