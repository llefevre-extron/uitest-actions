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
        var application = Application.Launch("notepad.exe");
        var mainWindow = application.GetMainWindow(new UIA3Automation());

        var textEditor = mainWindow.FindFirstDescendant(factory => factory.ByAutomationId("15"));
        var pattern = textEditor.Patterns.Value.Pattern;

        pattern.SetValue("testing");
        Wait.UntilInputIsProcessed(TimeSpan.FromSeconds(1));
        Assert.AreEqual("testing", pattern.Value);

        application.Close();
    }
}
