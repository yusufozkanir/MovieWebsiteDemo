using Autofac;
using MovieWebsiteDemo.Core.IUnitOfWork;
using MovieWebsiteDemo.Core.Repositories;
using MovieWebsiteDemo.Core.Services;
using MovieWebsiteDemo.Repository.DataAccess;
using MovieWebsiteDemo.Repository.DataAccess.Repositories;
using MovieWebsiteDemo.Repository.DataAccess.UnitOfWork;
using MovieWebsiteDemo.Service.Business.Mapping;
using MovieWebsiteDemo.Service.Business.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace MovieWebsiteDemo.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<,>)).As(typeof(IGenericService<,>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
