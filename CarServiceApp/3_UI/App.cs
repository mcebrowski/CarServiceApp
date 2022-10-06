using CarServiceApp.Data;
using CarServiceApp.Data.DummyData;
using CarServiceApp.Services;
using CarServiceApp.UI;

namespace CarServiceApp
{
    public class App : IApp
    {
        private readonly IDummyDataHandler _dataHandler;
        private readonly IMainMenuHandler _mainMenuHandler;
        private readonly IEventsHandler _eventsHandler;
        private readonly CarServiceAppDbContext _carServiceAppDbContext;

        public App(
            IDummyDataHandler dataHandler,
            IMainMenuHandler mainMenuHandler,
            IEventsHandler eventsHandler,
            CarServiceAppDbContext carServiceAppDbContext
            )
        {
            _dataHandler = dataHandler;
            _mainMenuHandler = mainMenuHandler;
            _eventsHandler = eventsHandler;
            _carServiceAppDbContext = carServiceAppDbContext;
            _carServiceAppDbContext.Database.EnsureCreated();
        }

        public void Run()
        {
            Console.WriteLine("\n***** Welcome to Car Service Application *****\n");
            _eventsHandler.SubscribeToEvents();
            _dataHandler.AddEmployees();
            _dataHandler.AddClients();
            _mainMenuHandler.SelectMainOption();
        }
    }
}