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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        TarotController tarotController = new TarotController();

        TarotModel Individual1;
        TarotModel Individual2;        
        Form2 form2;

        Dictionary<PictureBox, string> mappingBox = new Dictionary<PictureBox, string>();
        Dictionary<PictureBox, string> mappingBox2 = new Dictionary<PictureBox, string>();

        private void btnBegin_Click(object sender, EventArgs e)
        {            
            Individual1 = tarotController.GetTarot(txtBirthday1.Value);                        
            this.fillFields1(Individual1);
        }

        private void btnBegin_Click2(object sender, EventArgs e)
        {
            Individual2 = tarotController.GetTarot(txtBirthday2.Value);
            this.fillFields2(Individual2);
        }

        private void HidePictures(Dictionary<PictureBox, string> mapping)
        {
            foreach (var item in mapping.Keys)
            {
                item.Visible = false;
            }
        }

        private void ShowPictures(Dictionary<PictureBox, string> mapping)
        {
            foreach (var item in mapping.Keys)
            {
                item.Visible = true;
            }
        }

        private void fillFields1(TarotModel tarot)
        {
            CurrentCard.Text = "";
            PBCurrentCard.Image = null;
            tarotController.fillCard(PBOne, tarot.One);
            tarotController.fillCard(PBTwo, tarot.Two);
            tarotController.fillCard(PBThree, tarot.Three);
            tarotController.fillCard(PBFour, tarot.Four);
            tarotController.fillCard(PBFive, tarot.Five);
            tarotController.fillCard(PBSix, tarot.Six);
            tarotController.fillCard(PBA, tarot.A);
            tarotController.fillCard(PBB, tarot.B);
            tarotController.fillCard(PBC, tarot.C);
            tarotController.fillCard(PBD, tarot.D);
            tarotController.fillCard(PBE, tarot.E);
            tarotController.fillCard(PBF, tarot.F);
            tarotController.fillCard(PBF6, tarot.F6);
            string lifeRoad = "LifeRoad:" + tarot.LifeRoad;
            tarotController.fillLabelCard(LifeRoad1, lifeRoad);
            ShowPictures(mappingBox);
        }

        private void fillFields2(TarotModel tarot)
        {
            CurrentCard2.Text = "";
            PBCurrentCard2.Image = null;
            tarotController.fillCard(PBOne_2, tarot.One);
            tarotController.fillCard(PBTwo_2, tarot.Two);
            tarotController.fillCard(PBThree_2, tarot.Three);
            tarotController.fillCard(PBFour_2, tarot.Four);
            tarotController.fillCard(PBFive_2, tarot.Five);
            tarotController.fillCard(PBSix_2, tarot.Six);
            tarotController.fillCard(PBA_2, tarot.A);
            tarotController.fillCard(PBB_2, tarot.B);
            tarotController.fillCard(PBC_2, tarot.C);
            tarotController.fillCard(PBD_2, tarot.D);
            tarotController.fillCard(PBE_2, tarot.E);
            tarotController.fillCard(PBF_2, tarot.F);
            tarotController.fillCard(PBF6_2, tarot.F6);
            string lifeRoad = "LifeRoad:" + tarot.LifeRoad;
            tarotController.fillLabelCard(LifeRoad2, lifeRoad);
            ShowPictures(mappingBox2);

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

        private void MapBoxes2()
        {
            mappingBox2.Add(PBOne_2, "One");
            mappingBox2.Add(PBTwo_2, "Two");
            mappingBox2.Add(PBThree_2, "Three");
            mappingBox2.Add(PBFour_2, "Four");
            mappingBox2.Add(PBFive_2, "Five");
            mappingBox2.Add(PBSix_2, "Six");
            mappingBox2.Add(PBA_2, "A");
            mappingBox2.Add(PBB_2, "B");
            mappingBox2.Add(PBC_2, "C");
            mappingBox2.Add(PBD_2, "D");
            mappingBox2.Add(PBE_2, "E");
            mappingBox2.Add(PBF_2, "F");
            mappingBox2.Add(PBF6_2, "F6");
        }

        private void PictureClick1Tab(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            tarotController.fillCurrentCard(PBCurrentCard, pb.Image);
            string value = mappingBox.Where(x => x.Key == pb).FirstOrDefault().Value;
            tarotController.fillLabelCard(CurrentCard, value);
        }

        private void PictureClick2Tab(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            tarotController.fillCurrentCard(PBCurrentCard2, pb.Image);
            string value = mappingBox2.Where(x => x.Key == pb).FirstOrDefault().Value;
            tarotController.fillLabelCard(CurrentCard2, value);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            MapBoxes1();
            MapBoxes2();
            HidePictures(mappingBox);
            HidePictures(mappingBox2);
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (Individual1 == null || Individual2 == null)
            {
                MessageBox.Show("Please, be sure there's 2 people to compare.", "Attention!");
            }
            else {
                if (form2 != null) {
                    form2.Close();
                }
                form2 = new Form2(tarotController.GetTarotCompare(Individual1, Individual2));                                                                                   
                form2.Show();
            }
        }
    }
}
