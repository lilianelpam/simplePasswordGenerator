using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator
{
    public class Generator
    {
        public int passwordLength;
        public bool useLetters;
        public string letters;
        public bool useUppercaseLetters;
        public string uppercaseLetters;
        public bool useNumbers;
        public string numbers;
        public bool useCustomCharacters;
        public string customCharacters;

        public string mainString;

        public string auxInputString;
        public string auxInputCustomCharacters;
        public static string promptCustomCharacters = "Please tell me which characters do you want to use. (i.e.: #@$%^&): ";

        public string generatedPassword;

        public Generator()
        {
            Console.WriteLine("Hi, and welcome to simplest password generator ever.\n");
        }

        public string getLineFromConsole()
        {
            string lineInput = Console.ReadLine();

            if (lineInput.Length == 0)
            {
                Console.Write("Please insert a valid string: ");
                return getLineFromConsole();
            }
            else
            {
                return lineInput;
            }
        }

        public void generatePassword()
        {
            generatedPassword = "";

            Random res = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                int x = res.Next(mainString.Length);
                generatedPassword = generatedPassword + mainString[x];
            }
        }

        public void setup()
        {
            setupLetters();
            setupUppercaseLetters();
            setupNumbers();
            setupCustomCharacters();
            generateStrings();
        }

        public bool checkMainString(out string auxString)
        {
            auxString = "";
            if (mainString.Length == 0)
            {
                auxString = "You need to have at least one valid character to be used. Main String length is 0!";
                return false;
            }

            return true;
        }

        public void generateStrings()
        {
            letters = "";
            uppercaseLetters = "";
            numbers = "";
            customCharacters = "";

            if (useLetters)
            {
                letters = "abcdefghijklmnopqrstuvwxyz";
            }

            if (useUppercaseLetters)
            {
                uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            if (useNumbers)
            {
                numbers = "0123456789";
            }

            if (useCustomCharacters)
            {
                customCharacters = auxInputCustomCharacters;
            }

            mainString = letters + uppercaseLetters + numbers + customCharacters;
        }

        public void setupCustomCharacters(bool didntGetIt = false)
        {
            if (didntGetIt)
            {
                Console.WriteLine("I didn't quite get that...");
            }

            Console.Write("Please tell me if you would like to use custom characters. (Y, for yes. N, for no.): ");

            auxInputString = getLineFromConsole();

            switch (auxInputString)
            {
                case "y":
                    useCustomCharacters = true;
                    Console.Write(promptCustomCharacters);
                    auxInputCustomCharacters = getLineFromConsole();
                    break;
                case "Y":
                    useCustomCharacters = true;
                    Console.Write(promptCustomCharacters);
                    auxInputCustomCharacters = getLineFromConsole();
                    break;
                case "n":
                    useCustomCharacters = false;
                    break;
                case "N":
                    useCustomCharacters = false;
                    break;
                default:
                    setupCustomCharacters(true);
                    break;
            }
        }

        public void setupNumbers(bool didntGetIt = false)
        {
            if (didntGetIt)
            {
                Console.WriteLine("I didn't quite get that...");
            }

            Console.Write("Please tell me if you would like to use numbers from 0 to 9. (Y, for yes. N, for no.): ");

            auxInputString = getLineFromConsole();

            switch (auxInputString)
            {
                case "y":
                    useNumbers = true;
                    break;
                case "Y":
                    useNumbers = true;
                    break;
                case "n":
                    useNumbers = false;
                    break;
                case "N":
                    useNumbers = false;
                    break;
                default:
                    setupNumbers(true);
                    break;
            }
        }

        public void setupUppercaseLetters(bool didntGetIt = false)
        {
            if (didntGetIt)
            {
                Console.WriteLine("I didn't quite get that...");
            }

            Console.Write("Please tell me if you would like to use UPPERCASE letters. (Y, for yes. N, for no.): ");

            auxInputString = getLineFromConsole();

            switch (auxInputString)
            {
                case "y":
                    useUppercaseLetters = true;
                    break;
                case "Y":
                    useUppercaseLetters = true;
                    break;
                case "n":
                    useUppercaseLetters = false;
                    break;
                case "N":
                    useUppercaseLetters = false;
                    break;
                default:
                    setupUppercaseLetters(true);
                    break;
            }
        }

        public void setupLetters(bool didntGetIt = false)
        {
            if (didntGetIt)
            {
                Console.WriteLine("I didn't quite get that...");
            }

            Console.Write("Please tell me if you would like to use letters. (Y, for yes. N, for no.): ");

            auxInputString = getLineFromConsole();

            switch (auxInputString)
            {
                case "y":
                    useLetters = true;
                    break;
                case "Y":
                    useLetters = true;
                    break;
                case "n":
                    useLetters = false;
                    break;
                case "N":
                    useLetters = false;
                    break;
                default:
                    setupLetters(true);
                    break;
            }
        }

        public bool checkPasswordLength(out string auxString)
        {
            auxString = "";

            if (passwordLength <= 0)
            {
                auxString = "Password length has to be bigger than 0 characters.";
                return false;
            }

            if (passwordLength > 32)
            {
                auxString = "Password length has to be smaller than 32 characters.";
                return false;
            }

            return true;
        }

        public void getPasswordLength()
        {
            Console.Write("Before we can startplease insert your desired password length. (Between 1 to 32 characters): ");
            this.passwordLength = Convert.ToInt32(getLineFromConsole());
        }
    }
}
