using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.MapEditor
{
    /// <summary>
    /// Stack of applied commands. Allows use undo/redo.
    /// </summary>
    class CommandStack
    {
        public void Push(Command command)
        {

        }

        public void Undo()
        {

        }

        public void Redo()
        {
            
        }

        private IList<Command> commandStack = new List<Command>();
        private uint stackPointer;
        private uint stackCapacity;
    }
}
