using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExxerProject.Web.Events.Handlers;
using ExxerProject.Web.Events.Interfaces;

namespace ExxerProject.Web.Events
{
    public class EventsFactory : IEventsFactory
    {
        [ThreadStatic]
        private List<Delegate> actions;

        public EventsFactory(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; set; }

        public void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }
            actions.Add(callback);
        }

        public void ClearCallbacks()
        {
            actions = null;
        }

        public void Raise<T>(T args) where T : IDomainEvent
        {
            //TODO How I can get only the handlers that handles "T"?!? At the moment I am getting all the handlers then passing
            // "T args" to each one and if the cast is succeed then the args are processed.
            foreach (var handler in this.GetHandlers())
            {
                handler.Handle(args);
            }

            if (actions != null)
            {
                foreach (var action in actions)
                {
                    if (action is Action<T>)
                    {
                        ((Action<T>)action)(args);
                    }
                }
            }
        }

        private IEnumerable<Handler> GetHandlers()
        {            
            var types = Assembly.Load(new AssemblyName("ExxerProject.Web")).GetTypes().Where(
                type => type.GetTypeInfo().BaseType != null &&
                !type.GetTypeInfo().IsAbstract &&
                typeof(Handler).IsAssignableFrom(type));

            var handlers = new List<Handler>();

            foreach (var type in types)
            {
                handlers.Add((Handler)Activator.CreateInstance(type, this.ServiceProvider));
            }

            return handlers;
        }
    }
}
