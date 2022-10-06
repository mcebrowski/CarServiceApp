namespace CarServiceApp.Services
{
    public abstract class UserInputHandler
    {
        protected static string GetUserInput(string question)
        {
            Console.WriteLine(question);
            string userInput = Console.ReadLine();
            return userInput;
        }

        protected static string DetermineDepartmentName(int num)
        {
            string departmentName;
            if (num == 1)
            {
                departmentName = "Customer Service";
            }
            else if (num == 2)
            {
                departmentName = "Mechanical Workshop";
            }
            else if (num == 3)
            {
                departmentName = "Body and Paint Workshop";
            }
            else
            {
                departmentName = "Spare Parts";
            }
            return departmentName;
        }
    }
}
