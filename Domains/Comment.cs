using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    [AddINotifyPropertyChangedInterface]
    public class Comment
    {

        public int Id { get; set; }

        public bool IsAccepted { get; set; } = false;

        public string CommentText { get; set; }

        public int NotificationId { get; set; }
  
        public Notification Notification { get; set; }
    }
}
