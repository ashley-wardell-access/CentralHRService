using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralHRService.Models
{
    public class InstanceViewModel
    {
        public string InstanceName { get; set; }
        public Guid LicenseGuid { get; set; }
        public Guid LastRunSSUGuid { get; set; }
        public int VersionMajor { get; set; }
        public int VersionMinor { get; set; }
        public int Build { get; set; }
        public int Revision { get; set; }
        public DateTime LastPing { get; set; }
    }
}
