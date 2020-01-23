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
    public class PlcService : IPlcService
    {
        public int Valoare { get; set; } = 1;// Valoare de proba comunicatie Blazor
        // List of Plcs
        public List<PlcModel> ListPlcs;
        // DbContext
        private readonly RaportareDbContext _context;
        // Logger
        private readonly ILogger<PlcService> _logger;
        // Constructor
        public PlcService(ILogger<PlcService> logger, RaportareDbContext context)
        {
            ListPlcs = new List<PlcModel>();
            _context = context;
            _logger = logger;
            _logger.LogInformation("{data}<=>{Messege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "A pornit PlcService din PlcService Constructor");
        }

        // Get New Plc object by PlcModel
        public Plc GetNewPlc(PlcModel plcModel)
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
                    }
                    else return;
                }, _cancelTasks.Token);
                if (!task.Wait(TimeSpan.FromSeconds(0.5))) _cancelTasks.Cancel(); // Daca nu mai raspundein timp util se opreste Task
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

        // Get PlcModel by name from DbContext
        public PlcModel GetPlcModelFromDbByName(string plcName)
        {
            if (plcName == null)
            {
                return null;
            }
            var plcModel = _context.Plcs
                .FirstOrDefault(m => m.Name == plcName);
            _logger.LogInformation("{data}<=>{Messege} PlcName:{name}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "S-a gasit PlcModel from Db with name", plcName);
            return plcModel;
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
        // Add PlcModel to ListPlc by Plc name
        public void AddPlcModelToListPlcs(string plcName)
        {
            if (plcName == null)
            {
                return;
            }
            // Check if Plc Name is already in ListPlcs
            if (!IsPlcNameInListPlcs(plcName))
            {
                PlcModel plcModel = GetPlcModelFromDbByName(plcName);
                plcModel.PlcObject = GetNewPlc(plcModel);
                ListPlcs.Add(plcModel);
                _logger.LogInformation("{data}<=>{Messege} PlcName:{name}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "S-a gasit adaugat PlcModel in ListPlcs with name", plcName);
            }

        }
        public string ClickTestare()
        {
            _logger.LogInformation("{data} {exMessege}", DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"), "Click din View component");
            return "A fost apasat click din View";
        }

    }
}
