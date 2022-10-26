using System;

namespace lp5_1
{
    class MyMatrix
    {
        int n;
        int m;
        int[,] mass;
        public MyMatrix(int n, int m)//конструктор
        {
            this.n = n;
            this.m = m;
            mass = new int[this.n, this.m];
        }
        public int this[int i, int j]//индекстатор
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }
        public MyMatrix(int n, int m, int min, int max)//консруктор
        {
            this.n = n;
            this.m = m;
            mass = new int[this.n, this.m];
            Random rd = new Random(); //обращение к классу случайных величин
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mass[i, j] = rd.Next(min, max);
                }
            }
        }
        public void Show()//метод для печатания
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void Fill()//метод,перезаполнение матрицы случайными значениями
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mass[i, j] = rand.Next(1, 23);
                }
            }
        }
        public void ChangeSize(int nn, int mm)//метод для изменения строк и столбцов
        {
            Random r = new Random();
            int[,] mars = new int[nn, mm];
            for (int i = 0; i < nn; i++)//cтроки
            {
                if (i < n)
                {
                    for (int j = 0; j < mm; j++)
                    {
                        if (j < m)
                        {
                            mars[i, j] = mass[i, j];
                        }
                        else
                        {

                            mars[i, j] = r.Next(-100, 100);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < nn; j++)
                    {
                        mars[i, j] = r.Next(-100, 100);
                    }
                }
            }
            mass = new int[nn, mm];
            mass = mars;
            n = nn;
            m = mm;
        }

        public void ShowParialy(int[] first, int[] second)
        {
            for (int i = first[0]; i <= second[0]; i++)
            {
                if (i == first[0] && first[0] == second[0])
                {
                    for (int j = first[1]; j <= second[1]; ++j)
                    {
                        Console.WriteLine(mass[i, j] + "\t");

                    }
                    break;
                }
                else if (i == first[0])
                {
                    for (int j = first[1]; j < m; ++j)
                    {
                        Console.WriteLine(mass[i, j] + "\t");

                    }
                }
                else if (i < second[0])
                {
                    for (int j = 0; j < m; ++j)
                    {
                        Console.WriteLine(mass[i, j] + "\t");

                    }
                }
                else if (i == second[0])
                {
                    for (int j = 0; j <= second[1]; j++)
                    {
                        Console.WriteLine(mass[i, j] + "\t");
                    }
                }

            }
            Console.WriteLine();
        }
    }
   
        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерзность матрицы A");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите диапазон");
            int min = Convert.ToInt32(Console.ReadLine());
            int max = Convert.ToInt32(Console.ReadLine());
            MyMatrix m1 = new MyMatrix(n, m, min, max);
            m1.Show();
            Console.WriteLine("что-то новое");
            m1.Fill();
            m1.Show();
            Console.WriteLine("Изменим размер матрицы");
            int nn = Convert.ToInt32(Console.ReadLine());
            int mm = Convert.ToInt32(Console.ReadLine());
            m1.ChangeSize(nn,mm);
            m1.Show();
            int[] a = new int[] { 1, 2 };
            int[] b = new int[] { 2, 3 };
            Console.WriteLine("чаасть матрицы");
            m1.ShowParialy(a, b);
        }
    }
}
