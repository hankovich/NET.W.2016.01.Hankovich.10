using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public class TickTockEventsArgs : EventArgs
    {
        public TickTockEventsArgs(int milliseconds)
        {
            LastWaitingTime = milliseconds;
        }

        /// <summary>
        /// Get last waiting time in milliseconds
        /// </summary>
        public int LastWaitingTime { get; private set; }
    }

    public class TickTock
    {
        /// <summary>
        /// Event that raises when time, setted in timer is out.
        /// </summary>
        public event EventHandler<TickTockEventsArgs> RockAroundTheClock = delegate { };

        /// <summary>
        /// Method raises <see cref="RockAroundTheClock"/> event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnTick(object sender, TickTockEventsArgs e)
        {
            RockAroundTheClock?.Invoke(sender, e);
        }

        /// <summary>
        /// Sets timeout for event.
        /// <exception cref="ArgumentException">Throws when milliseconds is negative</exception>
        /// <param name="milliseconds">Time in ms to set</param>
        /// </summary>
        public void SetTheFinalCountDown(int milliseconds)
        {
            if (milliseconds < 0)
                throw new ArgumentException($"{nameof(milliseconds)} < 0");
            Thread.Sleep(milliseconds);
            OnTick(this, new TickTockEventsArgs(milliseconds));
        }
    }
}
