using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Tarot.Model;
using Tarot.Service;

namespace Allan_Tarot
{
    public partial class Form3 : Form
    {

        private string BaseDirectory = "Resources";
        private Dictionary<PictureBox, PictureBox> mappingBox;
        public Form3()
        {
            InitializeComponent();            

        }

        private void fillPictureBox(PictureBox pictureBox, int value)
        {
            pictureBox.Image = Image.FromFile(BaseDirectory + "/" + value + ".jpg");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void fillFields1(TarotModel tarot)
        {
            this.fillPictureBox(PBOne, tarot.One);
            this.fillPictureBox(PB1, tarot.One);
            this.fillPictureBox(PBTwo, tarot.Two);
            this.fillPictureBox(PB2, tarot.Two);
            this.fillPictureBox(PBThree, tarot.Three);
            this.fillPictureBox(PB3, tarot.Three);
            this.fillPictureBox(PBFour, tarot.Four);
            this.fillPictureBox(PB4, tarot.Four);
            this.fillPictureBox(PBFive, tarot.Five);
            this.fillPictureBox(PB5, tarot.Five);
            this.fillPictureBox(PBSix, tarot.Six);
            this.fillPictureBox(PB6, tarot.Six);
            this.fillPictureBox(PBA, tarot.A);
            this.fillPictureBox(PBA1, tarot.A);
            this.fillPictureBox(PBB, tarot.B);
            this.fillPictureBox(PBB1, tarot.B);
            this.fillPictureBox(PBC, tarot.C);
            this.fillPictureBox(PBC1, tarot.C);
            this.fillPictureBox(PBD, tarot.D);
            this.fillPictureBox(PBD1, tarot.D);
            this.fillPictureBox(PBE, tarot.E);
            this.fillPictureBox(PBE1, tarot.E);
            this.fillPictureBox(PBF, tarot.F);
            this.fillPictureBox(PBF1, tarot.F);
            this.fillPictureBox(PBF6, tarot.F6);
            this.fillPictureBox(PBF61, tarot.F6);

              //LifeRoad.Text = "LifeRoad: " + tarot.LifeRoad.ToString();


        }

        private void GetPictureBox() {
            foreach (var item in Controls.OfType<TabControl>()) {
                var container = item;
                foreach (var itemTabPage in container.Controls.OfType<TabPage>()) {
                    var tabPage = itemTabPage;
                    foreach (var itemPB in tabPage.Controls.OfType<PictureBox>()) {
                        
                        if (itemPB.Name != "pictureBox1") {
                            this.fillPictureBox(itemPB, -1);
                            itemPB.BorderStyle = BorderStyle.Fixed3D;                            
                        }
                        
                    }
                    foreach (var itemPanel in tabPage.Controls.OfType<Panel>()) {
                        var panel = itemPanel;
                        foreach (var pb in panel.Controls.OfType<PictureBox>()) {
                            this.fillPictureBox(pb, -1);
                        }
                        
                    }
                }
            }
        }

        private void PB_MouseHover(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            var result = mappingBox.Where(x => x.Key == pb).FirstOrDefault().Value;
            result.BorderStyle = BorderStyle.Fixed3D;
            result.Height = 100;
            result.Width = 70;            
            result.BringToFront();
            
        }

        private void PB_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            var result = mappingBox.Where(x => x.Key == pb).FirstOrDefault().Value;            
            result.Height = 71;
            result.Width =  48;            
            result.BorderStyle = BorderStyle.None;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            GetPictureBox();
            MappingBoxes();
        }

        private void MappingBoxes() {
            this.mappingBox = new Dictionary<PictureBox, PictureBox>();
            this.mappingBox.Add(PBOne, PB1);
            this.mappingBox.Add(PBTwo, PB2);
            this.mappingBox.Add(PBThree, PB3);
            this.mappingBox.Add(PBFour, PB4);
            this.mappingBox.Add(PBFive, PB5);
            this.mappingBox.Add(PBSix, PB6);
            this.mappingBox.Add(PBA, PBA1);
            this.mappingBox.Add(PBB, PBB1);
            this.mappingBox.Add(PBC, PBC1);
            this.mappingBox.Add(PBD, PBD1);
            this.mappingBox.Add(PBE, PBE1);
            this.mappingBox.Add(PBF, PBF1);
            this.mappingBox.Add(PBF6, PBF61);
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            TarotService tarotService = new TarotService(txtBirthday.Value);
            var tarot = tarotService.GetTarot();
            this.fillFields1(tarot);
        }
    }
}
