using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArrayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // * = Mine
            // | = Empty
            // ? = Unknown (Player Only)

            // Initialise/Declare variables needed
            Random rnd = new Random();
            int mines = 0;
            int winConField = 0;
            bool gameOver = false;

            int winConUser;
            int rowInput;
            int columnInput;
            

            string[,] mineField = new string[6, 6];
            string[,] userField = new string[6, 6];

            // Number of mines tends towards 8 or higher. Keeps random but in a general area.
            while (mines < 8)
            {
                for (int row = 0; row < 6; row++)
                {
                    // Randomly place mines along the map

                    for (int column = 0; column < 6; column++)
                    {
                        userField[row, column] = " ? ";

                        // Fifth chance of a mine, ensures they are spread out
                        if (rnd.Next(1, 6) == 5 && mineField[row, column] != " * ")
                        {
                            mineField[row, column] = " * ";
                            mines++;
                        }

                        // Indicates it as empty
                        else
                        {
                            mineField[row, column] = " | ";
                        }

                        // Print the real, hidden minefield. Used for testing.

                        Console.Write(mineField[row, column]);

                    }

                    Console.WriteLine("\n");

                }          
            }

            // Iterate through minefield to count number of mines
            for (int row = 0; row < 6; row++)
            {
                // Separate to previous iteration to avoid runtime error

                for (int column = 0; column < 6; column++)
                {
                    if (mineField[row, column] == " * ")
                    {
                        // Count is used later for win condition

                        winConField++;

                    }
                }
            }

            // Welcoming Message for First Play

            Console.WriteLine("Welcome to Minesweeper!");

            // Print the empty minefield

            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 6; column++)
                {

                    Console.Write(userField[row, column]);

                }

                Console.WriteLine("\n");

            }

            // Loop until win/loss condition is met
            while (!gameOver)
            {
                // Reset mineCount
                int mineCount = 0;

                // Gain user input once game has started

                Console.WriteLine("Please input a vertical number (0-5):");
                rowInput = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Please input a horizontal number (0-5):");
                columnInput = Int32.Parse(Console.ReadLine());

                // Loss condition activates and game is over
                if (mineField[rowInput, columnInput] == " * ")
                {

                    Console.WriteLine("You just hit a mine! You lose!");
                    gameOver = true;

                }

                // Must have hit an empty space
                else
                {
                    // If the value is the top line, but not the corners
                    if (rowInput == 0 && columnInput != 0 && columnInput != 5)
                    {
                        // Iterate specific row/column numbers based on unique position
                        for (int row = 0; row < 2; row++)
                        {
                            for (int column = columnInput - 1; column <= columnInput + 1; column++)
                            {
                                // Count all mines within a square of the chosen space
                                if (mineField[row, column] == " * ")
                                {

                                    mineCount++;

                                }

                            }

                        }

                    }

                    // If the value is the bottom line, but not the corners
                    else if (rowInput == 5 && columnInput != 0 && columnInput != 5)
                    {
                        for (int row = 4; row < 6; row++)
                        {

                            for (int column = columnInput - 1; column <= columnInput + 1; column++)
                            {

                                if (mineField[row, column] == " * ")
                                {

                                    mineCount++;

                                }

                            }

                        }

                    }

                    // If the value is the left line, but not the corners
                    else if (columnInput == 0 && rowInput != 0 && rowInput != 5)
                    {
                        for (int row = rowInput - 1; row <= rowInput + 1; row++)
                        {
                            for (int column = 0; column < 2; column++)
                            {

                                if (mineField[row, column] == " * ")
                                {

                                    mineCount++;

                                }

                            }

                        }

                    }

                    // If the value is the right line, but not the corners
                    else if (columnInput == 5 && rowInput != 0 && rowInput != 5)
                    {
                        for (int row = rowInput - 1; row <= rowInput + 1; row++)
                        {
                            for (int column = 4; column < 6; column++)
                            {

                                if (mineField[row, column] == " * ")
                                {

                                    mineCount++;

                                }

                            }

                        }


                    }

                    // If the value is the top left corner
                    else if (rowInput == 0 && columnInput == 0)
                    {
                        for (int row = 0; row < 2; row++)
                        {
                            for (int column = 0; column < 2; column++)
                            {
                                if (mineField[row, column] == " * ")
                                {

                                    mineCount ++;

                                }
                            }
                        }
                    }

                    // If the value is the top right corner
                    else if (rowInput == 0 && columnInput == 5)
                    {
                        for (int row = 0; row < 2; row++)
                        {
                            for (int column = 4; column < 6; column++)
                            {
                                if (mineField[row, column] == " * ")
                                {

                                    mineCount++;

                                }

                            }

                        }

                    }

                    // If the value is the bottom left corner
                    else if (rowInput == 5 && columnInput == 0)
                    {
                        for (int row = 4; row < 6; row++)
                        {
                            for (int column = 0; column < 2; column++)
                            {

                                if (mineField[row, column] == " * ")
                                {

                                    mineCount++;

                                }

                            }
                        }
                    }

                    // If the value is the bottom right corner
                    else if (rowInput == 5 && columnInput == 5)
                    {

                        for (int row = 4; row < 6;  row++)
                        {

                            for (int column = 4; column < 6; column++)
                            {

                                if (mineField[row, column] == " * ")
                                {

                                    mineCount++;

                                }

                            }

                        }

                    }

                    // If the value is anywhere that isn't next to an edge
                    else
                    {
                        for (int row = rowInput - 1; row <= rowInput + 1; row++)
                        {
                            for (int column = columnInput - 1; column <= columnInput + 1; column++)
                            {
                                if (mineField[row, column] == " * ")
                                {

                                    mineCount++;

                                }

                            }

                        }


                    }

                    // Change what the user sees to compensate
                    // The number in the box states how many mines are within the square around it
                    userField[rowInput, columnInput] = " " + mineCount.ToString() + " ";
                    Console.Clear();

                    // Reset win conditions to 0 for each attempt
                    winConUser = 0;

                    // Iterate to check win condition and write out the table the user should see.
                    for (int row = 0; row < 6; row++)
                    {
                        for (int column = 0; column < 6; column++)
                        {
                            // Print the minefield the user has
                            Console.Write(userField[row, column]);

                            // Count unchecked spaces
                            if (userField[row, column] == " ? ")
                            {
                                winConUser++;
                            }

                        }

                        Console.WriteLine("\n");

                    }

                    // Checks if player has checked every box and has not hit a mine
                    
                    if (winConUser == winConField)
                    {
                        // Win condition, game ends and user wins

                        Console.WriteLine("Congratulations! You get every square that wasn't a mine! You win!");
                        gameOver = true;

                    }

                }

            }

            Console.ReadKey();

        }
    }
}
