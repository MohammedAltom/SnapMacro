using System;
using System.Collections.Generic;
using System.Text;

namespace SnapMacro.JsonModels
{
    public class SubscribeModel : Model
    {
        public SubscribeModel()
        {
            this.Events = new List<Event>();
            //Events.AddRange(events);
        }



        /*private List<Event> initialEvenets()
        {
            
        }*/
    }
}
