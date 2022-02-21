using static System.Console;

namespace twentytwo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
    Mark:   Write("Enter the n: ");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 0) throw new Exception("Error of innput data!");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                goto Mark;
            }
/**/        Func< object, int[]> func1 = new (CreateRandomArray); 
            Task< int[]> task1 = new (func1, n);

/**/        Func< Task<int[]>, int[]> func2 = new (ShowArray);
            Task< int[]> task2 = task1.ContinueWith(func2);

/**/        Func< Task<int[]>, int[]> func3 = new (MaxInt);
            Task< int[]> task3 = task2.ContinueWith<int[]>(func3);

/**/        Func< Task<int[]>, int[]> func4 = new (SumArray);
            Task< int[]> task4 = task3.ContinueWith(func4);

/**/        task1.Start();
            Console.ReadKey();
        }
        static int[] CreateRandomArray(object a)
        {
            int n = (int)a;
            int[] arr = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(-100, 100);
            }
            return arr;
        }
        static int[] ShowArray(Task<int[]> task)
        {
            int[] arr = task.Result;
            for (int i = 0; i < arr.Count(); i++)
            {
                Write($"{arr[i]} ");
            }
            Write("\n");
            return arr;
        }
        static int[] MaxInt(Task<int[]> task)
        {
            int[] arr = task.Result;
            int maxint  = arr[0];
            for (int i = 1; i < arr.Count(); i++)
            {
                if (arr[i] > maxint)
                {
                    maxint = arr[i];
                }
            }
            WriteLine($"MaxInt = {maxint}");
            return arr;
        }
        static int[] SumArray(Task<int[]> task)
        {
            int[] arr = task.Result;
            int sa = 0;
            for (int i = 0; i < arr.Count(); i++)
            {
                sa += arr[i];
            }
            WriteLine($"SumArray = {sa}");
            return arr;
        }
    }
}