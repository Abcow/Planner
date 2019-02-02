using System;

namespace Planner.Navigation
{
    public class NavigationModel
    {
        public NavigationModel(INavigationNode initialNode)
        {
            Show(initialNode);
        }

        public event Action CurrentNodeChanged;

        public INavigationNode CurrentNode { get; private set; }

        public void Show(INavigationNode node)
        {
            if (CurrentNode == node) return;

            CurrentNode.Dispose();
            CurrentNode = node;
            CurrentNodeChanged?.Invoke();
        }
    }
}
