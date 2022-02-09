using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    [AddINotifyPropertyChangedInterface]
    public class Notification 
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
    }
}
