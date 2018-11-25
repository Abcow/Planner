using System;
using System.Collections.Generic;

namespace Planner.Application
{
    public class Iteration
    {
        private IterationScheme _scheme;

        public Iteration(IterationScheme scheme, Event previousPlanning, System.DateTime start, IEnumerable<RecurringEvent> recurringEvents)
        {
            _scheme = scheme;
            PreviousPlanning = previousPlanning;
            Start = start;
            RecurringEvents = recurringEvents;
            NextPlanning = new Event();
        }

        public string Name { get; private set; }
        public int ID { get; private set; }
        public Event PreviousPlanning { get; }
        public Event NextPlanning { get; }
        public DateTime Start { get; }
        public IEnumerable<RecurringEvent> RecurringEvents { get; private set; }
        public IEnumerable<Event> Events { get; private set; }
    }
}
