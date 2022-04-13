using System;

namespace Name
{
    class Program
    {
        struct MyFrac
        {
            public long nom, denom;
            public MyFrac(long nom_, long denom_)
            {
                long nsd = NSD(Math.Abs(nom_), Math.Abs(denom_));
                nom = nom_/nsd;
                denom = denom_/nsd;

                string f = ToString();
                Console.WriteLine(f);
            }
            static long NSD (long a, long b)
            {
                while (b > 0)
                {
                    long c = a % b;
                    a = b;
                    b = c;
                }
                return a;
            }
            public override string ToString()
            {
                return nom + "/" + denom;
            }
        }
        static string ToStringWithIntegerPart(MyFrac f1)
        {
            double a = f1.nom/f1.denom;
            int num = Convert.ToInt32(a);
            if (num != 0)
            {
                long nom = f1.nom - num * f1.denom;
                return num + "+" + nom + "/" + f1.denom;
            }
            return f1.nom + "/" + f1.denom;
        }
        static double DoubleValue(MyFrac f1)
        {
            double a = f1.nom, b = f1.denom;
            double d = a/b;
            return d;
        }
        static MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom,f1.denom * f2.denom);
        }
        static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom, f1.denom * f2.denom);
        }
        static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }
        static MyFrac Divide(MyFrac f1, MyFrac f2)

        {
            return new MyFrac(f1.nom*f2.denom,f1.denom*f2.nom);
        }
        static MyFrac CalcSum1(int n)
        {
            MyFrac res = new MyFrac(0, 1);
            for (int i = 1; i <= n; i++)
            {
                MyFrac add = new MyFrac(1, i*(i+1));
                res = Plus(res, add);
            }
            return res;
        }
        static MyFrac CalcSum2(int n)
        {
            //(1–1/4)*(1–1/9)*(1–1/16)*...*(1–1/n^2)
            MyFrac res = new MyFrac(3,4);
            for (int i = 3; i <= n; i++)
            {
                MyFrac add = new MyFrac(i*i-1,i*i);
                res = Multiply(res, add);
            }
            return res;
        }

        static void Main()
        {
            Console.WriteLine("Enter first fraction");
            MyFrac f1 = new MyFrac(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()));
            Console.WriteLine("Enter second fraction");
            MyFrac f2 = new MyFrac(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()));
            Console.WriteLine("Choose task");
            Console.WriteLine("ToStringWithIntegerPart - 1");
            Console.WriteLine("DoubleValue - 2");
            Console.WriteLine("Plus - 3");
            Console.WriteLine("Minus - 4");
            Console.WriteLine("Multiply - 5");
            Console.WriteLine("Divide - 6");
            Console.WriteLine("CalcSum1 - 7");
            Console.WriteLine("CalcSum2 - 8");
            Console.WriteLine();
            Console.WriteLine("Exit - 0");
            int a;
            do
            {
                a = Int32.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        ToStringWithIntegerPart(f1);
                        break;
                    case 2:
                        DoubleValue(f1);
                        break;
                    case 3:
                        Plus(f1, f2);
                        break;
                    case 4:
                        Minus(f1, f2);
                        break;
                    case 5:
                        Multiply(f1, f2);
                        break;
                    case 6:
                        Divide(f1, f2);
                        break;
                    case 7:
                        Console.WriteLine("Enter number");
                        int n1 = Int32.Parse(Console.ReadLine());
                        CalcSum1(n1);
                        break;
                    case 8:
                        Console.WriteLine("Enter number");
                        int n2 = Int32.Parse(Console.ReadLine());
                        CalcSum2(n2);
                        break;
                }
            }
            while (a != 0);
        }
    }
}
