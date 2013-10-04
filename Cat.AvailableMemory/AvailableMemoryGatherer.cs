using System;
using Cat.Core;
using Cat.Core.Parsing;

namespace Cat.AvailableMemory
{
    public class AvailableMemoryGatherer : ICanMeow
    {
        public Meow Meow()
        {
            var ram = GetAvailableMemory();
            var meow = new Meow()
            {
                DateStamp = DateTime.Now,
                MeowCode = "AVAILABLE_MEMORY",
                Origin = "Unknown",
                Message = ram + "MB"
            };
            return meow;
        }

        private string GetAvailableMemory()
        {
            var ramCounter = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");
            return ramCounter.NextValue().ToString();
        }
    }
}
