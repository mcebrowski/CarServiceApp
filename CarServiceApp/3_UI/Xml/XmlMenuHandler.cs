using CarServiceApp.Data.XmlHandler;
using CarServiceApp.Services;

namespace CarServiceApp.UI
{
    public class XmlMenuHandler : UserInputHandler, IXmlMenuHandler
    {
        private readonly IXmlHandler _xmlHandler;

        public XmlMenuHandler(IXmlHandler xmlHandler)
        {
            _xmlHandler = xmlHandler;
        }

        public void SelectYourOption() 
        {
            bool inXmlMenu = true;
            while (inXmlMenu)
            {
                Console.WriteLine("--- XML FILES MENU ---\n");
                Console.WriteLine("1 - Add employees dummy data to Xml file\n");
                Console.WriteLine("2 - Add clients dummy data to Xml file\n");
                Console.WriteLine("3 - Create xml file with clients in each department (with department manager)\n");
                Console.WriteLine("Q - Go back to main menu\n");

                var userInput = GetUserInput("Please select valid option \nPress key: 1, 2, 3 or Q").ToUpper();

                switch (userInput)
                {
                    case "1":
                        _xmlHandler.CreateXml("employees");
                        break;
                    case "2":
                        _xmlHandler.CreateXml("clients");
                        break;
                    case "3": 
                        _xmlHandler.JoinXml();
                        break;
                    case "Q":
                        inXmlMenu = false;
                        break;
                    default:
                        Console.WriteLine($"Invalid input. You have entered [{userInput}]. Please select valid option");
                        continue;
                }
            }
        }
    }
}
