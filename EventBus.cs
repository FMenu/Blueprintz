using System.Collections;
using System.Collections.Generic;
using System.Timers;

namespace Blueprintz
{
    public abstract class EventBus
    {
        private Timer timer = new Timer(10);

        public EventBus()
        {
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) => Update();

        public abstract IEnumerator GetParams<T>();

        public virtual void Enable() { }
        public virtual void Update() { }
        public virtual void Disable() { }
        public virtual void Awake() { }

        public void Subscribe() => events.Add(this);
        public void BeginUpdate() => this.timer.Start();

        private static List<EventBus> events = new List<EventBus>();

        public static void FireEnable()
        {
            foreach (EventBus @event in events)
            {
                Program.logger.Debug("Enable!fired");
                @event.Enable();
            }
        }

        public static void FireDisable()
        {
            foreach (EventBus @event in events)
                @event.Disable();
        }

        public static void FireAwake()
        {
            foreach (EventBus @event in events)
                @event.Awake();
        }
    }
}
