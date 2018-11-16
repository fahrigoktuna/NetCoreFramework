using NetCoreFramework.Domain.Events.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Domain.EventHandlers.Interface
{
    public interface IDomainHandler<T> where T : IDomainEvent
    {
        void Handle(T @event);
    }
}
