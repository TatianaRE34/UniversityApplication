using StudentEnrollmentRepository.DatabaseAccess;
using StudentEnrollmentRepository.Repository;
using StudentEnrollmentRepository.DatabaseAccess;
using StudentEnrollmentRepository.Repository;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
namespace UniversityApplication
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });
        public static IUnityContainer Container => container.Value;
   

        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
                        RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ILoginRepository, LoginRepository>();
            container.RegisterType<IRegistrationRepository, RegistrationRepository>();
            container.RegisterType<ILoginDataAccess, LoginDataAccess>();
            container.RegisterType<IRegistrationDataAccess, RegistrationDataAccess>();
            container.RegisterType<IStudentRegRepository, StudentRegRepository>();
            container.RegisterType<IStudentRegistrationDataAccess, StudentRegistrationDataAccess>();
        }
    }
}