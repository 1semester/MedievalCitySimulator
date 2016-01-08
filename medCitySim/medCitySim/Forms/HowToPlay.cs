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
    public partial class HowToPlay : Form
    {
        Graphics dc;
        /// <summary>
        /// Initializes the form
        /// </summary>
        public HowToPlay()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Draws the image for How To Play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HowToPlay_Load(object sender, EventArgs e)
        {
            if(dc == null)
            {
                dc = CreateGraphics();
            }


        }
        /// <summary>
        /// Handles the click function on the picture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
