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
    /// Interaction logic for TeamLeaderView.xaml
    /// </summary>
    public partial class TeamLeaderView : UserControl
    {
        public List<string> CheckBoxData { get; set; } = new List<string>() { "Accepted", "Not Accepted" };
        public TeamLeaderVM WindowVM { get; set; }

        public TeamLeaderView()
        {

            InitializeComponent();
        }

        private void btnCreateComment_Click(object sender, RoutedEventArgs e)
        {
            WindowVM = this.DataContext as TeamLeaderVM;
            var newWindow = new CreateCommentView();
            var CreateCommentVM = newWindow.DataContext as CreateCommentVM;
            CreateCommentVM.SubscribeComment += WindowVM.PublishComment;
            newWindow.ShowDialog();
        }

        private void btnCreateWorker_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new CreateWorkerView();
            newWindow.ShowDialog();
        }

    }
}
