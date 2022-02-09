using Arch.EntityFrameworkCore.UnitOfWork;
using DAL;
using Domains;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiskTask1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WorkerVM : BaseVM
    {
        private readonly UnitOfWork<AppDbContext> _unitOfWork;

        public Worker Worker { get; set; }

        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public WorkerVM(UnitOfWork<AppDbContext> unitOfWork, Worker worker)
        {
            Worker = worker;
            _unitOfWork = unitOfWork;
            Load();
        }

        private void Load()
        {
            Notifications =   _unitOfWork.GetRepository<Notification>().GetAll().Where(x => x.WorkerId == Worker.Id).ToList();
        }

        public void PublishNotification(Notification obj)
        {
            var temp = new List<Notification>(Notifications);
            obj.Worker = Worker;
            obj.WorkerId = Worker.Id;
            temp.Add(obj);
            Notifications = temp;
            _unitOfWork.DbContext.Notifications.Add(obj);
            _unitOfWork.SaveChanges();

            var lastNotifaction = _unitOfWork.DbContext.Notifications.ToList().LastOrDefault();
            var newComment = new Comment() { Notification = lastNotifaction, NotificationId = lastNotifaction.Id };
            _unitOfWork.DbContext.Comments.Add(newComment);
            _unitOfWork.SaveChanges();
        }
    }
}
