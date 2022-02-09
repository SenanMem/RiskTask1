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
    /// Interaction logic for CreateCommentView.xaml
    /// </summary>
    public partial class CreateCommentView : Window
    {
        public CreateCommentVM WindowVM { get; set; }
        public CreateCommentView()
        {
            WindowVM = new CreateCommentVM();
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

        }
    }
}
