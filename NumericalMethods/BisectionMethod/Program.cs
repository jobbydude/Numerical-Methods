using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace BisectionMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double xl;  //Lower estimate
            double xu;  //Upper estimate
            double xr;  //Initial estimate of the root
            double xn = 0;  //New estimate of the root
            double im;  //Maximum iterations
            double es;  //Acceptable error %
            double ea = 0;
            int i;

            Console.WriteLine("Numerical Methods : Bisection Method\n");
            Console.WriteLine("Function: f(x)= (e^-x) - x");

            //Step 1
            Console.WriteLine("Step 1:\n[Choose lower xi and upper xu estimates for the roots, so that the \n" +
                "function changes sign over the interval. This can be checked by\nensuring that " +
                "f(xi)f(xu) < 0]");
            Console.WriteLine();


            while (true)
            {
                Console.Write("Lower estimate xl = ");
                xl = Convert.ToDouble(Console.ReadLine());
                Console.Write("Lower estimate xu = ");
                xu = Convert.ToDouble(Console.ReadLine());
                Console.Write("Maximum iterations = ");

                if (fx(xl) * fx(xu) < 0)
                {
                    im = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Acceptable error = ");
                    es = Convert.ToDouble(Console.ReadLine());
                    //Apply exception handling?
                    Console.WriteLine("Accept input values?\n[YES] CONTINUE\n[NO] BACK");
                    if (Console.ReadLine() == "YES")
                    {
                        break;
                    }
                    else if (Console.ReadLine() == "NO")
                    {
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("[Function does not change sign over interval [" + Convert.ToString(xl) + "," + Convert.ToString(xu) + "]\nUse applicable values.]");
                }
            }

            Console.WriteLine("[Break]");


            //ALGORITHM 
            //Evaluation
            xr = xc(xl, xu); //Initial estimate
            Console.WriteLine("Initial estimate Xr = " + xr);

            for (i = 1; i <= im; i++)
            {
                double aa = fx(xl) * fx(xr);
                if (aa == 0)
                {
                    Console.WriteLine("Exact root =" + xr);
                    break;
                }
                else if (aa < 0) //(-) negative
                {
                    xu = xr;
                    Console.WriteLine("Xl = " + xl);
                    Console.WriteLine("Xu = " + xu);
                }
                else if (aa > 0) //(+) positive
                {
                    xl = xr;
                    Console.WriteLine("Xl = " + xl);
                    Console.WriteLine("Xu = " + xu);
                }
                xn = xc(xl, xu); //new estimate
                Console.WriteLine("Xn = " + xn);

                ea = Abs((xn - xr) / xn) * 100; //error estimate
                Console.WriteLine("Error estimate = " + ea);
                if (ea < es)
                {
                    Console.WriteLine("Root Xr = " + xn);
                    Console.WriteLine("Error = " + ea + " %");
                    Console.WriteLine("Number of iterations = " + i);
                }
                xr = xn;
                Console.WriteLine();
            }



            //FUNCTIONS
            double fx(double xk)
            {
                //double x = -0.4 * Pow(xk, 2) + 2.2 * xk + 4.7;
                double x = Exp(-xk) - xk;
                return x;
            }

            double xc(double u, double l)
            {
                double xk = (l + u) / 2;
                return xk;
            }


            Console.ReadLine();
        }
    }
}
