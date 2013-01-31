using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure.ServiceRuntime;
using TableStorageLogger;

namespace Worker
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.WriteLine("Worker entry point called", "Information");
            int index = 0;
            while (true)
            {
                index++;

                if (index%4 == 0)
                    Logger.Add("Worker", "Error", new Exception("Error details").ToString());

                Logger.Add("Worker", "Sleep", "for 1 seconds");
                Thread.Sleep(1000);
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            Logger.Add("Worker", "Start", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));

            return base.OnStart();
        }

        public override void OnStop()
        {
            Logger.Add("Worker", "Stop", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
            Logger.Persist(true);
            //This is a delay to allow the service to stop gracefully.
            Thread.Sleep(TimeSpan.FromMinutes(3));
            base.OnStop();
        }
    }
}
