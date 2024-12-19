using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace RevitPlague;

public class EntryApplication : IExternalApplication
{
    public Result OnStartup(UIControlledApplication application)
    {
        #region Ribbon Panel
        
        RibbonPanel ribbonPanel = application.CreateRibbonPanel("Revit Plague");
        string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
        PushButtonData buttonData = new PushButtonData("cmdHelloWorld",
            "RevitPlague", thisAssemblyPath, "RevitPlague.Commands.EntryCommand");
        PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;
        pushButton.ToolTip = "Say hello to the entire world.";
        Uri uriImage = new Uri("pack://application:,,,/RevitPlague;component/Resources/icons/RibbonIcon32.png");
        BitmapImage largeImage = new BitmapImage(uriImage);
        pushButton.LargeImage = largeImage;
        
        #endregion
        
        Host.Start();

        return Result.Succeeded;
    }
    
    public Result OnShutdown(UIControlledApplication application)
    {
        Host.Stop();
        
        return Result.Succeeded;
    }
}