using CarServiceApp;
using CarServiceApp.Data;
using CarServiceApp.Data.CsvReader;
using CarServiceApp.Data.DummyData;
using CarServiceApp.Data.XmlHandler;
using CarServiceApp.DataProviders;
using CarServiceApp.Entities;
using CarServiceApp.Repositories;
using CarServiceApp.Services;
using CarServiceApp.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IEmployeesProvider, EmployeesProvider>();
services.AddSingleton<IRepository<Employee>, SqlRepository<Employee>>();
services.AddSingleton<IClientsProvider, ClientsProvider>();
services.AddSingleton<IRepository<Client>, SqlRepository<Client>>();
services.AddSingleton<IDummyDataHandler, DummyDataHandlerSql>();
services.AddSingleton<IMainMenuHandler, MainMenuHandler>();
services.AddSingleton<IEmployeeMenuHandler, EmployeeMenuHandler>();
services.AddSingleton<IEmployeesDetailsHandler, EmployeesDetailsHandler>();
services.AddSingleton<IClientMenuHandler, ClientMenuHandler>();
services.AddSingleton<IEventsHandler, EventsHandler>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IXmlHandler, XmlHandler>();
services.AddSingleton<IXmlMenuHandler, XmlMenuHandler>();

services.AddDbContext<CarServiceAppDbContext>(options => options
   .UseSqlServer("Data Source = DESKTOP-MIKO\\SQLEXPRESS; Initial Catalog = CarServiceAppStorage; Integrated Security = True;"));
//services.AddDbContext<CarServiceAppDbContext>(options => options
//    .UseSqlServer("Data Source = MIKO-DOM\\SQLEXPRESS; Initial Catalog = CarServiceAppStorage; Integrated Security = True;"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app?.Run();