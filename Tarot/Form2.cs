using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tarot.Model;

namespace Allan_Tarot
{
    public partial class Form2 : Form
    {

        
        TarotController controller;
        Dictionary<PictureBox, string> mappingBox = new Dictionary<PictureBox, string>();
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(TarotModel tarot) {
            InitializeComponent();
            controller = new TarotController();
            fillFields1(tarot);
            
        }

        private void MapBoxes1()
        {
            mappingBox.Add(PBOne, "One");
            mappingBox.Add(PBTwo, "Two");
            mappingBox.Add(PBThree, "Three");
            mappingBox.Add(PBFour, "Four");
            mappingBox.Add(PBFive, "Five");
            mappingBox.Add(PBSix, "Six");
            mappingBox.Add(PBA, "A");
            mappingBox.Add(PBB, "B");
            mappingBox.Add(PBC, "C");
            mappingBox.Add(PBD, "D");
            mappingBox.Add(PBE, "E");
            mappingBox.Add(PBF, "F");
            mappingBox.Add(PBF6, "F6");
        }

        private void fillFields1(TarotModel tarot)
        {
            controller.fillCard(PBOne, tarot.One);
            
            controller.fillCard(PBTwo, tarot.Two);
            controller.fillCard(PBThree, tarot.Three);
            controller.fillCard(PBFour, tarot.Four);
            controller.fillCard(PBFive, tarot.Five);
            controller.fillCard(PBSix, tarot.Six);
            controller.fillCard(PBA, tarot.A);
            controller.fillCard(PBB, tarot.B);
            controller.fillCard(PBC, tarot.C);
            controller.fillCard(PBD, tarot.D);
            controller.fillCard(PBE, tarot.E);
            controller.fillCard(PBF, tarot.F);
            controller.fillCard(PBF6, tarot.F6);
            string value = "LifeRoad: " + tarot.LifeRoad.ToString();
            controller.fillLabelCard(LifeRoad, value);            

            PBOne.SizeMode = PictureBoxSizeMode.StretchImage;
            PBTwo.SizeMode = PictureBoxSizeMode.StretchImage;
            PBThree.SizeMode = PictureBoxSizeMode.StretchImage;
            PBFour.SizeMode = PictureBoxSizeMode.StretchImage;
            PBFive.SizeMode = PictureBoxSizeMode.StretchImage;
            PBSix.SizeMode = PictureBoxSizeMode.StretchImage;
            PBA.SizeMode = PictureBoxSizeMode.StretchImage;
            PBB.SizeMode = PictureBoxSizeMode.StretchImage;
            PBC.SizeMode = PictureBoxSizeMode.StretchImage;
            PBD.SizeMode = PictureBoxSizeMode.StretchImage;
            PBE.SizeMode = PictureBoxSizeMode.StretchImage;
            PBF.SizeMode = PictureBoxSizeMode.StretchImage;
            PBF6.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void PictureClick(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            controller.fillCurrentCard(PBCurrentCard, pb.Image);
            string value = mappingBox.Where(x => x.Key == pb).FirstOrDefault().Value;
            controller.fillLabelCard(CurrentCard, value);
        }



        private void PB_MouseHover(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Height = pb.Height * 7;
            pb.Width = pb.Width * 7;
            pb.BringToFront();
        }

        private void PB_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Width = 30;
            pb.Height = 45;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MapBoxes1();
        }
    }
}
