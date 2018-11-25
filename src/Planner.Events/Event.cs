using Planner.Events;

namespace Planner.Calendar
{
    public class Event
    {
        public Event(RecurringEvent parent)
        {
            Name = parent.Name;
        }

        public string Name { get; private set; }

        public RecurringEvent Parent { get; }

        Day StartDay { get; }
        Day EndDay { get; }


    }
}
