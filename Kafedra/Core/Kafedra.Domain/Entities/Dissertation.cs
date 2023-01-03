using Kafedra.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Domain.Entities
{
    public class Dissertation:BaseEntity
    {
        public string Name { get; set; }
        public bool FromBachalavr { get; set; }
        public ICollection<UserDissertation> UserDissertations { get; set; }

    }
}
