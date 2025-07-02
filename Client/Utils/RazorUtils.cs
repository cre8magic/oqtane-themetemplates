using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Oqtane.Modules;

namespace [Owner].Theme.[Theme].Utils;
internal class RazorUtils
{
    public static void RunAndIgnoreErrors(Action action)
    {
        try
        {
            action();
        }
        catch 
        {
            /* ignore */
        }
    }

    public static async Task RunAsyncAndLogErrors(Func<Task> action, ModuleBase component, ModuleBase.Logger logger, [CallerMemberName] string? caller = null)
    {
        try
        {
            await action();
        }
        catch (Exception ex)
        {
            await logger.LogError(ex, $"Error {caller} {{Error}}", ex.Message);
            component.AddModuleMessage($"Error {caller}", MessageType.Error);
        }
    }
}
