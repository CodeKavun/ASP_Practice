using FibonacciDependecy_HW.Services.Abstract;

namespace FibonacciDependecy_HW.Services.Implementation
{
    public class FibonacciService : IFibonacci
    {
        public int CalculateFibonacci(int n)
        {
            int result = FibonacciNumber(n);
            return result;
        }

        private static int FibonacciNumber(int n)
        {
            if (n <= 1) return n;
            return FibonacciNumber(n - 1) + FibonacciNumber(n - 2);
        }
    }
}
