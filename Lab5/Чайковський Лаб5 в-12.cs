using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введiть кiлькiсть стовпцiв i рядкiв: ");
            int n = Convert.ToInt32(Console.ReadLine());
            var tsmatrix = new TSMatrix(n);
            tsmatrix.InputTSMatrix();
            Console.WriteLine($"Максимальне число: {tsmatrix.GetMax()}");
            Console.WriteLine($"Мiнiмальне число: {tsmatrix.GetMin()}");
            Console.WriteLine(tsmatrix);
            Console.ReadLine();
        }
    }


    class TSMatrix
    {
        private int _n;
        private double[,] _matrix;

        public TSMatrix(int n, double[,] matrix)
        {
            _n = n;
            _matrix = matrix;
        }
        public TSMatrix(int n)
        {
            _n = n;
            _matrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    _matrix[i, j] = 0;
                }
            }
        }
        public TSMatrix()
        {
            _n = 2;
            _matrix = new double[2, 2];
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    _matrix[i, j] = 0;
                }
            }
        }
        public TSMatrix(TSMatrix f)
        {
            _n = f._n;
            _matrix = f._matrix;
        }

        public double[,] ActMatrix
        {
            get
            {
                return _matrix;
            }
            set
            {
                _matrix = value;
            }
        }
        public int N
        {
            get
            {
                return _n;
            }
            set
            {
                _n = value;
            }
        }

        public void InputTSMatrix()
        {
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    Console.Write($"елемент {i + 1} {j + 1} : ");
                    _matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public double GetMax()
        {
            double max = _matrix[0, 0];
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    if (max < _matrix[i, j])
                    {
                        max = _matrix[i, j];
                    }
                }
            }
            return max;
        }

        public double GetMin()
        {
            double min = _matrix[0, 0];
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    if (min > _matrix[i, j])
                    {
                        min = _matrix[i, j];
                    }
                }
            }
            return min;

        }
        public override string ToString()
        {
            string _stringMatrix = "";
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    _stringMatrix += Convert.ToString(_matrix[i, j]) + " ";
                }
                _stringMatrix += "\n";
            }
            return string.Format($"Kiлькiсть рядкiв i стовцпiв : {_n} \n Матриця: \n{_stringMatrix}");
        }
    }

    class TOpMatrix : TSMatrix
    {
        public static TOpMatrix operator +(TOpMatrix k1, TOpMatrix k2)
        {
            for (int i = 0; i < k1.N; i++)
            {
                for (int j = 0; j < k1.N; j++)
                {
                    k1.ActMatrix[i, j] += k2.ActMatrix[i, j];
                }
            }
            return k1;
        }
        public static TOpMatrix operator -(TOpMatrix k1, TOpMatrix k2)
        {
            for (int i = 0; i < k1.N; i++)
            {
                for (int j = 0; j < k1.N; j++)
                {
                    k1.ActMatrix[i, j] -= k2.ActMatrix[i, j];
                }
            }
            return k1;
        }
        public static TOpMatrix operator *(TOpMatrix k1, TOpMatrix k2)
        {
            for (int i = 0; i < k1.N; i++)
            {
                for (int j = 0; j < k1.N; j++)
                {
                    k1.ActMatrix[i, j] *= k2.ActMatrix[i, j];
                }
            }
            return k1;
        }
    }
}

