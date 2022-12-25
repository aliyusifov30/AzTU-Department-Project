using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Domain.Entities;
using Kafedra.Persistence.Contexts;


namespace Kafedra.Persistence.Repositories.Common
{
    public class CurriculumRepository : GenericRepository<Curriculum>, ICurriculumRepository
    {
        public CurriculumRepository(KafedraContext context) : base(context)
        {
        }
    }
}
