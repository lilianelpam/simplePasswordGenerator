// See https://aka.ms/new-console-template for more information

using Password_Generator;

class Program
{
    static void Main(string[] args)
    {
        string auxString;
        Generator generator = new Generator();

        generator.getPasswordLength();

        if (!generator.checkPasswordLength(out auxString))
        {
            Console.WriteLine(auxString);
            return;
        }

        generator.setup();

        if (!generator.checkMainString(out auxString))
        {
            Console.WriteLine(auxString);
            return;
        }

        generator.generatePassword();

        Console.WriteLine("Here is your password: " + generator.generatedPassword + "\nEnjoy! nwn");
    }
}