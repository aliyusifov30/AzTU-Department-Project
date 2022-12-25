using Kafedra.Domain.Entities.Common;
using Kafedra.Domain.Enums;
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
        public string Description { get; set; }
        public string Manager { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }

        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; }

        public DateTime PublicationYear { get; set; }
        public DateTime DefenseYear { get; set; }

        public decimal Point { get; set; }

        public DissertationType DissertationType { get; set; }

        public string FilePath { get; set; }

        public bool FromBachalavr { get; set; }
        //public ICollection<UserDissertation> UserDissertations { get; set; }
    }
}
