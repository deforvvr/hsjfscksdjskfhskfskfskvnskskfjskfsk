using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Matrix
    {
        private int n;
        private int[,] mass;
        public Matrix() { }
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }
        public Matrix(int n)
        {
            this.n = n;
            mass = new int[this.n, this.n];
        }
        public int this[int i, int j]
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
        public void WriteMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                    mass[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public void ReadMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public static Matrix umnch(Matrix a, int ch)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    resMass[i, j] = a[i, j] * ch;
                }
            }
            return resMass;
        }
        public static Matrix umn(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
                for (int j = 0; j < b.N; j++)
                    for (int k = 0; k < b.N; k++)
                        resMass[i, j] += a[i, k] * b[k, j];

            return resMass;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Matrix.umn(a, b);
        }
        public static Matrix operator *(Matrix a, int b)
        {
            return Matrix.umnch(a, b);
        }
        public static Matrix razn(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMass;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.razn(a, b);
        }
        public static Matrix Sum(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMass;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Sum(a, b);
        }
    }
    class MainProgram
    {

        static void Main(string[] args)
        {

            

            Console.WriteLine("Введите размерность матриц:");
            int nn = Convert.ToInt32(Console.ReadLine());

            Matrix mass1 = new Matrix(nn);
            Matrix mass2 = new Matrix(nn);
            Matrix mass3 = new Matrix(nn);
            Matrix mass4 = new Matrix(nn);
            Matrix mass5 = new Matrix(nn);
            Matrix mass6 = new Matrix(nn);
            Matrix mass7 = new Matrix(nn);
            Matrix mass8 = new Matrix(nn);
            Matrix mass9 = new Matrix(nn);

            Console.WriteLine("Введите матрицу А:");
            mass1.WriteMat();

            Console.WriteLine("Введите матрицу B:");
            mass2.WriteMat();


            Boolean begin = true;
            string moveTo;

            while(begin)
            {
                Console.WriteLine("\nКакую операцию вы хотите выполнить?\nДля просмотра всех операций введите /?");

                moveTo = Console.ReadLine();
                moveTo = moveTo.ToLower();

                switch (moveTo)
                {
                    case "vivoda":
                        mass1.ReadMat();
                        break;

                    case "vivodb":
                        mass2.ReadMat();
                        break;

                    case "sumab":
                        mass4 = (mass1 + mass2);
                        mass4.ReadMat();
                        break;

                    case "aminusb":
                        mass6 = (mass1 - mass2);
                        mass6.ReadMat();
                        break;

                    case "bminusa":
                        mass9 = (mass2 - mass1);
                        mass9.ReadMat();
                        break;

                    case "umnab":
                        mass8 = (mass1 * mass2);
                        mass8.ReadMat();
                        break;

                    case "umnax":
                        int x = int.Parse(Console.ReadLine());
                        mass5 = (mass1 * x);
                        mass5.ReadMat();
                        break;

                    case "determinant":
                        if (nn == 2)
                        {
                            int determinant = (mass1[0, 0] * mass1[1, 1]) + (mass1[0, 0] * mass1[1, 1]);
                            Console.WriteLine(determinant);
                        }
                        else if (nn == 3) 
                        {
                            int determinant = (mass1[0, 0] * mass1[1, 1] * mass1[2, 2]) + (mass1[1, 0] * mass1[2, 1] * mass1[0, 2]) + (mass1[2, 0] * mass1[0, 1] * mass1[1, 2]);
                            Console.WriteLine(determinant);
                        }
                        else
                        {
                            Console.WriteLine("ERROR");
                        }
                        break;

                    case "/?":
                        Console.WriteLine("vivoda -- вывод матрицы А");
                        Console.WriteLine("vivodb -- вывод матрицы B");
                        Console.WriteLine("sumab -- сумма матриц А и В");
                        Console.WriteLine("aminusb -- вычитание матрицы В из матрицы А");
                        Console.WriteLine("bminusa -- вычитание матрицы А из матрицы В");
                        Console.WriteLine("umnab -- умножение матриц А и В");
                        Console.WriteLine("umnax -- умножение матрицы А на число");
                        Console.WriteLine("determinant -- определитель матрицы А");
                        break;

                    default:
                        begin = false; 
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
