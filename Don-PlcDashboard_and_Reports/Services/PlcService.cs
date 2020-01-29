using Don_PlcDashboard_and_Reports.Data;
using Don_PlcDashboard_and_Reports.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Don_PlcDashboard_and_Reports.Services
{
    public class PlcService
    {
        public int Valoare { get; set; } = 1;// Valoare de proba comunicatie Blazor
        // List of Plcs
        public List<PlcModel> ListPlcs;
        // List of Tags
        public List<TagModel> ListTags;
        // Logger
        private readonly ILogger<PlcService> _logger;

        // Constructor
        public PlcService(ILogger<PlcService> logger)
        {
            ListPlcs = new List<PlcModel>();
            ListTags = new List<TagModel>();
            _logger = logger;
            _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "A pornit PlcService din PlcService Constructor");
        }

        // Get New Plc object by PlcModel
        public Plc GetNewPlcFromPlcModel(PlcModel plcModel)
        {
            return new Plc(plcModel.CpuType, plcModel.Ip, plcModel.Rack, plcModel.Slot);
        }

        // Connect Plc
        public void ConnectPlc(Plc plc)
        {
            try
            {
                var _cancelTasks = new CancellationTokenSource();
                var task = Task.Run(() =>
                {
                    if (!plc.IsConnected)
                    {
                        plc.Open(); // Deschidere conexiune Plc
                        _logger.LogInformation("{data}<=>{Messege} IP: {ip}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "S-a deschis conexiune cu plc", plc.IP);
                    }
                    else return;
                }, _cancelTasks.Token);
                if (!task.Wait(TimeSpan.FromSeconds(0.5))) _cancelTasks.Cancel(); // Daca nu mai raspundein timp util se opreste Task
            }
            catch (PlcException exPlc)
            {
                _logger.LogError("{data} {exMessege} IP: {ip}",DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), exPlc.Message, plc.IP);
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError("{data} {exMessege} IP: {ip}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), ex.Message, plc.IP);
            }
            catch (Exception ex)
            {
                _logger.LogError("{data} {exMessege} IP: {ip}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), ex.Message, plc.IP);
            }
        }

        // Disconnect Plc
        public void DisconnectPlc(Plc plc)
        {
            try
            {
                var _cancelTasks = new CancellationTokenSource();
                var task = Task.Run(() =>
                {
                    if (plc.IsConnected)
                    {
                        plc.Close(); // Inchidere conexiune Plc
                        _logger.LogInformation("{data}<=>{Messege} IP: {ip}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "S-a inchis conexiune cu plc", plc.IP);
                    }
                    else return;
                }, _cancelTasks.Token);
                if (!task.Wait(TimeSpan.FromSeconds(0.5))) _cancelTasks.Cancel(); // Daca nu mai raspunde in timp util se opreste Task
            }
            catch (PlcException exPlc)
            {
                _logger.LogError("{data} {exMessege} IP: {ip}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), exPlc.Message, plc.IP);
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError("{data} {exMessege} IP: {ip}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), ex.Message, plc.IP);
            }
            catch (Exception ex)
            {
                _logger.LogError("{data} {exMessege} IP: {ip}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), ex.Message, plc.IP);
            }
        }

        // Initiate List of Plcs from DbContext
        public async Task InitializeListOfPlcAsync(RaportareDbContext context)
        {
            ListPlcs.Clear();
            IEnumerable<PlcModel> listPlcs = await context.Plcs.ToListAsync();
            IEnumerable<TagModel> tagList = await context.Tags.ToListAsync();
            // Add list of Plcs(with Plc object and TagList) from DbContext To PlcService PLCList
            foreach (var plcModel in listPlcs)
            {
                plcModel.PlcObject = GetNewPlcFromPlcModel(plcModel);
                plcModel.TagsList = tagList.Where(t => t.PlcModelID == plcModel.PlcModelID).ToList();
                ListPlcs.Add(plcModel);
            }
        }

        // Check if a plc name is already in listPlcs
        public bool IsPlcNameInListPlcs(string plcName)
        {
            if (plcName == null)
            {
                return false;
            }
            var plcModel = ListPlcs.FirstOrDefault(m => m.Name == plcName);
            if (plcModel == null)
            {
                return false;
            }
            _logger.LogInformation("{data}<=>{Messege} PlcName:{name}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "S-a gasit PlcModel in ListPlcs with name", plcName);
            return true;
        }

        public string ClickTestare()
        {
            _logger.LogInformation("{data} {exMessege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "Click din View component");
            return "A fost apasat click din View";
        }

    }
}
