//The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719 are themselves prime.
// There are thirteen such primes below 100: 2,3,5,7,11,13,17,31,37,71,73,79, and 97.
// How many circular primes are there below one million?

namespace euler_thirtyfive
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> primes = getPrimes(1000000);
            int count = 0;
            foreach( int num in primes)
            {
                string primeString = Convert.ToString(num);
                bool isCircular = true;
                List<int> circle = new List<int>();
                circle.Add(num);
                int digits = primeString.Length;
                for (int i = 1; i < digits; i++)
                {    
                    string rotatedPrimeString = "";
                    for (int j = 0; j < digits; j++)
                    {
                        rotatedPrimeString += primeString[(j + i) % digits];
                    }
                    int rotatedPrime = 0;
                    Int32.TryParse(rotatedPrimeString, out rotatedPrime);
                    if (primes.Contains(rotatedPrime))
                    {
                        circle.Add(rotatedPrime);
                    }
                    else 
                    {
                        isCircular = false;
                    }
                }
                if (isCircular)
                {
                    Console.WriteLine(primeString);
                    count += 1;
                }
            }
            Console.WriteLine("total circular primes:" + count);
        }

        private static List<int> getPrimes(int n)
        {
            List<int> numbers = new List<int>();
            for (int i = 2; i < n; i++)
            {
                numbers.Add(i);
            }
            for (int i = 0; i < numbers.Count(); i++)
            {
                int newPrime = numbers[i];
                for (int j = i+1; j < numbers.Count(); j++)
                {
                    if (numbers[j] % newPrime == 0)
                    {
                        numbers.RemoveAt(j);
                    }
                }
            }
            return numbers;
        }
    }
}