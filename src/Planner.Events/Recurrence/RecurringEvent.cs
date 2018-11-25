namespace Planner.Events.Recurrence
{
    public class RecurringEvent
    {
        public RecurringEvent Parent { get; }

        public RecurringEvent CreateChild()
        {
            return new RecurringEvent(this);
        }

        private RecurringEvent(RecurringEvent parent)
        {
            Parent = parent;
        }

        public string Name { get; private set; }
    }
}
