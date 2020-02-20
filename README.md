# Dashboard and report machines stopping time by cause
#### Donalam Project
## Description
The project consists in 3 parts: 
* OPC Server (Create new PLC to read signals) 
* Dashboard: to see  live the status of machines (working/ stopped and period in time, chart of reasons for stopping in percent) 
* Reports: register all breackdown time and reason of stopeges for each Plc, and send automatically a mail dailly with report. Also the posibility to extract in excel data for a desired period

# Features
* Background Service
* Opc Server (Add a new PLCs and signals for each of them)
* Reading signals from PLC
* Save/ Retrieve data from SQL Server in excel
* Send mail automatically
* View components in ASP.NET Core
* Partial View
* JavaScript - Use AJAX Calls
* JavaSCript - Pass parameters via JSON from server to view
* Datatable - to sort, search, filter, pagination data in view
* Chartjs - for charts
* Asp.Net Core App

# Nuget Sources
* - S7netplus - to write to Siemens Plc
* - EPPlus - to read/ write excel files
* - EntityFrameworkCore