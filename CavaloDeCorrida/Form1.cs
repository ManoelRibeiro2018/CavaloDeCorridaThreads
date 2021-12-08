using CavaloDeCorrida.Cavalo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CavaloDeCorrida
{
    public partial class Form1 : Form
    {
        public PictureBox MeuPictureBox = null;
        public int Finish { get; set; }

        SemaphoreSlim semaphore = new(2);
        public List<CavaloModel> CavaloModels { get; set; }

        public int chegada = 0;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Finish = 932;
            new CavaloModel(pictureBox1, pictureBox2, pictureBox3);
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            var thread = new List<Task>();

            for (int i = 0; i < 3; i++)
            {
                thread.Add(Task.Factory.StartNew(PrepareRace));
            }
        }
        private void PrepareRace()
        {
            for (int length = 0; length <= Finish; length++)
            {
                Run(length);
            }
        }

        private void Run(int length)
        {
            semaphore.Wait();

            Point jogador1 = CavaloModel.CavaloOne.Location;
            Point jogador2 = CavaloModel.CavaloTwo.Location;
            Point jogador3 = CavaloModel.CavaloThree.Location;


            //Thread.Sleep(1);

            if (Task.CurrentId == 1)
            {
                jogador1.X = length;
                CavaloModel.CavaloOne.Location = jogador1;
            }
            if (Task.CurrentId == 2)
            {
                jogador2.X = length;
                CavaloModel.CavaloTwo.Location = jogador2;
            }
            if (Task.CurrentId == 3)
            {
                jogador3.X = length;
                CavaloModel.CavaloThree.Location = jogador3;
            }

            //FinishRace(Task.CurrentId, length);

            semaphore.Release();
        }

        void Wait()
        {
            if (NvlList.SelectedItem.ToString() == "Ativado")
            {
                semaphore.Wait();
            }
        }

        void Release()
        {
            if (NvlList.SelectedItem.ToString() == "Ativado")
            {
                semaphore.Release();
            }
        }

        public void FinishRace(int? id, int length)
        {

            if (length == Finish && chegada == 0)
            {
                MessageBox.Show($"Cavalo: {id} é o vencedor!!! ");
                ++chegada;
            }
            else if (length == Finish && chegada == 1)
            {
                MessageBox.Show($"Cavalo: {id} chegou em segundo lugar!!! ");
                ++chegada;
            }
            else if (length == Finish && chegada == 2)
            {
                MessageBox.Show($"Cavalo: {id} chegou em terceiro lugar!!! ");
            }
        }
    }
}
