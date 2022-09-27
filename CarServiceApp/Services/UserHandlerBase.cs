namespace CarServiceApp.Services
{
    public abstract class UserHandlerBase
    {
        protected string GetUserInput(string question)
        {
            Console.WriteLine(question);
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
