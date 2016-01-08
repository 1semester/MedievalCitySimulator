using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medCitySim
{
    public partial class Game : Form
    {
        Graphics dc;
        MedCitySim.GameWorld gw;
        /// <summary>
        /// Initializes the game form
        /// </summary>
        public Game()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The timer is used to update new information, and handle current information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gw == null)
            {
                gw = new MedCitySim.GameWorld(dc, this.DisplayRectangle);
            }
            gw.GameLoop();
        }
        /// <summary>
        /// Gives the game form graphics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_Load(object sender, EventArgs e)
        {
            if (dc == null)
            {
                dc = CreateGraphics();
            }
            gw = new MedCitySim.GameWorld(dc, this.DisplayRectangle);
        }
    }
}
