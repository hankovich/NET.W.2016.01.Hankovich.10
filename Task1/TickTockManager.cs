﻿using System;
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

        public int LastWaitingTime { get; private set; }
    }

    public class TickTock
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<TickTockEventsArgs> RockAroundTheClock = delegate { };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnTick(object sender, TickTockEventsArgs e)
        {
            RockAroundTheClock?.Invoke(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="milliseconds"></param>
        public void SetTheFinalCountDown(int milliseconds)
        {
            if (milliseconds < 0)
                throw new ArgumentException($"{nameof(milliseconds)} < 0");
            Thread.Sleep(milliseconds);
            OnTick(this, new TickTockEventsArgs(milliseconds));
        }
    }
}
