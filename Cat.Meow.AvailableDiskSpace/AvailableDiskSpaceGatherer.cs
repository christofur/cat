using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cat.Core;
using Cat.Core.Parsing;

namespace Cat.AvailableDiskSpace
{
    public class AvailableDiskSpaceGatherer : ICanMeow
    {
        public Meow Meow()
        {
            var diskspace = GetAvailableDiskSpace();
            var meow = new Meow()
                {
                    DateStamp = DateTime.Now, 
                    MeowCode = "AVAILABLE_DISK_SPACE", 
                    Origin = "Unknown", 
                    Message = ToJSON.Do(diskspace)
                };
            return meow;
        }

        private Dictionary<string, long> GetAvailableDiskSpace()
        {
            return DriveInfo.GetDrives().Where(drive => drive.IsReady).ToDictionary(drive => drive.Name, drive => drive.TotalFreeSpace);
        }
    }


}
