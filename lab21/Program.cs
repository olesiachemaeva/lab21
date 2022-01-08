using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/*Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. 
    Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом. 
    Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз. 
    Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. 
    Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. 
    Садовники должны работать параллельно. 
    Создать многопоточное приложение, моделирующее работу садовников.*/

namespace lab21
{
    class Program
    {
        //const int n = 10;
        //const int m = 10;
        static int[,] path ;
        private static int m=10;
        private static int n=10;
        //static int[] path = new int[n] { 1, 2, 3, 1, 50, 6, 2, 1, 6, 2 };
        //static int[] path = new int[m] { 2, 6, 9, 2, 5, 3, 2, 2, 2, 5 };
        static void Main(string[] args)
        {
           
           
path = new int[n, m];


            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner2();
            for(int i=0;i<n;i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(path[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (path[i,j] >= 0)
                    {
                        int delay = path[i,j];
                        path[i,j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
        static void Gardner2()
        {
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = m - 1; j > 0; j--)
                {
                    if (path[i,j] >= 0)
                    {
                        int delay = path[i,j];
                        path[i,j] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }

    }
}
    
    


