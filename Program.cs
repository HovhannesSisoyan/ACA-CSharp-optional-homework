using System;
using System.Collections;

public class Program
{
    public static IEnumerable Power(int number, int exponent)
    {
        for (int i = 1; i <= exponent; i++)
        {
            yield return (int)Math.Pow(number, i);
        }
    }
    public static void Main(string[] args)
    {

        BinarySearchTree binarySearchTree = new BinarySearchTree();
        binarySearchTree.Add(10);
        binarySearchTree.Add(5);
        binarySearchTree.Add(15);
        binarySearchTree.Add(4);
        binarySearchTree.Add(1);
        //  binarySearchTree.Delete(5);
        foreach (int item in binarySearchTree)
        {
            Console.WriteLine(item);   
        }

        PrimeNumbers primeNnumers = new PrimeNumbers();
        foreach (int item in primeNnumers)
        {
            Console.WriteLine(item);   
        }

        foreach (int item in Power(2, 20))
        {
            Console.WriteLine(item);
        }
    }
};

