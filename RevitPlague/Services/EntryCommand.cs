using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitPlague.Services.Contracts;

namespace RevitPlague.Services;

[Transaction(TransactionMode.Manual)]
public class EntryCommand : IExternalCommand
{
    public virtual Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        try
        {
            var window = Host.GetService<IWindow>();
            window.ShowDialog();
            
            return Result.Succeeded;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return Result.Failed;
        }
    }
}