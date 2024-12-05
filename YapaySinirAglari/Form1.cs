namespace YapaySinirAglari
{
    public partial class Form1 : Form
    {

        NeuralNetwork neuralNetwork;
        Button[,] girisButonlarý = new Button[7, 5];
        private Label[] cikisLabelleri = new Label[5];
        public Form1()
        {
            InitializeComponent();
            InitializeNeuralNetwork();
            CreateInputButtons();
            InitializeLabels();
        }

        private void buttonEgit_Click(object sender, EventArgs e)
        {
            List<List<double>> girisler = new List<List<double>>();
            List<List<double>> hedefler = new List<List<double>>();

            for (int i = 0; i < 5; i++)
            {
                List<double> giris = new List<double>();
                List<double> hedef = new List<double>();

                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        giris.Add(EgitimMerkezi.EgitimVerileri[i, j, k]);
                    }
                }

                for (int m = 0; m < 5; m++)
                {
                    hedef.Add(EgitimMerkezi.CikisVektörleri[i, m]);
                }

                girisler.Add(giris);
                hedefler.Add(hedef);
            }

            double toplamHAta = 0;

            for (int epoch = 0; epoch < 5000; epoch++) 
            {
                for (int i = 0; i < girisler.Count; i++)
                {
                    var giris = girisler[i];
                    var hedef = hedefler[i];
                    neuralNetwork.FeedForward(giris);
                    double epochError = neuralNetwork.Backpropagation(hedef, 0.1); // Öðrenme oraný
                    toplamHAta += epochError;
                }

                if (epoch % 100 == 0) //Her 100 epoch'da bir
                {
                    double averageError = toplamHAta / (100 * girisler.Count); // Ortalama hatayý hesapla
                    lblError.Invoke((MethodInvoker)delegate {
                        lblError.Text = $"Hata Oraný: {averageError:F4}";
                    });
                    toplamHAta = 0; //Hata toplamýný sýfýrladýk
                }
            }
            MessageBox.Show("Eðitim tamamlandý...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DisplayOutput(List<double> output)
        {
            for (int i = 0; i < output.Count; i++)
            {
                cikisLabelleri[i].Text = $"{(char)('A' + i)} Çýkýþý: {output[i]:F4}";
            }

            //Maksimum deðeri bulduk ve tahmini harfi bulup yazdýrdýk
            int maxIndex = output.IndexOf(output.Max());
            char predictedChar = (char)('A' + maxIndex);
            MessageBox.Show($"Tahmin edilen harf: {predictedChar}", "Tahmin Edilen HArf", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void InitializeNeuralNetwork()
        {
            int inputSize = 35;  // 7x5 grid
            int hiddenSize = 15;  // Gizli katman nöron sayýsý
            int outputSize = 5;  // 5 harf (A, B, C, D, E)
            neuralNetwork = new NeuralNetwork(inputSize, hiddenSize, outputSize);
        }

        private void InitializeLabels()
        {
            string[] labelsText = { "A Çýkýþý:", "B Çýkýþý:", "C Çýkýþý:", "D Çýkýþý:", "E Çýkýþý:" };
            int startY = 20; 
            int spacingY = 55;
            
            int startX = 300;  
            int spacingX = 1; 

            for (int i = 0; i < cikisLabelleri.Length; i++)
            {
                cikisLabelleri[i] = new Label
                {
                    Location = new Point(startX + (i * spacingX), startY + (i * spacingY)),
                    Size = new Size(200, 20),
                    Text = labelsText[i] + " 0.0"
                };
                this.Controls.Add(cikisLabelleri[i]);
            }
        }
        private void CreateInputButtons()
        {
            int startX = 10;
            int startY = 10;
            int buttonSize = 50;
            int spacing = 5;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button btn = new Button
                    {
                        Width = buttonSize,
                        Height = buttonSize,
                        Location = new Point(startX + j * (buttonSize + spacing), startY + i * (buttonSize + spacing)),
                        BackColor = Color.Yellow
                    };
                    btn.Click += InputButton_Click;
                    Controls.Add(btn);
                    girisButonlarý[i, j] = btn;
                }
            }

            buttonTemizle.Click += buttonTemizle_Click;
            Controls.Add(buttonTemizle);
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = btn.BackColor == Color.Yellow ? Color.Red : Color.Yellow;
        }

        private void buttonTest_Click_1(object sender, EventArgs e)
        {
            List<double> inputVector = new List<double>();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    inputVector.Add(girisButonlarý[i, j].BackColor == Color.Red ? 1.0 : 0.0);
                }
            }

            var output = neuralNetwork.FeedForward(inputVector);
            DisplayOutput(output);
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            saveFileDialog.Title = "Yapay Sinir Aðlarý";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    //Gizli katman aðýrlýklarý ve biaslarý
                    foreach (Neuron neuron in neuralNetwork.GizliKatman.Neurons)
                    {
                        foreach (double weight in neuron.Agirlik)
                        {
                            writer.Write(weight + " ");
                        }
                        writer.WriteLine(neuron.Bias);
                    }

                    //Çýktý katmaný aðýrlýklarý ve biaslarý
                    foreach (Neuron neuron in neuralNetwork.CikisKatmani.Neurons)
                    {
                        foreach (double weight in neuron.Agirlik)
                        {
                            writer.Write(weight + " ");
                        }
                        writer.WriteLine(neuron.Bias);
                    }
                }
            }
        }

        private void buttonYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File (*.txt)|*.txt";
            openFileDialog.Title = "Yapay Sinir Aðý Yükle";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    string line;
                    int neuronIndex = 0;

                    // Gizli katman aðýrlýklarý ve biaslarý oku
                    while ((line = reader.ReadLine()) != null && neuronIndex < neuralNetwork.GizliKatman.Neurons.Count)
                    {
                        string[] values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < values.Length - 1; i++)
                        {
                            neuralNetwork.GizliKatman.Neurons[neuronIndex].Agirlik[i] = double.Parse(values[i]);
                        }
                        neuralNetwork.GizliKatman.Neurons[neuronIndex].Bias = double.Parse(values[values.Length - 1]);
                        neuronIndex++;
                    }

                    neuronIndex = 0; // Çýktý katmaný için indeksi sýfýrla

                    // Çýktý katmaný aðýrlýklarý ve biaslarý oku
                    while ((line = reader.ReadLine()) != null && neuronIndex < neuralNetwork.CikisKatmani.Neurons.Count)
                    {
                        string[] values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < values.Length - 1; i++)
                        {
                            neuralNetwork.CikisKatmani.Neurons[neuronIndex].Agirlik[i] = double.Parse(values[i]);
                        }
                        neuralNetwork.CikisKatmani.Neurons[neuronIndex].Bias = double.Parse(values[values.Length - 1]);
                        neuronIndex++;
                    }
                }
            }
        }
        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            foreach (var button in girisButonlarý)
            {
                button.BackColor = Color.Yellow;
            }
        }
    }
}