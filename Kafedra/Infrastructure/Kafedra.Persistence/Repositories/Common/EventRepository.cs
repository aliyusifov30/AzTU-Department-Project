using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Domain.Entities;
using Kafedra.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Persistence.Repositories.Common
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(KafedraContext context) : base(context)
        {
        }
    }
}
