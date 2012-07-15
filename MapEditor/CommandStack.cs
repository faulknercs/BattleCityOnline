using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.MapEditor
{
    class CommandStack
    {
        public void Push(Command command)
        {

        }

        public void Undo()
        {

        }

        private Stack<Command> commands = new Stack<Command>();
    }
}
