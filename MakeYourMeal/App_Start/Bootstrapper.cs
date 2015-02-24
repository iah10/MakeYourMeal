namespace MakeYourMeal
{
	public static class Bootstrapper
	{
		public static void Run()
		{
			SetAutofacContainer();
			//Configure AutoMapper
			//AutoMapperConfiguration.Configure();
		}
		private static void SetAutofacContainer()
		{
		 //   var builder = new ContainerBuilder();
		 //   builder.RegisterControllers(Assembly.GetExecutingAssembly());
		 //   builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
		 //   builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();
		 //   builder.RegisterAssemblyTypes(typeof(FoodItemRepository).Assembly)
		 //   .Where(t => t.Name.EndsWith("Repository"))
		 //   .AsImplementedInterfaces().InstancePerRequest();
		 //   builder.RegisterAssemblyTypes(typeof(FoodItemService).Assembly)
		 //  .Where(t => t.Name.EndsWith("Service"))
		 //  .AsImplementedInterfaces().InstancePerRequest();

		 ////   builder.RegisterAssemblyTypes(typeof(DefaultFormsAuthentication).Assembly)
		 ////.Where(t => t.Name.EndsWith("Authentication"))
		 ////.AsImplementedInterfaces().InstancePerHttpRequest();

		 //   builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MakeYourMealEntities())))
		 //	   .As<UserManager<ApplicationUser>>().InstancePerRequest();

		 //   builder.RegisterFilterProvider();
		 //   IContainer container = builder.Build();
		 //   DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}