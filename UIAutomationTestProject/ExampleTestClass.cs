using FlaUI.Core;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UIAutomationTestProject;

[TestClass]
public class ExampleTestClass
{
    [TestMethod]
    public void ExampleTestMethod()
    {
        // Open application and get main window.
        var application = Application.Launch("notepad.exe");
        var mainWindow = application.GetMainWindow(new UIA3Automation());

        // Find text editor and get value pattern.
        var textEditor = mainWindow.FindFirstDescendant(factory => factory.ByAutomationId("15"));
        var pattern = textEditor.Patterns.Value.Pattern;

        // Set value of text editor.
        pattern.SetValue("testing");

        // Create images directory and take screenshot
        var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent!.Parent!.Parent!.Parent!;
        Wait.UntilInputIsProcessed(TimeSpan.FromSeconds(2));
        Directory.CreateDirectory(Path.Combine(dir.FullName, "Images"));
        textEditor.CaptureToFile($"{dir.FullName}/Images/TempImage.png");
        Wait.UntilInputIsProcessed(TimeSpan.FromSeconds(2));

        // Verify text content is as expected.
        Assert.AreEqual("testing", pattern.Value);

        // Close application.
        application.Close();
    }

    [TestMethod]
    public void ScreenshotDesktop()
    {
        var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent!.Parent!.Parent!.Parent!;
        Wait.UntilInputIsProcessed(TimeSpan.FromSeconds(2));
        Directory.CreateDirectory(Path.Combine(dir.FullName, "Images"));
        new UIA3Automation().GetDesktop().CaptureToFile($"{dir.FullName}/Images/DesktopImage.png");
        Wait.UntilInputIsProcessed(TimeSpan.FromSeconds(2));
    }
}
