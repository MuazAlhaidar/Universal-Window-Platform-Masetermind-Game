using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_UWP_Edition {
    class GameLogic
    {
        //Used to represnt the board
         public int[,] Board=new int[10, 4] {
                    {-1,-1,-1,-1 },
                    {-1,-1,-1,-1 },
                    {-1,-1,-1,-1 },
                    {-1,-1,-1,-1 },
                    {-1,-1,-1,-1 },
                    {-1,-1,-1,-1 },
                    {-1,-1,-1,-1 },
                    {-1,-1,-1,-1 },
                    {-1,-1,-1,-1 },
                    {-1,-1,-1,-1 },
             } ;
         public int Counter = 0; // Used to reprsent how many terms player can make decisiosns
         int[] CPUPegs = new int[4]; //CPU's code
        public int[] ScorePegs = new int[4]; //Score player has


        public GameLogic()
        {
            int[] temp = new int[4];
            temp[0] = 0;
            temp[1] = 1;
            temp[2] = 2;
            temp[3] = 3;
            setCPUPegs(temp) ;

        }
        public void setCPUPegs(int[] Pegs)
        {
            CPUPegs = Pegs;
        }
        // This sets the player's pegs, and return how much pegs are in the right place, and how much are just right color.
        //Returns status code. -1 means "PLayer should stop this game, cause he lost OOF"
        //0 is player has another shot, display score
        //1 means player won.
        public int setPlayerPegsAndScore(int[] Pegs)
        {
            { //Check to see if player should stop playing
                if (Counter >= 10)
                    return -1;
            }

            bool win = false;
            { // Get the score of the plaeyr, and set that to Score Pegs
                int rightPlace = 0;
                int rightColor = 0;

                //Getting number of matching placement
                for(int i=0; i<4; i++) 
                {
                    if (CPUPegs[i] == Pegs[i])
                        rightPlace++;
                    
                }
                if (rightPlace == 4)
                {
                    win = true;
                    for(int i=0; i<10; i++)
                    {
                        for(int j=0; j<4; j++)
                        {
                            Board[i, j] = 10; // THe value to show that this is the winning result
                        }
                    }
                    return 1;
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

            {   //Now, set the player pegs down, and move the counter if they fail. Otherwise if they win, return they won. 
                    for (int i = 0; i < 4; i++)
                    {
                        Board[Counter, i] = Pegs[i];
                    }
                    Counter++;
                    return 0;
            }
        }

        // Player can switch pegs that are on the board, with what is in the field.
        public void switchPegs(int boardPos, int playerPos, int[] PlayerPegs)
        {
            int temp = Board[Counter, boardPos];
            Board[Counter, boardPos]=PlayerPegs[playerPos];
            PlayerPegs[playerPos] = temp;

        }
    }
}
