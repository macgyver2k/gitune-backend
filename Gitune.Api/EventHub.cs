using System;
using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Gitune.Api
{
    public interface IEventSource
    {
        IObservable<T> GetEvents<T>();
    }

    public interface IEventSink
    {
        void Publish<T>(T importState);
    }

    public class EventHub : IEventSource, IEventSink
    {
        private readonly Subject<object> subject = new Subject<object>();

        public IObservable<T> GetEvents<T>()
        {
            return subject.OfType<T>();
        }

        public void Publish<T>(T importState)
        {
            subject.OnNext(importState);
        }
    }
}