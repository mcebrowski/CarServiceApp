using CarServiceApp.Data;
using CarServiceApp.Services;

namespace CarServiceApp
{
    public class App : IApp
    {
        private readonly IDataHandler _dataHandler;
        private readonly IUserHandler _userHandler;
        private readonly IEventsHandler _eventsHandler;
        private readonly CarServiceAppDbContext _carServiceAppDbContext;

        public App(
            IDataHandler dataHandler,
            IUserHandler userHandler,
            IEventsHandler eventsHandler,
            CarServiceAppDbContext carServiceAppDbContext)
        {
            _dataHandler = dataHandler;
            _userHandler = userHandler;
            _eventsHandler = eventsHandler;
            _carServiceAppDbContext = carServiceAppDbContext;
            _carServiceAppDbContext.Database.EnsureCreated();
        }

        public void Run()
        {
            Console.WriteLine("\n***** Welcome to Car Service Application *****\n");
            _eventsHandler.SubscribeToEvents();
            _dataHandler.AddEmployees();
            _userHandler.SelectYourOption();
        }
    }
}