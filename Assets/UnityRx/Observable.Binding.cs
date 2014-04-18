﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityRx
{
    public static partial class Observable
    {
        public static IConnectableObservable<T> Multicast<T>(this IObservable<T> source, ISubject<T> subject)
        {
            return new ConnectableObservable<T>(source, subject);
        }

        public static IConnectableObservable<T> Publish<T>(this IObservable<T> source)
        {
            return source.Multicast(new Subject<T>());
        }

        // not yet
        //public static IConnectableObservable<T> Publish<T>(this IObservable<T> source, T initialValue)
        //{
        //    return source.Multicast(new BehaviourSubject<T>(initialValue));
        //}

        public static IConnectableObservable<T> PublishLast<T>(this IObservable<T> source)
        {
            return source.Multicast(new AsyncSubject<T>());
        }

        // not yet
        //public static IConnectableObservable<T> Replay<T>(this IObservable<T> source)
        //{
        //    return source.Multicast(new ReplaySubject<T>());
        //}
    }
}