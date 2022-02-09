using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domains
{
    [AddINotifyPropertyChangedInterface]
    [Table("Workers")]
    public class Worker :User, IPerson
    {
        #region IPerson
        public string FirstName { get; set; }
        public string LastName { get ; set; }
        #endregion
        public int Pin { get; set; }
        public string LogIn { get; set; }
        public string Extension { get; set; }

        List<Notification> Notifications { get; set; }

        public int TeamLeaderId { get; set; }
        public TeamLeader TeamLeader { get; set; }
    }
}
