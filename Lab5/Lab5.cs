using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab5
{
    public partial class Lab5 : Form
    {
        public Lab5()
        {
            InitializeComponent();
            PlotGraph();
        }

        private static Random _random = new Random();

        public static List<int[]> GenerateArrays()
        {
            List<int[]> arrays = new List<int[]>();
            for (int size = 10; size <= 100; size += 5)
            {
                int[] data = new int[size];
                for (int i = 0; i < size; i++)
                {
                    data[i] = _random.Next(-100, 100);
                }
                arrays.Add(data);
            }
            return arrays;
        }

        private void PlotGraph()
        {
            List<int[]> baseArrays = GenerateArrays();
            Series bubbleSeries = new Series("Bubble Sort") { ChartType = SeriesChartType.Line };
            Series shakerSeries = new Series("Shaker Sort") { ChartType = SeriesChartType.Line };
            Series combSeries = new Series("Comb Sort") { ChartType = SeriesChartType.Line };

            foreach (int[] baseArray in baseArrays)
            {
                int size = baseArray.Length;

                // Копируем массивы, чтобы избежать повторной сортировки одного и того же
                int[] bubbleArray = (int[])baseArray.Clone();
                int[] shakerArray = (int[])baseArray.Clone();
                int[] combArray = (int[])baseArray.Clone();

                ArrayDecorator<int> bubbleDecorator = new ArrayDecorator<int>(bubbleArray);
                Sorts.BubbleSort(bubbleDecorator);
                bubbleSeries.Points.AddXY(size, bubbleDecorator.OperatoinCount);

                ArrayDecorator<int> shakerDecorator = new ArrayDecorator<int>((int[])baseArray.Clone());
                Sorts.ShakerSort(shakerDecorator);
                shakerSeries.Points.AddXY(size, shakerDecorator.OperatoinCount);

                ArrayDecorator<int> combDecorator = new ArrayDecorator<int>((int[])baseArray.Clone());
                Sorts.CombSort(combDecorator);
                combSeries.Points.AddXY(size, combDecorator.OperatoinCount);
            }

            //chart1.Series.Add(bubbleSeries);
            //chart1.Series.Add(shakerSeries);
            chart1.Series.Add(combSeries);
        }


    }
}
