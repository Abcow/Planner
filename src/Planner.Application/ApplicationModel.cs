using Planner.Navigation;

namespace Planner.Application
{
    public class ApplicationViewModel : PropertyChangedNotifier
    {
        public NavigationModel Navigation {get; private set;}
    }
}
