using System;
using System.Collections.Generic;
using System.Text;

namespace SnapMacro.JsonModels
{
    public class Model
    {
        public int Acceleration { get; set; } = 1;
        public string CreationTime { get; set; } = "20220226T051717";
        public bool DoNotShowWindowOnFinish { get; set; } = false;
        public List<Event> Events { get; set; }
        public int LoopDuration { get; set; } = 0;
        public int LoopInterval { get; set; } = 0;
        public int LoopIterations { get; set; } = 1;
        public string LoopType { get; set; } = "TillLoopNumber";
        public int MacroSchemaVersion { get; set; } = 3;
        public List<string> MergeConfigurations { get; set; } = new List<string>();
        public bool RestartPlayer { get; set; } = false;
        public int RestartPlayerAfterMinutes { get; set; } = 60;

        public string Shortcut { get; set; } = "";


    }
}
