using System;
using System.Collections.Generic;
using System.Text;

namespace RGR_VLADA_1_1
{
    class Translate
    {
        static string func1(string n, string p1)
        {
            string[] str = n.Split(',', '.');
            string minys = "";
            if (str[0].IndexOf('-') != -1)
            {
                str[0] = str[0].Remove(0, 1);
                minys = "-";
            }
            string mas = "";
            string mas1 = "";
            string sp = "0123456789ABCDEFG";
            int n1 = Convert.ToInt32(str[0]);
            double n2 = -1;
            if (str.Length > 1)
                n2 = Convert.ToDouble("0," + str[1]);
            int count2 = 0;
            int p = Convert.ToInt32(p1);
            do
            {
                mas += sp[n1 % p];
                n1 /= p;
            }
            while (n1 / p >= 1);
            mas += sp[n1 % p];
            if (n2 > 0)
            {
                mas1 = ",";
                do
                {
                    string s = Convert.ToString(n2 * p);
                    string[] s2 = s.Split(',');
                    mas1 += sp[Convert.ToInt32(s2[0])];
                    n2 = Convert.ToDouble("0," + s2[1]);
                    count2++;
                }
                while (count2 < 6);
            }
            char[] mas2 = mas.ToCharArray();
            Array.Reverse(mas2);
            string mas0 = new string(mas2);
            return (minys + mas0 + mas1);
        }
        static double func2(string n, string p1)
        {
            string[] str = n.Split(',', '.');
            double minys = 1;
            if (str[0].IndexOf('-') != -1)
            {
                str[0] = str[0].Remove(0, 1);
                minys *= -1;
            }
            string s0 = str[0];
            string s1 = "-1";
            if (n.IndexOf('.') != -1 || n.IndexOf(',') != -1)
                s1 = str[1];
            double mas0 = 0;
            int count0 = 0;
            double mas1 = 0;
            int count1 = -1;
            int p = Convert.ToInt32(p1);
            int[] mas1_g = new int[17];

            do
            {
                if (s0[s0.Length - 1] < 58)
                    mas0 += (s0[s0.Length - 1] - 48) * Math.Pow(p, count0);
                else
                    mas0 += (s0[s0.Length - 1] - 55) * Math.Pow(p, count0);
                count0++;
                s0 = s0.Remove(s0.Length - 1, 1);
            }
            while (s0.Length > 0);
            if (s1 != "-1")
            {
                do
                {
                    if (s1[0] < 58)
                        mas1 += (s1[0] - 48) * Math.Pow(p, count1);
                    else
                        mas1 += (s1[0] - 55) * Math.Pow(p, count1);
                    count1--;
                    s1 = s1.Remove(0, 1);
                }
                while (s1.Length > 0);
            }
            return minys * (mas0 + mas1);
        }
    }
}
