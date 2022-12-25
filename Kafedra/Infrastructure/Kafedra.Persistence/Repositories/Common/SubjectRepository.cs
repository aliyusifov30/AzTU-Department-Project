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
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(KafedraContext context) : base(context)
        {
        }
    }
}
