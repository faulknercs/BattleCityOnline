using System;

namespace BattleCity.GameLib.Events
{
    /// <summary>
    ///  Represents arguments of PlayerKeyEvent
    /// </summary>
    public class PlayerKeyEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isReleased">Value, which indicating whether player released key or not</param>
        public PlayerKeyEventArgs(bool isReleased)
        {
            KeyReleased = isReleased;
        }

        /// <summary>
        /// Gets a value indicating whether player released key or not
        /// </summary>
        public bool KeyReleased { get; private set; }
    }
}
