using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind
{
    public partial class GameForm : Form
    {
        GameLogic gameLogic = new GameLogic();
        public GameForm()
        {
            InitializeComponent();
        }

        private void TestFunction_Click(object sender, EventArgs e)
        {
            int[] temp = new int[4] { 0, 1, 2, 3 };
            gameLogic.setCPUPegs(temp);

            int[] temp1 = new int[4] { 1, 0, 2, 3 };
            if (1==gameLogic.setPlayerPegsAndScore(temp))
                Console.WriteLine("Player won. Clap clap");
            if (0==gameLogic.setPlayerPegsAndScore(temp1))
                Console.WriteLine("Player dind't won.");
            int[] temp2 = {4,5,1,2};
            if (0==gameLogic.setPlayerPegsAndScore(temp2))
                Console.WriteLine("OOF Player lost");


        }
    }
}
