using System;

namespace TicTacToe
{
  internal class Program
  {
    const char crossSign = 'X';
    const char roundSign = 'O';

    static void Main(string[] args)
    {
      Console.Write("Хотите сыграть против другого игрока? [y/n] ");
      bool startGame = Console.ReadLine() == "y";

      if (startGame)
      {
        char[] field = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        char currentPlayer = crossSign;

        DrawField(field);        

        while (true)
        {                 
          Console.Write($"Ход {currentPlayer}: ");          
          ConsoleKeyInfo cki = Console.ReadKey(true);
          bool correctInput = int.TryParse(cki.KeyChar.ToString(), out int choise) && 
            choise > 0 && choise <= 9 && field[choise - 1] != crossSign && field[choise - 1] != roundSign;

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

            currentPlayer = (currentPlayer == crossSign) ? roundSign : crossSign; // смена игрока.
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

    /// <summary>
    /// Отрисовываем текущее состояния игрового поля.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    static void DrawField(char[] field)
    {
      for (int i = 0; i < 9; i += 3)
      {
        Console.WriteLine("-------------");
        Console.Write("| ");
        DrawSign(field[i]);
        Console.Write("| ");
        DrawSign(field[i + 1]);
        Console.Write("| ");
        DrawSign(field[i + 2]);
        Console.WriteLine("|");
      }

      Console.WriteLine("-------------");
      Console.WriteLine();    
    }

    /// <summary>
    /// Отрисовываем знак в игровом поле.
    /// </summary>
    /// <param name="sign">Знак игрока.</param>
    static void DrawSign(char sign)
    {
      if (sign == crossSign)
      {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write($"{sign}");
        Console.ResetColor();
        Console.Write(" ");
      }
      else if (sign == roundSign)
      {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write($"{sign}");
        Console.ResetColor();
        Console.Write(" ");
      }
      else
      {
        Console.Write($"{sign} ");
      }
    }

    /// <summary>
    /// Проверяем на выигрыш.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    /// <returns>True, если есть выигрышная комбинация, иначе - false.</returns>
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

    /// <summary>
    /// Проверяем на ничью.
    /// </summary>
    /// <param name="field">Игровое поле.</param>
    /// <returns>True, если ничья, иначе - false.</returns>
    static bool CheckForDraw(char[] field)
    {
      foreach (char c in field)
      {
        if (c != crossSign && c != roundSign)
          return false;
      }

      return true;
    }

  }
}
