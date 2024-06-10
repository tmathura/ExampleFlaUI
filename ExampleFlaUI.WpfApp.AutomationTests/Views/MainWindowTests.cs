using ExampleFlaUI.WpfApp.AutomationTests.Helpers;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;

namespace ExampleFlaUI.WpfApp.AutomationTests.Views;

[TestClass]
public class MainWindowTests
{
    private const string MainTestFolder = "TestData";

    /// <summary>
    /// Gets or sets the WorkbookScanner application.
    /// </summary>
    private static Application App { get; set; } = null!;

    /// <summary>
    /// Gets or sets the ConditionFactory.
    /// </summary>
    private static ConditionFactory ConditionFactory { get; set; } = null!;

    /// <summary>
    /// Gets or sets the WorkbookScanner application.
    /// </summary>
    private static Window MainWindow { get; set; } = null!;

    /// <summary>
    /// Gets or sets the WpfAppHelper.
    /// </summary>
    private static WpfAppHelper WpfAppHelper { get; set; } = null!;

    /// <summary>
    /// Initializes the test environment after before tests are executed.
    /// </summary>
    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        var mainTestFilesDirectory = Path.Combine(Directory.GetCurrentDirectory(), MainTestFolder);
        var appDirectory = Directory.GetCurrentDirectory().Replace(".AutomationTests", "");

        var appPath = Path.Combine(appDirectory, "ExampleFlaUI.WpfApp.exe");

        App = Application.Launch(appPath, mainTestFilesDirectory);

        var uia3Automation = new UIA3Automation();

        ConditionFactory = new ConditionFactory(new UIA3PropertyLibrary());

        MainWindow = App.GetMainWindow(uia3Automation);

        WpfAppHelper = new WpfAppHelper(MainWindow);
    }

    [TestMethod]
    public async Task MainWindow_Load()
    {
        // Arrange
        var button = await WpfAppHelper.GetLoadingButton();

        // Act
        button.Click();

        // Assert
        var grid = await WpfAppHelper.GetUserGrid();

        Assert.AreEqual(2, grid.Rows.Length);
    }

    /// <summary>
    /// Cleans up the test environment after all tests are executed.
    /// </summary>
    [ClassCleanup]
    public static void ClassCleanup()
    {
        App.Close();
    }
}