using System.Diagnostics;
using FlaUI.Core;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIAutomationTestProject;

[TestClass]
public class ExampleTestClass
{
    [Ignore]
    [TestMethod]
    public void VerifyWindowTitle()
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = @"VCS\VCS.exe",
            UseShellExecute = true
        };

        // Open application and get main window.
        var application = Application.Launch(processInfo);
        var mainWindow = application.GetMainWindow(new UIA3Automation());
        Wait.UntilInputIsProcessed(TimeSpan.FromSeconds(2));

        // Verify window title is as expected.
        const string EXPECTED_TITLE = "Extron VCS - Quantum Ultra / Quantum Ultra II - NewProject <administrator>";
        Assert.AreEqual(EXPECTED_TITLE, mainWindow.Title);

        // Create images directory and take screenshot
        var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent!.Parent!.Parent!.Parent!;
        Wait.UntilInputIsProcessed(TimeSpan.FromSeconds(1));
        Directory.CreateDirectory(Path.Combine(dir.FullName, "Images"));
        mainWindow.CaptureToFile($"{dir.FullName}/Images/MainWindow.png");
        Wait.UntilInputIsProcessed(TimeSpan.FromSeconds(1));

        // Close the application.
        application.Close();
    }

    [TestMethod]
    [TestCategory("Quantum")]
    public void MyQuantumTest()
    {
        Console.WriteLine("Running the Quantum test!");
    }

    [TestMethod]
    [TestCategory("MGP")]
    public void MyMGPTest()
    {
        Console.WriteLine("Running the MGP test!");
    }
}
