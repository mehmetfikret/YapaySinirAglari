using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapaySinirAglari
{
    public class Neuron
    {
        public List<double> Agirlik;
        public double Bias;
        public double Cikti;
        public double Gradient;
        public List<double> Girisler;

        public Neuron(int girisSayisi)
        {
            Agirlik = new List<double>();
            Girisler = new List<double>();
            Random rand = new Random();
            for (int i = 0; i < girisSayisi; i++)
            {
                Agirlik.Add(rand.NextDouble() - 0.5); //-0.5 ile 0.5 arasında rastgele değerlerle başlattırır
            }
            Bias = rand.NextDouble() - 0.5;
        }

        public double Activate(double input)
        {
            return 1 / (1 + Math.Exp(-input)); //Sigmoid aktivasyon fonksiyonu
        }

        //giriş verilerini nörona ileterek çıkışı hesaplattırdık
        public void FeedForward(List<double> girisler)
        {
            Girisler = girisler;
            double toplam = Bias;
            for (int i = 0; i < Agirlik.Count; i++)
            {
                toplam += girisler[i] * Agirlik[i];
            }
            Cikti = Activate(toplam);
        }
    }
}
