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
            using (var ctx = new AsthmaDbcontext())
            {
                var kids = ctx
                        .Children
                        .Where(e => e.UserId == _userId);
                return kids
                    .ctx
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
    }
}