using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapaySinirAglari
{
    public static class EgitimMerkezi
    {
        public static int[,,] EgitimVerileri = new int[5, 7, 5] {

            // A
            {
                {0,0,1,0,0},
                {0,1,0,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,1,1,1,1},
                {1,0,0,0,1},
                {1,0,0,0,1}
            },
            // B
            {
                {1,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,1,1,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,1,1,1,0}
            },
            // C
            {
                {0,0,1,1,1},
                {0,1,0,0,0},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {0,1,0,0,0},
                {0,0,1,1,1}
            },
            // D
            {
                {1,1,1,0,0},
                {1,0,0,1,0},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,0,0,0,1},
                {1,0,0,1,0},
                {1,1,1,0,0}
            },
            // E
            {
                {1,1,1,1,1},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {1,1,1,1,1},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {1,1,1,1,1}
            }
        };

        //Çıkış vektörleri
        public static int[,] CikisVektörleri = new int[5, 5] {
            {1,0,0,0,0}, // A
            {0,1,0,0,0}, // B
            {0,0,1,0,0}, // C
            {0,0,0,1,0}, // D
            {0,0,0,0,1}  // E
        };
    }
}
