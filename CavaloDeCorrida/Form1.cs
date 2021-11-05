using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace CavaloDeCorrida
{
    public partial class Form1 : Form
    {
        public PictureBox MeuPictureBox = null;
        public Random  Random { get; set; }
        public int  Chegada { get; set; }

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Random = new Random();
            Chegada = 1400;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            var thread = new List<Task>();
            thread.Add(Task.Factory.StartNew(Metodo));
            thread.Add(Task.Factory.StartNew(Metodo));
            thread.Add(Task.Factory.StartNew(Metodo));
        }
        private void Metodo()
        {
            var cavalo1 = pictureBox1;
            var cavalo2 = pictureBox2;
            var cavalo3 = pictureBox3;

            Point jogador1 = cavalo1.Location;
            Point jogador2 = cavalo2.Location;
            Point jogador3 = cavalo3.Location;

            for (int i = 0; i < 1040; i++)
            {
                Thread.Sleep(Random.Next(0,20));

                if (Task.CurrentId == 1)
                {
                    jogador1.X = i;
                    cavalo1.Location = jogador1;
                }
                if (Task.CurrentId == 2)
                {
                    jogador2.X = i;
                    cavalo2.Location = jogador2;
                }
                if (Task.CurrentId == 3)
                {
                    jogador3.X = i * i;
                    cavalo3.Location = jogador3;
                }
            }
        }        
       
    }
}
