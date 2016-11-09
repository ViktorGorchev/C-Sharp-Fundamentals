using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAGame.UI;

namespace SAGame
{
    public partial class Form1 : Form
    {
        private Maps game;
        public Form1()
        {
            InitializeComponent();
            game = new Maps(this);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            game.HandeleKeyPress(e);
        }
        
    }
    
}
