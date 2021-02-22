using System;
using System.Windows.Forms;
using Tarot.Model;

namespace Tarot.Service
{

    public class TarotService
    {

        private DateTime birthday;
        private TarotModel tarot;

        public TarotService(DateTime birthday)
        {
            this.birthday = birthday;
            this.tarot = new TarotModel();
        }

        public DateTime BirthDay
        {
            get
            {
                return this.birthday;
            }
        }

        public void SetBirthday(DateTime birthday)
        {
            this.birthday = birthday;
        }

        private void fillLabel(Label label, string value) {
            label.Text = value;
        }

        public TarotModel GetTarot()
        {
            this.tarot.A = this.GetA();
            this.tarot.B = this.GetB();
            this.tarot.C = this.GetC();
            this.tarot.D = this.GetD();
            this.tarot.E = this.GetE();
            this.tarot.F = this.GetF();
            this.tarot.F6 = this.GetF6();
            this.tarot.One = this.GetOne();
            this.tarot.Two = this.GetTwo();
            this.tarot.Three = this.GetThree();
            this.tarot.Four = this.GetFour();
            this.tarot.Five = this.GetFive();
            this.tarot.Six = this.GetSix();
            this.tarot.TarotNumberCard = this.GetTarotCardNumber();
            this.tarot.Birthday = this.birthday;
            this.tarot.LifeRoad = this.GetLifeRoad();
            return tarot;
        }

        private int GetDecompose(int value)
        {
            string valueStr = value.ToString();
            int sum = value;
            if (sum <= 22)
            {
                return sum;
            }
            sum = 0;            
            for (int index = 0; index < valueStr.Length; index++)
            {
                int current = int.Parse(valueStr[index].ToString());
                sum += current;
            }
            if (sum > 22)
            {
                return GetDecompose(sum);
            }
            return sum;
        }

        private int GetOne()
        {
            return this.birthday.Month;
        }

        private int GetTwo()
        {
            var day = GetDecompose(this.birthday.Day);
            var year = GetDecompose(this.birthday.Year);
            var result = day + year;
            return GetDecompose(result);
        }

        private int GetThree()
        {
            var day = GetDecompose(this.birthday.Day);
            return day;
        }

        private int GetFour()
        {
            var day = GetDecompose(this.birthday.Day);
            var month = this.birthday.Month;

            var result = day + month;

            return GetDecompose(result);

        }

        private int GetFive()
        {
            var year = GetDecompose(this.birthday.Year);
            return year;
        }

        private int GetSix()
        {
            var result = this.GetOne() + this.GetTwo() + this.GetThree() + this.GetFour() + this.GetFive();
            return GetDecompose(result);
        }

        private int GetA()
        {
            var result = this.GetOne() + GetTwo();

            return GetDecompose(result);
        }

        private int GetB()
        {
            var result = GetTwo() + GetThree();

            return GetDecompose(result);
        }

        private int GetC()
        {
            var result = GetThree() + GetFour();

            return GetDecompose(result);

        }
        private int GetD()
        {
            var result = GetFour() + GetFive();

            return GetDecompose(result);

        }
        private int GetE()
        {
            var result = GetFive() + GetOne();

            return GetDecompose(result);
        }
        private int GetF()
        {
            var result = GetA() + GetB() + GetC() + GetD() + GetE();

            return GetDecompose(result);
        }

        private int GetF6()
        {
            var result = GetSix() + GetF();

            return GetDecompose(result);
        }

        private int GetTarotCardNumber()
        {
            var yearDecomposed = GetDecompose(DateTime.Now.Year);
            var result = yearDecomposed + GetF6();

            return GetDecompose(result);
        }

        private int GetLifeRoad()
        {
            var day = this.birthday.Day;
            var month = this.birthday.Month;
            var year = this.birthday.Year;
            string concat = day.ToString() + month.ToString() + year.ToString();
            var result = GetDecompose(int.Parse(concat));
            return GetDecompose(result);
        }

        public TarotModel GetCompare(TarotModel firstIndividual, TarotModel secondIndividual) {
            TarotModel compareResult = new TarotModel();

            compareResult.A = this.GetDecompose(firstIndividual.A + secondIndividual.A);
            compareResult.B = this.GetDecompose(firstIndividual.B + secondIndividual.B);
            compareResult.C = this.GetDecompose(firstIndividual.C + secondIndividual.C);
            compareResult.D = this.GetDecompose(firstIndividual.D + secondIndividual.D);
            compareResult.E = this.GetDecompose(firstIndividual.E + secondIndividual.E);
            compareResult.F = this.GetDecompose(firstIndividual.F + secondIndividual.F);
            compareResult.F6 = this.GetDecompose(firstIndividual.F6 + secondIndividual.F6);
            compareResult.LifeRoad = this.GetDecompose(firstIndividual.LifeRoad + secondIndividual.LifeRoad);
            compareResult.One = this.GetDecompose(firstIndividual.One + secondIndividual.One);
            compareResult.Two = this.GetDecompose(firstIndividual.Two + secondIndividual.Two);
            compareResult.Three = this.GetDecompose(firstIndividual.Three + secondIndividual.Three);
            compareResult.Four = this.GetDecompose(firstIndividual.Four + secondIndividual.Four);
            compareResult.Five = this.GetDecompose(firstIndividual.Five + secondIndividual.Five);
            compareResult.Six = this.GetDecompose(firstIndividual.Six + secondIndividual.Six);
            
            return compareResult;
        }
    }

}