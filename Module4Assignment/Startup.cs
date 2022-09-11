using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4Assignment
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // register services
            // https://www.c-sharpcorner.com/article/understanding-addtransient-vs-addscoped-vs-addsingleton-in-asp-net-core/
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddFile("app.log");
            });

            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<IDataDao, DatabaseDao>();
        }
    }
}
