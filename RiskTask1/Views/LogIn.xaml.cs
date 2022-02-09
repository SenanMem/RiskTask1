using Prism.Events;
using RiskTask1.SubEvent;
using RiskTask1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RiskTask1.Views
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : UserControl
    {

        public LogIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetEvenetAggregator.EventAggregator.GetEvent<PasswordCheckEvent>().Publish(PasswordBox.Password);
            //GetEventAggregator. .GetEvent<PasswordCheckEvent>().Publish(PasswordBox.Password);
        }
    }
}
