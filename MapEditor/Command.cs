using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCity.MapEditor
{
    /// <summary>
    /// Interface of editor's commands (Add block, remove, etc.)
    /// </summary>
    interface Command
    {
        /// <summary>
        /// Reverts a changes.
        /// </summary>
        void Undo();
        /// <summary>
        /// Applies a changes.
        /// </summary>
        void Redo();
    }
}
