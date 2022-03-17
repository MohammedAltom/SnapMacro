using System;
using System.Collections.Generic;
using System.Text;

namespace SnapMacro.JsonModels
{
    public class Event
    {
        public int? Delta { get; set; }
        public string? EventType { get; set; }
        public string? KeyName { get; set; }
        public string? Msg { get; set; }
        public int? Timestamp { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
    }
}
