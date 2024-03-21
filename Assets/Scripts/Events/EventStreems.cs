using SimpleEventBus;
using SimpleEventBus.Interfaces;

namespace Events
{
    public static class EventStreams
    {
        public static IEventBus Global { get; } = new EventBus();
    }
}