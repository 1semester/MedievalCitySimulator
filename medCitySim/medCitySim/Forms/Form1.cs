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
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes the Form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Starts the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Game g = new Game();
            Hide();
            g.ShowDialog(this);
            Show();
        }
        /// <summary>
        /// Displays the How To Play form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            HowToPlay help = new HowToPlay();
            Hide();
            help.ShowDialog(this);
            Show();
        }
        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
