namespace CarServiceApp.Services
{
    public abstract class UserInputHandler
    {
        protected string GetUserInput(string question)
        {
            Console.WriteLine(question);
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
