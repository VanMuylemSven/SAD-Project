using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using UIKit;

namespace Project.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (System.Exception ex)
            {
                var properties = new Dictionary<string, string> {
                    { "File", "main.cs" }
                };
                Crashes.TrackError(ex, properties);
                throw ex;
            }
            
        }
    }
}