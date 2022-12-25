using FluentValidation;
using Kafedra.Application.DTOs.EventDTOs;
using Kafedra.Application.DTOs.SubjectDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.Validations.SubjectValidations
{
    public class SubjectCreateDtoValidation : AbstractValidator<SubjectCreateDto>
    {
        public SubjectCreateDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty()
                .MinimumLength(3).MaximumLength(100);
        }

    }
}
