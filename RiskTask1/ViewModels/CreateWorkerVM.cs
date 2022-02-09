using Domains;
using GalaSoft.MvvmLight.CommandWpf;
using Prism.Events;
using PropertyChanged;
using RiskTask1.SubEvent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace RiskTask1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CreateWorkerVM : BaseVM
    {
        public Worker NewWorker { get; private set; }

        public ICommand AddWorkerCommand { get; set; }

        public event Action<object, RoutedEventArgs> CloseEvent;

        public IEventAggregator GetEventAggregator { get; set; }


        public CreateWorkerVM()
        {
            NewWorker = new Worker();
            AddWorkerCommand = new RelayCommand(AddWorkerMethod);

            GetEvenetAggregator.EventAggregator.GetEvent<CreateWorkerPassword>().Subscribe(passwordSbuscribe);

        }

        private void passwordSbuscribe(string obj)
        {
            NewWorker.Password = obj;
        }

        private void AddWorkerMethod()
        {
            if (!string.IsNullOrEmpty(NewWorker.Password))
            {
                GetEvenetAggregator.EventAggregator.GetEvent<CreateWorkerSubEvent>().Publish(NewWorker);
                CloseEvent?.Invoke(new object(), new RoutedEventArgs());
            }
        }
    }
}
