using Kafedra.Application.Interfaces.Repostories.Common;
using Kafedra.Domain;
using Kafedra.Domain.Identities;
using Kafedra.Persistence.Configurations;
using Kafedra.Persistence.Contexts;
using Kafedra.Persistence.Repositories.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

namespace Kafedra.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<KafedraContext>(opt =>
            {
                opt.UseSqlServer(ServiceConfiguration.ConnectionString());
            }).AddIdentity<AppUser, IdentityRole>(x =>
            {
                x.Password.RequiredLength = 5;
              //  x.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
                x.SignIn.RequireConfirmedEmail = true;
                x.User.RequireUniqueEmail = true;
                //todo we will change here or add somethings
            }).
            AddEntityFrameworkStores<KafedraContext>().AddDefaultTokenProviders();
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<ICurriculumRepository, CurriculumRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDissertationRepository, DissertationRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IPartnerRepository, PartnersRepository>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ISyllabusRepository, SyllabusRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();

        }
    }
}
