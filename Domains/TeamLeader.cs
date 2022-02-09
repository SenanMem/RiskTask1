using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domains
{
    [AddINotifyPropertyChangedInterface]
    [Table("TeamLeaders")]
    public class TeamLeader : User, IPerson
    {
        #region IPerson
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #endregion
        public string TeamName { get; set; }

        public List<Worker> Workers { get; set; }
    }
}
