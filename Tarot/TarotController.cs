using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using Tarot.Model;
using Tarot.Service;
using System.Reflection.Metadata;
using System.Drawing;

namespace Allan_Tarot
{
   public class TarotController
    {
        const string BaseDirectory = "Resources";
        TarotService service;
        public TarotController() {
            
        }

        public void fillCard(PictureBox pb, int value)
        {
            pb.Image = Image.FromFile(BaseDirectory + "/" + value + ".jpg");
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void fillCurrentCard(PictureBox pb, Image image)
        {
            pb.Image = image;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void fillLabelCard(Label label, string value) {
            label.Text = value;
        }

        public TarotModel GetTarot(DateTime birthday) {
            if (service != null) {
                service.SetBirthday(birthday);
            }
            else {
                service = new TarotService(birthday);
            }
            var tarot = service.GetTarot();
            return tarot;
        }

        public TarotModel GetTarotCompare(TarotModel Individual1, TarotModel Individual2) {
            return service.GetCompare(Individual1, Individual2);
        }

       
    }
}
