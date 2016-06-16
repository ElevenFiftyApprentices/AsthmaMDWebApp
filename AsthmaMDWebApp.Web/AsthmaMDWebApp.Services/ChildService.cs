using AsthmaMDWebApp.Data;
using AsthmaMDWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsthmaMDWebApp.Services
{
    public class ChildService
    {

        private readonly Guid _userId;

        public ChildService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ChildViewModel> GetChildren()
        {
            using (var ctx = new AsthmaDbContext())
            {
                return
                ctx
                    .Children
                    .Where(e => e.UserId == _userId)
                    .Select(e => new ChildViewModel
                     {
                         ChildId = e.ChildId,
                         ChildName = e.ChildName,
                         ChildAge = e.ChildAge,
                         ChildHeight = e.ChildHeight,
                         ChildPeakFlowMeter = e.ChildPeakFlowMeter,
                         ChildFEV1 = e.ChildFEV1
                     })
                    .ToList();
            }
        }

        public ChildViewModel GetChildById(int childId)
        {
            ChildEntity entity;
            using (var ctx = new AsthmaDbContext())
            {
                entity =
                    ctx
                    .Children
                    .SingleOrDefault(e => e.UserId == _userId && e.ChildId == childId);
            }
            return
                new ChildViewModel
                {
                    ChildId = entity.ChildId,
                    ChildName = entity.ChildName,
                    ChildAge = entity.ChildAge,
                    ChildHeight = entity.ChildHeight,
                    ChildFEV1 = entity.ChildFEV1,
                    ChildPeakFlowMeter = entity.ChildPeakFlowMeter,
                    CreatedUtc = entity.CreatedUtc,
                    Logs = entity.Logs,
                    Alerts = entity.Alerts,
                    Gender = (ChildViewModel.GenderType)entity.Gender
                };
        }

        public bool CreateChild(ChildViewModel vm)
        {
            using (var ctx = new AsthmaDbContext())
            {
                var entity =
                    new ChildEntity
                    {
                        ChildId = vm.ChildId,
                        ChildName = vm.ChildName,
                        ChildAge = vm.ChildAge,
                        ChildHeight = vm.ChildHeight,
                        ChildFEV1 = vm.ChildFEV1,
                        ChildPeakFlowMeter = vm.ChildPeakFlowMeter,
                        CreatedUtc = DateTimeOffset.UtcNow
                    };
                ctx.Children.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}