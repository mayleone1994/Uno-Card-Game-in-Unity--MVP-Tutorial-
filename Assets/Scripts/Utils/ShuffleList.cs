using System;
using System.Collections.Generic;

public static class ShuffleList
{
    private static readonly Random random = new();

    public static void Shuffle<T>(this IList<T> collection)
    {
        int count = collection.Count;

        for (int i = count - 1; i > 0; i--)
        {
            int randomIndex = random.Next(i + 1);

            (collection[i], collection[randomIndex]) = (collection[randomIndex], collection[i]);
        }
    }
}
