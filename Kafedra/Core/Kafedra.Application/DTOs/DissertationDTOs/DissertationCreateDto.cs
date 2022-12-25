using Kafedra.Domain.Entities;
using Kafedra.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.DTOs.DissertationDTOs
{
    public class DissertationCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manager { get; set; }
        public string Author { get; set; }
        public string Topic { get; set; }

        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; }

        public decimal Point { get; set; }

        public DissertationType DissertationType { get; set; }

        public IFormFile File { get; set; }
    }
}
    