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
using System.Windows.Shapes;

namespace RiskTask1.Views
{
    /// <summary>
    /// Interaction logic for CreateWorkerView.xaml
    /// </summary>
    public partial class CreateWorkerView : Window
    {
        public CreateWorkerVM WindowVM { get; set; }
        public CreateWorkerView()
        {
            WindowVM = new CreateWorkerVM();
            this.DataContext = WindowVM;

            WindowVM.CloseEvent += btnCancel_Click;

            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            if (tbPassword.Password == tbPasswordAgain.Password)
                GetEvenetAggregator.EventAggregator.GetEvent<CreateWorkerPassword>().Publish(tbPassword.Password);
        }
    }
}
