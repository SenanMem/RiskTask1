using Arch.EntityFrameworkCore.UnitOfWork;
using DAL;
using Domains;
using Microsoft.EntityFrameworkCore;
//using DataAccessLayer;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiskTask1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowVM : BaseVM
    {
        public BaseVM CurrentVM { get; set; }

        private LogInVM _logInVM { get; set; }
        private TeamLeaderVM _teamLeaderVM { get; set; }
        private WorkerVM _workerVM { get; set; }

        private AppDbContext _appDbContext { get; set; }
        private UnitOfWork<AppDbContext> _unitOfWork { get; set; }

        public MainWindowVM()
        {
            _appDbContext = new AppDbContext(new DbContextOptions<AppDbContext>());
            _unitOfWork = new UnitOfWork<AppDbContext>(_appDbContext);

            _logInVM = new LogInVM(_unitOfWork);

            _logInVM.LoginEvent += _loginVmLoginEvent;

            CurrentVM = _logInVM;
        }

        private void _loginVmLoginEvent(bool arg1, User arg2)
        {
            if (arg1)
            {
                var teamLeader = _unitOfWork.DbContext.TeamLeaders.Include(x => x.Workers).Where(z => z.Id == arg2.Id).FirstOrDefault();
                _teamLeaderVM = new TeamLeaderVM(_unitOfWork, teamLeader);
                CurrentVM = _teamLeaderVM;
            }
            else
            {
                _workerVM = new WorkerVM(_unitOfWork, arg2 as Worker);
                CurrentVM = _workerVM;
            }
        }
    }
}
