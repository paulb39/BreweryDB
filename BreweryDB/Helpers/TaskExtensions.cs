using System;
using System.Threading.Tasks;

namespace BreweryDB.Helpers
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Invokes a task without waiting and blocking current thread, 
        /// without returning result of a task.
        /// </summary>
        /// <param name="aTask">The task to ignore its waiter.</param>
        public static void IgnoreWait(this Task aTask)
        {
            // create an async action to suppress compiler warnings
            Action action = async () => { await aTask; };

            // just invoke the action, where general code will run synchronously, 
            // but tasks are spawned in normal way.
            action();
        }
    }
}
