using System.Collections;
class PrimeNumbers: IEnumerable
{
    const int max = 1000000;
    int[] possiblePrimeNumers = new int[max];
    public PrimeNumbers()
    {
        for (int i = 0; i < max - 1; i++)
        {
            possiblePrimeNumers[i] = i + 1;
        }
        // Here I set every i-th element to 0, in order to have only prime numbers
        // possiblePrimeNumers will be [1, 2, 3, 0, 5, 0, 7, 0, 9, 0, 11, 0, 13, 0, 15, 0, 17, 0, 19, 0, 21, 0 ...  ] when first inner loop will be completed 
        // [1, 2, 3, 0, 5, 0, 7, 0, 0, 0, 11, 0, 13, 0, 0, 0, 17, 0, 19, 0, 0, 0 ...  ] when second inner loop will be completed and so on
        for (int i = 2; i < max; i++)
        {
            for (int j = 2 * i - 1; j < max; j += i)
            {
                possiblePrimeNumers[j] = 0;
            }
        }
        possiblePrimeNumers[0] = 0;
    }
    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < max; i++)
        {
            if (possiblePrimeNumers[i] != 0)
            {
                yield return possiblePrimeNumers[i];
            }
        }
    }
}