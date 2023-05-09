// See https://aka.ms/new-console-template for more information
using Purposeless;

Console.WriteLine("Welcome to the Purposeless (not trademarked) Programming Language (PPL). Please enter a text file to run or enter \"q\" to quit:");

string input = "";

while (input.ToLower() != "q")
{
    input = Console.ReadLine();
    Compiler.Run("C:\\Users\\annon\\Documents\\Visual Studio 2022\\TestProgram.txt");
}
