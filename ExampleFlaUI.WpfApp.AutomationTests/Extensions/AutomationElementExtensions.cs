using FlaUI.Core.AutomationElements;

namespace ExampleFlaUI.WpfApp.AutomationTests.Extensions
{
    public static class AutomationElementExtensions
    {
        /// <summary>
        /// Performs a double click on the <paramref name="automationElement"/> after a specified delay.
        /// </summary>
        /// <param name="automationElement">The <see cref="AutomationElement"/> to double click.</param>
        /// <param name="waitTimeout">The delay before performing the double click.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task DoubleClickAsync(this AutomationElement automationElement, TimeSpan waitTimeout)
        {
            await Task.Delay(waitTimeout);

            automationElement.DoubleClick();
        }
    }
}
