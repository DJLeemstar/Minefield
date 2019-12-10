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
            // % = Player
            //   = Empty
            // £ = Exit

            Random rnd = new Random();
            int mines = 0;

            char[,] mineField = new char[6, 6];

            for (int row = 0; row < 6; row++)
            {
                // 0,0 can't be a mine, since that's where the player starts.

                for (int column = 1; column < 6; column++)
                {
                    // Guaranteed six mines
                    while (mines < 6)
                    {
                        // Tenth chance of a mine
                        if (rnd.Next(1, 11) == 10)
                        {
                            mineField[row, column] = '*';
                        }

                        // Indicates it as empty
                        else
                        {
                            mineField[row, column] = ' ';
                        }

                    }

                }
                

            }

        }
    }
}
