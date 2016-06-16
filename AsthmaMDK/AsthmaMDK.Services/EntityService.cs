using AsthmaMDK.Models;
using AsthmaMDK.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsthmaMDK.Services
{
    public class EntityService
    {
        public bool CreateChildInfo(EntityViewModel vm)
        {
            using (var ctx = new AsthmaMDKDbContext())
            {
                var entity = new Entity
                {
                    EntityId = vm.EntityId,
                    ChildName = vm.ChildName,
                    PFMReading = vm.PFMReading,
                    Attack = vm.Attack,
                    FeelingScore = vm.FeelingScore,
                    Frequency = vm.Frequency

                };
                return ctx.SaveChanges() == 1;
            }


        }

        
    }
}
