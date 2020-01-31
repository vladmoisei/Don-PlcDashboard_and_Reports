using Don_PlcDashboard_and_Reports.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Don_PlcDashboard_and_Reports.Services
{
    public class BackgroundWorkService : BackgroundService
    {
        private readonly ILogger<BackgroundWorkService> _logger;
        RaportareDbContext _context;
        PlcService _plcService;

        public BackgroundWorkService(ILogger<BackgroundWorkService> logger, PlcService plcService, IServiceProvider services)
        {
            _plcService = plcService; // Get PlcService
            _logger = logger; // Get Logger
            Services = services; // Get Service Provider
            var scope = Services.CreateScope(); // Create Scope
            _context = scope.ServiceProvider.GetRequiredService<RaportareDbContext>(); // Get DbContext
            // log
            _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "A pornit BackgroundWorkService din BackgroundWorkService Constructor");
        }

        public IServiceProvider Services { get; }
        public bool IsRunnungBackgroundService;
        public DateTime LastTimeRunBackgroundWork;
        public Task StartAsync(CancellationToken stoppingToken)
        {
            // log
            _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "Start command for background service din Start Async BackgroundWorkService");

            //IsRunnungBackgroundService = true;
            return Task.CompletedTask;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //log
            _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "Start din Execute Async BackgroundWorkService");

            while (!stoppingToken.IsCancellationRequested)
            {
                IsRunnungBackgroundService = true;
                LastTimeRunBackgroundWork = DateTime.Now;
                // log
                _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "Doing din while, din Execute Async BackgroundWorkService");
                _logger.LogInformation("{LasttimeScan}", LastTimeRunBackgroundWork.ToString("dd.MM.yyyy hh:mm:ss"));
                await Task.Delay(5000, stoppingToken);
            }
            //throw new NotImplementedException();
        }

        public async Task StopAsync(CancellationToken stoppingToken)
        {
            // log
            _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "Stop command for background servicedin Stop Async BackgroundWorkService");

            IsRunnungBackgroundService = false;
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            
        }
    }
}
