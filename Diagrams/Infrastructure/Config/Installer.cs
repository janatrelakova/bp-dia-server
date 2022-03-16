using Autofac;
using DAL;
using Infrastructure.Diagrams;
using Infrastructure.Query;
using Infrastructure.Repositories;
using Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Config
{
    public class Installer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Query<>))
                .As(typeof(IQuery<>))
                .InstancePerDependency();

            builder.RegisterType<DiagramsUnitOfWorkProvider>()
                .AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<DiagramsUnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DiagramsDbContext>()
                .As<DbContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency();
        }

        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new Installer());
        }
    }
}
