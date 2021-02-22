using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tarot.Model;
using Tarot.Service;

namespace Allan_Tarot
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        TarotModel Individual1;
        TarotModel Individual2;
        TarotModel Compare;
        TarotController tarotController = new TarotController();
        Dictionary<PictureBox, string> mappingBox = new Dictionary<PictureBox, string>();
        Dictionary<PictureBox, string> mappingBox2 = new Dictionary<PictureBox, string>();
        Dictionary<PictureBox, string> mappingBox3 = new Dictionary<PictureBox, string>();


        private void fillFields1(TarotModel tarot)
        {
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
            tarotController.fillLabelCard(lblLifeRoad1, lifeRoad);
            ShowPictures(mappingBox);
        }

        private void fillFields2(TarotModel tarot)
        {
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
            tarotController.fillLabelCard(lblLifeRoad2, lifeRoad);
            ShowPictures(mappingBox2);


        }

        private void fillFields3(TarotModel tarot)
        {
            tarotController.fillCard(PBOne_Compare, tarot.One);
            tarotController.fillCard(PBTwo_Compare, tarot.Two);
            tarotController.fillCard(PBThree_Compare, tarot.Three);
            tarotController.fillCard(PBFour_Compare, tarot.Four);
            tarotController.fillCard(PBFive_Compare, tarot.Five);
            tarotController.fillCard(PBSix_Compare, tarot.Six);
            tarotController.fillCard(PBA_Compare, tarot.A);
            tarotController.fillCard(PBB_Compare, tarot.B);
            tarotController.fillCard(PBC_Compare, tarot.C);
            tarotController.fillCard(PBD_Compare, tarot.D);
            tarotController.fillCard(PBE_Compare, tarot.E);
            tarotController.fillCard(PBF_Compare, tarot.F);
            tarotController.fillCard(PBF6_Compare, tarot.F6);
            string lifeRoad = "LifeRoad:" + tarot.LifeRoad;
            tarotController.fillLabelCard(lblLifeRoad3, lifeRoad);
            ShowPictures(mappingBox3);


        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            
            Individual1 = tarotController.GetTarot(txtBirthday.Value);                        
            this.fillFields1(Individual1);            
        }

        private void PictureClick1Tab(object sender, EventArgs e) {
            var pb = (PictureBox)sender;
            tarotController.fillCurrentCard(currentPicture,pb.Image);
            string value = mappingBox.Where(x => x.Key == pb).FirstOrDefault().Value;
            tarotController.fillLabelCard(currentCard, value);
        }

        private void PictureClick2Tab(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            tarotController.fillCurrentCard(currentPicture2, pb.Image);
            string value = mappingBox2.Where(x => x.Key == pb).FirstOrDefault().Value;
            tarotController.fillLabelCard(currentCard2, value);
        }

        private void HidePictures(Dictionary<PictureBox, string> mapping) {
            foreach (var item in mapping.Keys) {
                item.Visible = false;
            }
        }

        private void ShowPictures(Dictionary<PictureBox, string> mapping) {
            foreach (var item in mapping.Keys)
            {
                item.Visible = true;
            }
        }

        private void PictureClick3Tab(object sender, EventArgs e)
        {
            var pb = (PictureBox)sender;
            tarotController.fillCurrentCard(currentPicture3, pb.Image);
            string value = mappingBox3.Where(x => x.Key == pb).FirstOrDefault().Value;
            tarotController.fillLabelCard(currentCard3, value);
        }

        private void MapBoxesTab1() {
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

        private void MapBoxesTab2()
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

        private void MapBoxesTab3()
        {
            mappingBox3.Add(PBOne_Compare, "One");
            mappingBox3.Add(PBTwo_Compare, "Two");
            mappingBox3.Add(PBThree_Compare, "Three");
            mappingBox3.Add(PBFour_Compare, "Four");
            mappingBox3.Add(PBFive_Compare, "Five");
            mappingBox3.Add(PBSix_Compare, "Six");
            mappingBox3.Add(PBA_Compare, "A");
            mappingBox3.Add(PBB_Compare, "B");
            mappingBox3.Add(PBC_Compare, "C");
            mappingBox3.Add(PBD_Compare, "D");
            mappingBox3.Add(PBE_Compare, "E");
            mappingBox3.Add(PBF_Compare, "F");
            mappingBox3.Add(PBF6_Compare, "F6");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            MapBoxesTab1();
            MapBoxesTab2();
            MapBoxesTab3();
            this.HidePictures(mappingBox);
            this.HidePictures(mappingBox2);
            this.HidePictures(mappingBox3);
        }

        private void btnBegin2_Click(object sender, EventArgs e)
        {
            Individual2 = tarotController.GetTarot(txtBirthday2.Value);
            this.fillFields2(Individual2);                        
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            var tab = (TabControl)sender;
            if (tab.SelectedIndex == 2) {
                if (Individual1 != null && Individual2 != null)
                {
                    
                    Compare = tarotController.GetTarotCompare(Individual1, Individual2);
                    fillFields3(Compare);
                    currentCard3.Text = "";
                    currentPicture3.Image = null;
                }
                else
                {
                    MessageBox.Show("Be sure to have 2 individuals to compare!", "Attention!");
                    tab.SelectedIndex = 0;

                }
            }
            
            
        }
    }
}
