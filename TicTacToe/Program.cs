using System;
using System.Security;

namespace TicTacToe
{
  internal class Program
  {
    
    static void Main(string[] args)
    {
      Console.Write("Хотите сыграть против другого игрока? [y/n] ");
      bool startGame = Console.ReadLine() == "y";
      
      if (startGame)
      {
        char[] field = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char currentPlayer = 'X';
        DrawField(field);        

        while (true)
        {                 
          Console.Write($"Ход {currentPlayer}: ");          
          ConsoleKeyInfo cki = Console.ReadKey(true);
          bool correctInput = int.TryParse(cki.KeyChar.ToString(), out int choise) && choise > 0 && choise <= 9 && field[choise - 1] != 'X' && field[choise - 1] != 'O';        

          if (correctInput)
          {
            Console.WriteLine(cki.KeyChar);
            field[choise - 1] = currentPlayer;
            DrawField(field);

            if (CheckForWin(field))
            {
              Console.WriteLine($"Выиграл игрок {currentPlayer}");
              break;
            }

            if (CheckForDraw(field))
            {
              Console.WriteLine("Ничья");
              break;
            }

            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
          }
          else
          {
            Console.Write("Неверный ход!");
            Console.WriteLine();
          }         
        }
      } 
      else
      {
        Console.Write("Ну нет так нет");
      }     
    }

    static void DrawField(char[] field)
    {
      Console.WriteLine("-------------");
      Console.Write("| ");
      DrawChar(field[0]);
      Console.Write("| ");
      DrawChar(field[1]);
      Console.Write("| ");
      DrawChar(field[2]);
      Console.WriteLine("|");
      Console.WriteLine("-------------");
      Console.Write("| ");
      DrawChar(field[3]);
      Console.Write("| ");
      DrawChar(field[4]);
      Console.Write("| ");
      DrawChar(field[5]);
      Console.WriteLine("|");
      Console.WriteLine("-------------");
      Console.Write("| ");
      DrawChar(field[6]);
      Console.Write("| ");
      DrawChar(field[7]);
      Console.Write("| ");
      DrawChar(field[8]);
      Console.WriteLine("|");
      Console.WriteLine();
    }

    static void DrawChar(char c)
    {
      if (c == 'X')
      {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write($"{c}");
        Console.ResetColor();
        Console.Write(" ");

      }

      else if (c == 'O')
      {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write($"{c}");
        Console.ResetColor();
        Console.Write(" ");

      }
      else
      {
        Console.Write($"{c} ");
      }
    }

    static bool CheckForWin(char[] field)
    {
      return (field[0] == field[1] && field[1] == field[2]) ||
        (field[3] == field[4] && field[4] == field[5]) ||
        (field[6] == field[7] && field[7] == field[8]) ||
        (field[0] == field[4] && field[4] == field[8]) ||
        (field[2] == field[4] && field[4] == field[6]) ||
        (field[0] == field[3] && field[3] == field[6]) ||
        (field[1] == field[4] && field[4] == field[7]) ||
        (field[2] == field[5] && field[5] == field[8]);
    }

    static bool CheckForDraw(char[] field)
    {
      foreach (char c in field)
      {
        if (c != 'X' && c != 'O')
          return false;
      }

      return true;
    }

  }
}
