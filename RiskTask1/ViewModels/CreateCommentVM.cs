using Domains;
using GalaSoft.MvvmLight.CommandWpf;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace RiskTask1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CreateCommentVM : BaseVM
    {
        public Comment NewComment { get; private set; } = new Comment();

        public ICommand AddCommentCommand { get; set; }

        public event Action<object, RoutedEventArgs> CloseEvent;

        public event Action<Comment> SubscribeComment;

        public CreateCommentVM()
        {
            AddCommentCommand = new RelayCommand(AddCommentMethod);
        }

        private void AddCommentMethod()
        {
            SubscribeComment?.Invoke(NewComment);
            CloseEvent?.Invoke(new object(), new RoutedEventArgs());
        }
    }
}
