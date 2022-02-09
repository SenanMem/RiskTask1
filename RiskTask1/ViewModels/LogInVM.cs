using Arch.EntityFrameworkCore.UnitOfWork;
using DAL;
using Domains;
using GalaSoft.MvvmLight.Command;
using Prism.Events;
using PropertyChanged;
using RiskTask1.SubEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RiskTask1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LogInVM : BaseVM
    {
        private readonly IRepository<User> _repoUser;
        
        private readonly UnitOfWork<AppDbContext> _unitOfWork;


        public User User { get; set; }
        
        public ICommand LoginCommand { get; set; }

        public IEventAggregator GetEventAggregator { get; set; }

        public event Action<bool, User> LoginEvent;



        public LogInVM(UnitOfWork<AppDbContext> unitOfWork)
        {
            User = new User();
            _unitOfWork = unitOfWork;
            _repoUser = _unitOfWork.GetRepository<User>();
            LoginCommand = new RelayCommand(loginMethod);
            GetEvenetAggregator.EventAggregator.GetEvent<PasswordCheckEvent>().Subscribe(passwordSbuscribe);
        }

        private  void loginMethod()
        {
            //Worker worker = new Worker() 
            //{ 
            //   FirstName="Senan",
            //   LastName="Memmedov",
            //   UserName = "WR",
            //   Password="1",
            //};
            //TeamLeader teamLeader = new TeamLeader()
            //{
            //    FirstName = "Anar",
            //    LastName = "Anarov",
            //    TeamName = ".Net",
            //    UserName = "TM",
            //    Password = "1",
            //    Workers = new List<Worker>() {worker},
            //};
            //_unitOfWork.DbContext.TeamLeaders.Add(teamLeader);
            //_unitOfWork.DbContext.SaveChanges();

            var user = _repoUser.GetAll().FirstOrDefault(x => x.UserName == User.UserName && x.Password == User.Password);
            if (user is not null)
            {
                if (user is TeamLeader)
                {
                    LoginEvent?.Invoke(true, user);
                }
                else if (user is User)
                {
                    LoginEvent?.Invoke(false, user);
                }
            }

        }
        private void passwordSbuscribe(string password)
        {
            User.Password = password;
        }
    }
}

