using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CavaloDeCorrida.Cavalo
{
    public class CavaloModel
    {
        public int Id { get; set; }
        public static PictureBox  CavaloOne { get; internal set; }
        public static PictureBox CavaloTwo { get; internal set; }
        public static PictureBox CavaloThree { get; internal set; }
        public Point CavaloPointOne { get; set; }
        public Point CavaloPointTwo { get; internal set; }
        public Point CavaloPointThree { get; internal set; }

        public CavaloModel(PictureBox cavaloOne, PictureBox cavaloTwo, PictureBox cavaloThree)
        {
            CavaloOne = cavaloOne;
            CavaloTwo = cavaloTwo;
            CavaloThree = cavaloThree;
        }
     
    }
}
