using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NetCoreFramework.Domain.EventHandlers.Interface;
using NetCoreFramework.Domain.EventHandlers.Students;
using NetCoreFramework.Domain.Events.Interface;
using NetCoreFramework.Domain.Events.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Infrastructure.Helpers.Events
{
    public  class DomainEvents
    {
         static readonly IWindsorContainer _windsorContainer;

         static DomainEvents()
        {
            _windsorContainer = new WindsorContainer();
            _windsorContainer.Register(Component.For<IDomainHandler<StudentCreated>>().ImplementedBy<StudentCreatedDefaultHandler>());
            _windsorContainer.Register(Component.For<IDomainHandler<StudentCreated>>().ImplementedBy<StudentCreatedEmailHandler>());
        }

        public static void Raise<T>(T @event) where T : IDomainEvent
        {
            foreach (var handler in _windsorContainer.ResolveAll<IDomainHandler<T>>())
            {
                handler.Handle(@event);
            }
        }

    }
}
