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
            gameLogic.setPlayerPegsAndScore(temp1);
            int[] temp2 = {4,5,1,2};
            gameLogic.setPlayerPegsAndScore(temp2);


        }
    }
}
