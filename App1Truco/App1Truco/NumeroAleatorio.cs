using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrucoAPP
{
    /// <summary>
    /// Métodos avançados para randomização
    /// </summary>
   public static class Randomizer
    {
        static Randomizer()
        {
            nextRandom = new Random();
            nextRandomHistory = new ArrayList();
        }
        private static Random nextRandom;
        private static ArrayList nextRandomHistory;
        private static int cont = 0;
        public static int Next()
        {

            cont++;
            int value = nextRandom.Next(0,3);
            while (true)
            {
                if (cont == 3)
                {
                    nextRandomHistory.Clear();
                    cont = 0;
                }
                if (!nextRandomHistory.Contains(value))
                {
                    nextRandomHistory.Add(value);
                    return value;
                }
                value = nextRandom.Next(0,3);
            }
        }
    }
}