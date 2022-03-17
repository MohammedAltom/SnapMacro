using System;
using System.Collections.Generic;
using System.Text;

namespace SnapMacro.JsonModels
{
    public class RegisterModel : Model
    {
        public RegisterModel()
        {
            this.Events = new List<Event>();
        }
    }
}
