using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Domain.Entities.Common
{
    public class BaseEntity: IThisisEntity
    {

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }= DateTime.UtcNow;
        public bool IsDeleted { get; set; }
    }
}
