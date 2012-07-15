using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.MapEditor
{
    abstract class Command
    {
        public abstract void Undo();
        public abstract void Redo();
    }
}
