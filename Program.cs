using System.Linq.Expressions;
using System.Net;

class Program
{
  static void Main(string[] args)
  {
    string? readResult = null;
    int guessesRemaining = 8;
    int currentGuess = 0;
    int secretNumber = new Random().Next(1, 100);
    Console.WriteLine(secretNumber);

    Console.WriteLine("Welcome to the secret number guessing game!");
    Console.WriteLine("Select a difficulty level: Easy, Medium, Hard or Cheater. This will determine the number of guesses you have.");
    bool validInput = false;
    bool cheaterMode = false;
    do
    {
      Console.WriteLine("1) Easy: 8 guesses");
      Console.WriteLine("2) Medium: 6 guesses");
      Console.WriteLine("3) Hard: 4 guesses");
      Console.WriteLine("4) Cheater: unlimited guesses");
      readResult = Console.ReadLine();

      if (string.IsNullOrEmpty(readResult))
      {
        Console.WriteLine("Invalid input. Please select a difficulty level.");
        continue;
      }

      try
      {
        int numberResult = int.Parse(readResult);

        if (numberResult == 1)
        {
          validInput = true;
        }
        else if (numberResult == 2)
        {
          guessesRemaining = 6;
          validInput = true;
        }
        else if (numberResult == 3)
        {
          guessesRemaining = 4;
          validInput = true;
        }
        else if (numberResult == 4)
        {
          cheaterMode = true;
          guessesRemaining = -10; // Set guesses to less than 0 to allow infinite guesses
          validInput = true;
        }
        else
        {
          Console.WriteLine("Invalid input. Please select a difficulty level.");
        }
      }
      catch (FormatException)
      {
        Console.WriteLine("Invalid input. Please select a difficulty level.");
        continue;
      }
    } while (validInput == false);

    do
    {
      try
      {
        Console.WriteLine("Guess the secret number! Input a number.");
        readResult = Console.ReadLine();
        if (!string.IsNullOrEmpty(readResult))
        {
          int number = int.Parse(readResult);
          if (number > secretNumber)
          {
            currentGuess++;
            Console.WriteLine($"Your guess #{currentGuess} was {number}.");
            Console.WriteLine("Your guess was too high!");
          }
          else if (number < secretNumber)
          {
            currentGuess++;
            Console.WriteLine($"Your guess #{currentGuess} was {number}.");
            Console.WriteLine("Your guess was too low!");
          }
          else
          {
            Console.WriteLine("Congratulations! You guessed the secret number!");
            break;
          }

        }

        else if (string.IsNullOrEmpty(readResult))
        {
          Console.WriteLine("Invalid input. Please enter a valid number.");
          continue;
        }

        if (cheaterMode == false)
        {
          guessesRemaining--;

          if (guessesRemaining == 0)
          {
            Console.WriteLine("You are out of guesses! Too bad! :( The secret number was " + secretNumber);
            break;
          }
          else
          {
            Console.WriteLine($"You have {guessesRemaining} guesses remaining.");
          }
        }
      }

      catch (FormatException)
      {
        Console.WriteLine("Invalid input. Please enter a valid number.");
      }

    } while (guessesRemaining > -1 || cheaterMode == true);
  }
}
