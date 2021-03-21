using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.SendMail;
using Microsoft.Extensions.Configuration;

namespace Core.Aspect.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;
        private IConfiguration Configuration { get; }
        private ISendMail _entityEmail;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }
        //public PerformanceAspect(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    _entityEmail = Configuration.GetSection("Email").Get<EntitySendMail>();
        //    //2.ctor nasıl çalışıyor kontrol et configuration nasıl göndereceğiz ya da göndermeden direk yapabiliyormuyuz getsection
        //}


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                //SendMail.Send(_entityEmail.Email,_entityEmail.Password, "ADMIN", "muhammed_kocak26@hotmail.com", "Sistem Performansı",

                //     $"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalMilliseconds}",
                //     "smtp.gmail.com", 587);

                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
