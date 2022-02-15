using Arch.EntityFrameworkCore.UnitOfWork;
using DAL;
using Domains;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Timers;
using RiskTask1.SubEvent;

namespace RiskTask1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TeamLeaderVM : BaseVM
    {
        private readonly UnitOfWork<AppDbContext> _unitOfWork;

        public TeamLeader TeamLeader { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public Comment SelectedComment { get; set; } = new Comment();

        public ICommand CreateCommentCommand { get; set; }



        private Timer Timer;

        public TeamLeaderVM(UnitOfWork<AppDbContext> unitOfWork, TeamLeader teamLeader)
        {
            TeamLeader = teamLeader;
            _unitOfWork = unitOfWork;
            GetEvenetAggregator.EventAggregator.GetEvent<CreateWorkerSubEvent>().Subscribe(workerSubscribe);

            Timer = new Timer();
            Timer.Elapsed += Timer_Elapsed;
            Timer.Interval = 200;
            Timer.Start();
        }

        private void workerSubscribe(Worker obj)
        {
            obj.TeamLeader = TeamLeader;
            obj.TeamLeaderId = TeamLeader.Id;
            Timer.Stop();
            _unitOfWork.DbContext.Workers.Add(obj);
            _unitOfWork.SaveChanges();
            Timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Load();
            var a = Comments;
        }

        public void PublishComment(Comment obj)
        {
            SelectedComment.CommentText = obj.CommentText;
            SelectedComment.IsAccepted = obj.IsAccepted;
            _unitOfWork.DbContext.Comments.Update(SelectedComment);
            _unitOfWork.SaveChanges();
            Load();
        }

        private void Load()
        {
            var temp = new List<Comment>();
            using (var trx = _unitOfWork.DbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in TeamLeader.Workers)
                    {
                        try
                        {
                            temp.AddRange(_unitOfWork.DbContext.Comments.Include(x => x.Notification).Where(z => z.CommentText == null && z.Notification.WorkerId == item.Id).ToList());
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            Comments = temp;
        }


     
    }
}
