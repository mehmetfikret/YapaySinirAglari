using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapaySinirAglari
{
    public class NeuralNetwork
    {
        public Katman GizliKatman;
        public Katman CikisKatmani;

        public NeuralNetwork(int inputSize, int hiddenSize, int outputSize)
        {
            GizliKatman = new Katman(hiddenSize, inputSize);//Gizli katman oluşturulur
            CikisKatmani = new Katman(outputSize, hiddenSize);//Çıkış katmanı oluşturulur
        }

       
        public List<double> FeedForward(List<double> inputs)
        {
            var gizliCiktilar = GizliKatman.FeedForward(inputs);// Gizli katman çıktıları hesaplanır
            return CikisKatmani.FeedForward(gizliCiktilar);// Çıkış katmanı çıktıları hesaplanır
        }

        //Hata hesaplaması ve güncelleme işlemleri
        public double Backpropagation(List<double> hedef, double ogrenmeOrani)
        {

            double toplamHata = 0;
            int cikisSayisi = CikisKatmani.Neurons.Count;

            for (int i = 0; i < cikisSayisi; i++)
            {
                Neuron neuron = CikisKatmani.Neurons[i];
                double error = hedef[i] - neuron.Cikti;
                neuron.Gradient = error * neuron.Cikti * (1 - neuron.Cikti);
                toplamHata += error * error; //Toplam hata güncellenir
            }

            // Gizli katman nöronları için hata gradyanını hesapladık
            for (int i = 0; i < GizliKatman.Neurons.Count; i++)
            {
                Neuron neuron = GizliKatman.Neurons[i];
                double toplamGradyan = 0;
                foreach (Neuron cikisNoronlari in CikisKatmani.Neurons)
                {
                    toplamGradyan += cikisNoronlari.Agirlik[i] * cikisNoronlari.Gradient;
                }
                neuron.Gradient = toplamGradyan * neuron.Cikti * (1 - neuron.Cikti); // Sigmoid fonksiyonun türevi
            }

            // Gizli katman ve çıktı katmanı ağırlıkları güncellenir
            foreach (Katman layer in new Katman[] { GizliKatman, CikisKatmani })
            {
                foreach (Neuron neuron in layer.Neurons)
                {
                    for (int i = 0; i < neuron.Agirlik.Count; i++)
                    {
                        neuron.Agirlik[i] += ogrenmeOrani * neuron.Gradient * neuron.Girisler[i];
                    }
                    neuron.Bias += ogrenmeOrani * neuron.Gradient;
                }
            }

            return toplamHata / cikisSayisi; //Ortalama hata
        }
    }
}
