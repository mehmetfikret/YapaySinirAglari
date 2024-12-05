using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapaySinirAglari
{
    public class Katman
    {
        public List<Neuron> Neurons;


        //nöron sayısı ve giriş sayısını alır ve katmanı oluşturduk
        public Katman(int noronSayiisi, int girisSayisi)
        {
            Neurons = new List<Neuron>();
            for (int i = 0; i < noronSayiisi; i++)
            {
                Neurons.Add(new Neuron(girisSayisi));
            }
        }


        //giriş verilerini nöronlara ileterek çıkışları aldık
        public List<double> FeedForward(List<double> inputs)
        {
            List<double> outputs = new List<double>();
            foreach (var neuron in Neurons)
            {
                neuron.FeedForward(inputs);
                outputs.Add(neuron.Cikti);
            }
            return outputs;
        }
    }
}
