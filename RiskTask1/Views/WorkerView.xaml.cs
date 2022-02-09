using Domains;
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
    /// Interaction logic for WorkerView.xaml
    /// </summary>
    public partial class WorkerView : UserControl
    {
        public WorkerVM WindowVM { get; set; }


        public WorkerView()
        {
            InitializeComponent();
        }

        private void btnCreateNotification_Click(object sender, RoutedEventArgs e)
        {
            WindowVM = this.DataContext as WorkerVM;
            var newWindow = new CreateNotificationView();
            var CreateNotificationVM = newWindow.DataContext as CreateNotificationVM;
            CreateNotificationVM.SubscribeNotification += WindowVM.PublishNotification;
            newWindow.ShowDialog();
        }
        
    }
}
