using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace HLT.Web.RegisterAutofac
{
    public class RegisterAutofacForSingle
    {
        public static void RegisterAutofac()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //开启了Controller的依赖注入功能,这里使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //开启了Filter的依赖注入功能，为过滤器使用属性注入必须在容器创建之前调用RegisterFilterProvider方法，并将其传到AutofacDependencyResolver
            builder.RegisterFilterProvider();

            #region  IOC配置区域
            builder.RegisterType<Domain.Test>().As<Domain.ITest>().InstancePerDependency();
            #endregion

            var container = builder.Build();//创建一个容器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//容器注册到MVC中
        }
    }
}