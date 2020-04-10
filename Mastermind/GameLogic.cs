using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class GameLogic
    {
         int[,] Board=new int[10,4]; //Used to represnt the board
         int Counter = 0; // Used to reprsent how many terms player can make decisiosns
         int[] CPUPegs = new int[4]; //CPU's code
        
        public void setCPUPegs(int[] Pegs)
        {
            CPUPegs = Pegs;
        }
        // This sets the player's pegs, and return how much pegs are in the right place, and how much are just right color.
        public void setPlayerPegsAndScore(int[] Pegs)
        {
            int[] ScorePegs = new int[4];

            { // Get the score of the plaeyr, and set that to Score Pegs
                int rightPlace = 0;
                int rightColor = 0;

                //Getting number of matching placement
                for(int i=0; i<4; i++) 
                {
                    if (CPUPegs[i] == Pegs[i])
                        rightPlace++;
                    
                }

                //Getting number of matching colors
                for(int i=0; i<4; i++) 
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (CPUPegs[i] == Pegs[j])
                            rightColor++;
                    }
                    
                }

                //Right colors have to be mutally exlusive to rightPlace.
                rightColor -= rightPlace;
                for (int i = 0; i < 4; i++)
                {
                    if (rightColor != 0)
                    {
                        ScorePegs[i] = 1;
                        rightColor--;
                    }
                    else if (rightPlace != 0)
                    {
                        ScorePegs[i] = 2;
                        rightPlace--;
                    }
                    else
                    {
                        ScorePegs[i] = 0;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(ScorePegs[i]);
            }

            Console.WriteLine("");

        }
    }
}
