using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskTask1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseVM
    {
        public BaseVM CurrentVM { get; set; }//bu usercontrollerileri  deyismeydi 
    }
}
