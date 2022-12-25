using FluentValidation;
using Kafedra.Application.Validations.EventValidations;
using Kafedra.Application.Validations.SubjectValidations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application
{
    public static class ServiceRegistration
    {

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<EventCreateDtoValidation>();
            services.AddValidatorsFromAssemblyContaining<SubjectCreateDtoValidation>();
        }

    }
}
