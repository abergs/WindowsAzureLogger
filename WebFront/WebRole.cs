using System;
using System.Globalization;
using System.Threading;
using Microsoft.WindowsAzure.ServiceRuntime;
using TableStorageLogger;

namespace WebFront
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            Logger.Add("WebFront", "Start", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
            return base.OnStart();
        }
        
        public override void OnStop()
        {
            Logger.Add("WebFront", "Stop", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
            Thread.Sleep(TimeSpan.FromMinutes(4));
            base.OnStop();
        }
    }
}
