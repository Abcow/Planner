using Planner.Navigation;

namespace Planner.Application.Pages
{
    public abstract class Page : PropertyChangedNotifier, INavigationNode
    {
        public virtual void Dispose()
        {
        }
    }
}
