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
        }
    }
}
