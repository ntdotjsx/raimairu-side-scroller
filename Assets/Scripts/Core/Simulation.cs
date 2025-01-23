using System;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer.Core
{
    public static partial class Simulation
    {

        static HeapQueue<Event> eventQueue = new HeapQueue<Event>();
        static Dictionary<System.Type, Stack<Event>> eventPools = new Dictionary<System.Type, Stack<Event>>();

        static public T New<T>() where T : Event, new()
        {
            Stack<Event> pool;
            if (!eventPools.TryGetValue(typeof(T), out pool))
            {
                pool = new Stack<Event>(4);
                pool.Push(new T());
                eventPools[typeof(T)] = pool;
            }
            if (pool.Count > 0)
                return (T)pool.Pop();
            else
                return new T();
        }

        public static void Clear()
        {
            eventQueue.Clear();
        }
        static public T Schedule<T>(float tick = 0) where T : Event, new()
        {
            var ev = New<T>();
            ev.tick = Time.time + tick;
            eventQueue.Push(ev);
            return ev;
        }
        static public T Reschedule<T>(T ev, float tick) where T : Event, new()
        {
            ev.tick = Time.time + tick;
            eventQueue.Push(ev);
            return ev;
        }
        static public T GetModel<T>() where T : class, new()
        {
            return InstanceRegister<T>.instance;
        }
        static public void SetModel<T>(T instance) where T : class, new()
        {
            InstanceRegister<T>.instance = instance;
        }
        static public void DestroyModel<T>() where T : class, new()
        {
            InstanceRegister<T>.instance = null;
        }
        static public int Tick()
        {
            var time = Time.time;
            var executedEventCount = 0;
            while (eventQueue.Count > 0 && eventQueue.Peek().tick <= time)
            {
                var ev = eventQueue.Pop();
                var tick = ev.tick;
                ev.ExecuteEvent();
                if (ev.tick > tick)
                {
                    //event was rescheduled, so do not return it to the pool.
                }
                else
                {
                    // Debug.Log($"<color=green>{ev.tick} {ev.GetType().Name}</color>");
                    ev.Cleanup();
                    try
                    {
                        eventPools[ev.GetType()].Push(ev);
                    }
                    catch (KeyNotFoundException)
                    {
                        //This really should never happen inside a production build.
                        Debug.LogError($"No Pool for: {ev.GetType()}");
                    }
                }
                executedEventCount++;
            }
            return eventQueue.Count;
        }
    }
}


