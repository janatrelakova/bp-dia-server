using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using BAL.Services.Diagram;
using BAL.Services.User;
using BAL.Services.UserDiagram;
using Models.Entities;

namespace BAL.Config
{
    public class Installer : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var businessLayer = Assembly.GetExecutingAssembly();
            builder.RegisterModule(new Infrastructure.Config.Installer());


            builder.RegisterAssemblyTypes(businessLayer)
                .Where(facade => facade.Name.EndsWith("Facade"))
                .As(t => t.GetInterface("I" + t.Name))
                .InstancePerDependency();


            builder.RegisterType(typeof(UserService))
                .As(typeof(IUserService))
                .InstancePerDependency();

            builder.RegisterType(typeof(DiagramService))
                .As(typeof(IDiagramService))
                .InstancePerDependency();

            builder.RegisterType(typeof(NewDiagramService))
                .As(typeof(INewDiagramService))
                .InstancePerDependency();


            builder.RegisterType(typeof(UpdateDiagramService))
                .As(typeof(IUpdateDiagramService))
                .InstancePerDependency();

            builder.RegisterType(typeof(UserDiagramService))
                .As(typeof(IUserDiagramService))
                .InstancePerDependency();

            builder.RegisterType(typeof(ConnectDiagramService))
                .As(typeof(IConnectDiagramService))
                .InstancePerDependency();

            builder.RegisterInstance(new Mapper(new MapperConfiguration(cfg => { }))).As<IMapper>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.RegisterInstance(mapper);

        }
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new Infrastructure.Config.Installer());
        }
    }
}
