using Don_PlcDashboard_and_Reports.Data;
using Don_PlcDashboard_and_Reports.Models;
using Microsoft.AspNetCore.Components;
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
        CancellationTokenSource sourceToken;
        CancellationToken ct;

        public BackgroundWorkService(ILogger<BackgroundWorkService> logger, PlcService plcService, IServiceProvider services)
        {
            ReadingTimeInterval = 1000; //ms
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
        public int ReadingTimeInterval { get; set; } // Timp refresh in ms
        public override Task StartAsync(CancellationToken stoppingToken)
        {
            sourceToken = new CancellationTokenSource();
            ct = sourceToken.Token;
            // log
            _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "Start command for background service din Start Async BackgroundWorkService");

            Console.WriteLine($": Din Start async -  Cancelition token stare: {stoppingToken.IsCancellationRequested.ToString()}");
            //IsRunnungBackgroundService = true;
            return base.StartAsync(ct);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //log
            _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "Start din Execute Async BackgroundWorkService");
            Console.WriteLine($": Din Execute async -  Cancelition token stare: {stoppingToken.IsCancellationRequested.ToString()}");

            await DoWork(ct);
            //throw new NotImplementedException();
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                IsRunnungBackgroundService = true;
                LastTimeRunBackgroundWork = DateTime.Now;
                foreach (PlcModel plc in _plcService.ListPlcs)
                {
                    _plcService.RefreshTagValues(plc);
                    await _plcService.UpdateDbContextTagsValue(_context, plc.TagsList);
                }
                // log
                _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "Doing din while, din DoWork Async BackgroundWorkService");
                _logger.LogInformation("{LasttimeScan}", LastTimeRunBackgroundWork.ToString("dd.MM.yyyy hh:mm:ss"));

                await Task.Delay(ReadingTimeInterval, stoppingToken);
            }
            sourceToken.Dispose();
        }
        public override Task StopAsync(CancellationToken stoppingToken)
        {
            // log
            _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "Stop command for background service din Stop Async BackgroundWorkService");
            Console.WriteLine($": Din Stop async -  Cancelition token stare: {stoppingToken.IsCancellationRequested.ToString()}");
            IsRunnungBackgroundService = false;
            sourceToken.Cancel();
            return base.StopAsync(ct);
        }
        public override void Dispose()
        {
            _logger.LogInformation($"Background Service disposed at: {DateTime.Now.ToShortTimeString()}");
            base.Dispose();
        }
    }
}
