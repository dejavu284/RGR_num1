using System;

namespace RGR_VLADA_1_1
{
    class Program
    {
        static string perevodVdvoichku(string n, string p1)
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
            string otvet2 = "";
            string CleanOtvet = mas0 + mas1;
            string[] forCleanOtvet;
            string CleanOtvet2;
            if (CleanOtvet.IndexOf(',') != -1)
            {
                forCleanOtvet = CleanOtvet.Split(',');
                CleanOtvet2 = forCleanOtvet[0] + forCleanOtvet[1];
            }
            else CleanOtvet2 = mas0;
            if (CleanOtvet2.Length > 12)
            {
                Console.WriteLine("Число будет ограничено 12 разрядами\n");
                if (CleanOtvet.IndexOf(',') != -1)
                {
                    if (CleanOtvet.IndexOf(',') <= 13)
                    {
                        string[] StrArr = CleanOtvet.Split(',');
                        string sep = ",";
                        int len = StrArr[0].Length + StrArr[1].Length - 12;
                        otvet2 = StrArr[0] + sep + StrArr[1].Substring(0, StrArr[1].Length - len);

                    }
                    else if (CleanOtvet.IndexOf(',') > 13)
                    {
                        otvet2 = CleanOtvet.Substring(0, 12);
                        otvet2 = minys + otvet2;
                    }
                }
                else
                {
                    otvet2 = CleanOtvet.Substring(0, 12);
                    otvet2 = minys + otvet2;
                }
            }
                if (otvet2.Length == 12 || otvet2.Length == 13) return otvet2;
            CleanOtvet = minys + CleanOtvet;
            return CleanOtvet;
        }
        static void ChangeSep(ref string number)
        {
            if (number.IndexOf('.') != -1)
            {
                string[] StrArr = number.Split('.');
                string sep = ",";
                number = StrArr[0] + sep + StrArr[1];
            }
        }
       static void Main(string[] args)
        {
            Console.WriteLine("Раздел №1 «Перевод из 10-тичной системы счисления в p-ичную»\nТипы Object Pascal");
            Console.WriteLine("Текст задания:");
            Console.WriteLine("Спроектируйте и реализуйте приложение для преобразования числа\nиз одного формата(входного) в другой формат(выходной).\n");
            Console.WriteLine("Входной формат - число в 10-ичной системе счисления\nВыходной формат - число в 2-ичной или в 11-ичной системе счисления\n");
            Console.WriteLine();
            bool flagg = true;
            while (flagg)
            {
                Console.WriteLine();
                Console.WriteLine("================================================================");
                Console.WriteLine("                   Перевод систем счисления                     ");
                Console.WriteLine("================================================================\n");
                string n1;
                Console.WriteLine("//================================================================");
                Console.Write("\tВведите число в десятичной системе счисления:\t");
                while (true)
                {
                    int index = 0;
                    n1 = Console.ReadLine();
                    Console.WriteLine("//================================================================\n\n");
                    bool flag = Chislo(n1, ref index);
                    if (flag == true)
                    {
                        ChangeSep(ref n1);
                        double n1numb;
                        try
                        {
                            n1numb = double.Parse(n1);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("//================================================================");
                            Console.Write("\tЧисло большое, введите заного: ");
                            continue;
                        }
                        if (n1numb > int.MaxValue)
                        {
                            Console.WriteLine("//================================================================");
                            Console.Write("\tЧисло слишком большое, введите заного: ");
                            continue;
                        }
                        else if (n1numb < int.MinValue)
                        {
                            Console.WriteLine("//================================================================");
                            Console.Write("\tЧисло слишком маленькое, введите заного: ");
                            continue;
                        }
                        break; 
                    }
                    Console.WriteLine("//================================================================");
                    Console.Write("\tНе число, ошибка в {0} символе, введите заного: ", index + 1);
                }
                

                Console.WriteLine("//================================================================");
                Console.Write("\tВведите систему счисления в которую надо перевести число:   ");
                string p1;
                while (true)
                {
                    int index = 0;
                    p1 = Console.ReadLine();
                    Console.WriteLine("//================================================================\n\n");
                    if (Chislo(p1, ref index) == true || p1.IndexOf(',') == -1 || p1.IndexOf('.') == -1)
                    {
                        if (p1 == "11" || p1 == "2")
                        {
                            break;
                        }
                        Console.WriteLine("//================================================================");
                        Console.Write("\tВыбрана недопустимая система счисления, попробуйте еще раз:   ");
                        continue;
                    }
                    Console.WriteLine("//================================================================");
                    Console.Write("\tНе число, ошибка в {0} символе, введите заного:    ", index + 1);
                }
                string otvet = perevodVdvoichku(n1, p1);
                Console.WriteLine("Число {0}, в 10-ичной системе счисления, при переводе в {1}-ичную выглядит так: {2}\n\n", n1, p1, otvet);
                Console.Write("Нажмите любую клавишу, чтобы начать с начала:   ");
                Console.ReadKey();
            }
        }
        static bool Chislo(string str, ref int index)
        {
            byte count = 0;
            if (str.Length == index) return false;
            if (str.IndexOf('-') == 0) index++;
            while (str.Length > index)
            {
                if (str[index] == '.' || str[index] == ',')
                {
                    count++;
                    if (count > 1) return false;
                    index++;
                    continue;
                }
                if (Char.IsDigit(str[index]) == false) return false;
                index++;
            }
            return true;
        }
    }
}
