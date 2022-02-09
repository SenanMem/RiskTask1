using Arch.EntityFrameworkCore.UnitOfWork;
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
    public class CreateNotificationVM : BaseVM
    {
        public Notification NewNotification { get;private set; }

        public ICommand AddNotificationCommand { get; set; }

        public event Action<object, RoutedEventArgs> CloseEvent;

        public event Action<Notification> SubscribeNotification;

        public CreateNotificationVM()
        {
            NewNotification = new Notification();
            AddNotificationCommand = new RelayCommand(AddNotificationMethod);
        }

        private void AddNotificationMethod()
        {
            SubscribeNotification?.Invoke(NewNotification);
            CloseEvent?.Invoke(new object(), new RoutedEventArgs());
        }
    }
}
