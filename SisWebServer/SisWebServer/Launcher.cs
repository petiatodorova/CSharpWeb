﻿namespace SisWebServer
{
    using Server.Contracts;
    using Server.Routing;
    using Application;
    using Server;

    class Launcher : IRunnable
    {
        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            var mainApplication = new MainApplication();
            var appRouteConfig = new AppRouteConfig();
            mainApplication.Configure(appRouteConfig);
            var webServer = new WebServer(1337, appRouteConfig);

            webServer.Run();
        }
    }
}
