using System.Collections.Generic;
using BLL.Services.Memento;

namespace BLL.Services.HelperClasses
{
    public class StatsHistory // Caretaker
    {
        public StatsHistory()
        {
            History = new Stack<StatsMemento>();
        }
        
        public Stack<StatsMemento> History { get; private set; }
    }
}