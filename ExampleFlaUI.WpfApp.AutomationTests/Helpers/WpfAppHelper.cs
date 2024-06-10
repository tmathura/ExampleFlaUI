using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;

namespace ExampleFlaUI.WpfApp.AutomationTests.Helpers
{
    /// <summary>
    /// Helper class for interacting with the workbook scanner.
    /// </summary>
    public class WpfAppHelper
    {
        /// <summary>
        /// Gets or sets the ConditionFactory.
        /// </summary>
        private static readonly ConditionFactory ConditionFactory = new ConditionFactory(new UIA3PropertyLibrary());

        /// <summary>
        /// Gets or sets the main window.
        /// </summary>
        private readonly AutomationElement _mainWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfAppHelper"/> class.
        /// </summary>
        /// <param name="mainWindow">The main window.</param>
        public WpfAppHelper(AutomationElement mainWindow)
        {
            _mainWindow = mainWindow;
        }

        /// <summary>
        /// Gets the LoadingButton from the main window.
        /// </summary>
        /// <returns>The ScanButton, <see cref="Button"/>.</returns>
        public async Task<Button> GetLoadingButton()
        {
            var buttonAutomationElement = await AutomationHelper.WaitOnAutomationElement(_mainWindow, ConditionFactory.ByAutomationId("LoadingButton"));

            Assert.IsNotNull(buttonAutomationElement);

            var button = buttonAutomationElement.AsButton();

            return button;
        }

        /// <summary>
        /// Gets the UserGrid from the main window.
        /// </summary>
        /// <returns>The WorkbookGrid, <see cref="Grid"/>.</returns>
        public async Task<Grid> GetUserGrid()
        {
            var gridAutomationElement = await AutomationHelper.WaitOnAutomationElement(_mainWindow, ConditionFactory.ByAutomationId("UserGrid"));

            Assert.IsNotNull(gridAutomationElement);

            var grid = gridAutomationElement.AsGrid();
            return grid;
        }
    }
}
