using System;

public class Sorts
{

    internal static void BubbleSort<T>(ArrayDecorator<T> mas)
		where T : IComparable
	{
		for(int i = 0; i < mas.Length; i++)
		{
			for(int j = 0; j < mas.Length;  j++)
			{
				if(mas.CompareItems(mas[i], mas[j]) < 0)
				{
					T temp = mas[j];
					mas[j] = mas[i];
					mas[i] = temp;
				}
			}
		}	
	}

    internal static void BubbleSortOptimize<T>(ArrayDecorator<T> mas)
		where T:IComparable
	{
		for( int i = 0;i < mas.Length; i++)
		{
			for(int j = i+1; j < mas.Length; j++)
			{
				if (mas.CompareItems(mas[i], mas[j]) < 0)
				{
					T temp = mas[j];
					mas[j] = mas[i];
					mas[i] = temp;
				}
			}
		}
	}

    internal static void BubbleSortOptimizeOrdered<T>(ArrayDecorator<T> mas)
        where T : IComparable
	{
		for (int i = 0; i < mas.Length; i++)
		{
			bool flag = true;
			for (int j = i+1;j < mas.Length; j++)
			{
				if(mas.CompareItems(mas[j], mas[i]) < 0)
				{
					T temp = mas[j];
					mas[j] = mas[i];
					mas[i] = temp;
					flag = false;
				}
			}
			if (flag) return;
		}
	}

    internal static void ShakerSort(ArrayDecorator<int> array)
	{
		int leftEdge = 0;
		int rightEdge = array.Length - 1;
		while (leftEdge < rightEdge)
		{
			for( int i = rightEdge; i > leftEdge; i--)
			{
				if (array[i-1] > array[i])
				{
					int temp = array[i];
					array[i] = array[i-1];
					array[i-1] = temp;
				}
			}
			leftEdge++;
			for ( int i = leftEdge; i < rightEdge; i++)
			{
				if (array[i] > array[i+1])
				{
					int temp = array[i];
					array[i] = array[i + 1];
					array[i + 1] = temp;
				}	
			}
			rightEdge--;
		}
	}

	internal static void CombSort(ArrayDecorator<int> array)
	{
		double scale = 1.247;
		int delta = array.Length - 1;

		while( delta >= 1 )
		{
			for (int i = 0; i + delta < array.Length; i++ )
			{
				if (array[i] > array[i+delta])
				{
					int temp = array[i];
					array[i] = array[i+delta];
					array[i+delta] = temp;
				}
			}
			delta = (int)(delta/scale);
		}
	}
}
