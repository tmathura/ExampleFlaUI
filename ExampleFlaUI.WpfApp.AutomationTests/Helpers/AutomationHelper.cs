using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using System.Diagnostics;

namespace ExampleFlaUI.WpfApp.AutomationTests.Helpers
{
    /// <summary>
    /// Helper class for automation-related operations.
    /// </summary>
    public static class AutomationHelper
    {
        /// <summary>
        /// The default wait timeout.
        /// </summary>
        private static readonly TimeSpan DefaultWaitTimeout = TimeSpan.FromSeconds(5);

        /// <summary>
        /// The default delay.
        /// </summary>
        private static readonly TimeSpan DefaultDelay = TimeSpan.FromMilliseconds(100);

        /// <summary>
        /// Waits for an automation element to satisfy the specified property condition.
        /// </summary>
        /// <param name="automationElementToSearchOn">The automation element to search on.</param>
        /// <param name="propertyCondition">The property condition to satisfy.</param>
        /// <returns>The first automation element that satisfies the property condition, or null if not found.</returns>
        public static Task<AutomationElement> WaitOnAutomationElement(AutomationElement automationElementToSearchOn, PropertyCondition propertyCondition)
        {
            return WaitOnAutomationElement(automationElementToSearchOn, propertyCondition, DefaultWaitTimeout);
        }

        /// <summary>
        /// Waits for an automation element to satisfy the specified property condition within the specified timeout.
        /// </summary>
        /// <param name="automationElementToSearchOn">The automation element to search on.</param>
        /// <param name="propertyCondition">The property condition to satisfy.</param>
        /// <param name="waitTimeout">The timeout for waiting.</param>
        /// <returns>The first automation element that satisfies the property condition, or null if not found within the timeout.</returns>
        public static async Task<AutomationElement> WaitOnAutomationElement(AutomationElement automationElementToSearchOn, PropertyCondition propertyCondition, TimeSpan waitTimeout)
        {
            var stopwatch = Stopwatch.StartNew();
            var maxRunningTime = waitTimeout.TotalMilliseconds;

            while (stopwatch.ElapsedMilliseconds < maxRunningTime)
            {
                try
                {
                    var automationElement = automationElementToSearchOn.FindFirstDescendant(propertyCondition);
                    if (automationElement != null)
                    {
                        return automationElement;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }

                await Task.Delay(DefaultDelay);
            }

            return null;
        }

        /// <summary>
        /// Gets the modal windows of the specified main window.
        /// </summary>
        /// <param name="mainWindow">The main window.</param>
        /// <param name="delay">The time to wait before getting the modal windows.</param>
        /// <returns>An array of modal windows.</returns>
        public static async Task<Window[]> GetModalWindowsAfterDelay(Window mainWindow, TimeSpan delay)
        {
            await Task.Delay(delay);

            Window[] modalWindows = mainWindow.ModalWindows;

            return modalWindows;
        }
    }
}
