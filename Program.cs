using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AdventOfCode_2021_Day9
{
    public static class Program
    {
        public static void Main()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = Path.Combine(currentDirectory, @"..\..\..\input.txt");
            string path = Path.GetFullPath(file);
            string[] text = File.ReadAllText(path).Replace("\r", "").Split("\n");
            int count = 0;
            List<Tuple<int,int>> points = new();

            for(int i = 0; i < text.Length; i++)
            {
                for(int j = 0; j < text[0].Length;j++)
                {
                    if(j == 0)
                    {
                        if(text[i][j+1]>text[i][j])
                        {
                            if(i == 0)
                            {
                                if(text[i+1][j]>text[i][j])
                                {
                                    count++;
                                    count+= text[i][j] - '0';
                                    points.Add(Tuple.Create(i,j));
                                }
                            }
                            else if(i == text.Length-1)
                            {
                                if(text[i-1][j]>text[i][j])
                                {
                                    count++;
                                    count+= text[i][j] - '0';
                                    points.Add(Tuple.Create(i,j));
                                    break;
                                }
                            }
                            else
                            {
                                if(text[i-1][j]>text[i][j]
                                && text[i+1][j]>text[i][j])
                                {
                                    count++;
                                    count+= text[i][j] - '0';
                                    points.Add(Tuple.Create(i,j));
                                }
                            }
                        }
                    }
                    else if(j == text[0].Length-1)
                    {
                        if(text[i][j-1]>text[i][j])
                        {
                            if(i == 0)
                            {
                                if(text[i+1][j]>text[i][j])
                                {
                                    count++;
                                    count+= text[i][j] - '0';
                                    points.Add(Tuple.Create(i,j));
                                }
                            }
                            else if(i == text.Length-1)
                            {
                                if(text[i-1][j]>text[i][j])
                                {
                                    count++;
                                    count+= text[i][j] - '0';
                                    points.Add(Tuple.Create(i,j));
                                    break;
                                }
                            }
                            else
                            {
                                if(text[i-1][j]>text[i][j]
                                && text[i+1][j]>text[i][j])
                                {
                                    count++;
                                    count+= text[i][j] - '0';
                                    points.Add(Tuple.Create(i,j));
                                }
                            }
                        }
                    }
                    else
                    {
                        if(text[i][j-1]>text[i][j] && text[i][j+1]>text[i][j])
                        {
                            if(i == 0)
                            {
                                if(text[i+1][j]>text[i][j])
                                {
                                    count++;
                                    count+= text[i][j] - '0';
                                    points.Add(Tuple.Create(i,j));
                                }
                            }
                            else if(i == text.Length-1)
                            {
                                if(text[i-1][j]>text[i][j])
                                {
                                    count++;
                                    count+= text[i][j] - '0';
                                    points.Add(Tuple.Create(i,j));
                                }
                            }
                            else
                            {
                                if(text[i-1][j]>text[i][j]
                                && text[i+1][j]>text[i][j])
                                {
                                    count++;
                                    count+= text[i][j] - '0';
                                    points.Add(Tuple.Create(i,j));
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count);
            int[] basins = new int[3];
            foreach(var item in points)
            {
                HashSet<Tuple<int,int>> point = new();
                point.Add(Tuple.Create(item.Item1,item.Item2));
                int basinCount = CountBasins(item.Item1,item.Item2,text, point).Count;

                if(basinCount > basins[0])
                {
                    basins[2] = basins[1];
                    basins[1] = basins[0];
                    basins[0] = basinCount;
                }
                else if(basinCount > basins[1])
                {
                    basins[2] = basins[1];
                    basins[1] = basinCount;
                }
                else if(basinCount > basins[2])
                {
                    basins[2] = basinCount;
                }
            }
            Console.WriteLine(basins[2] * basins[1] * basins[0]);
        }
        public static HashSet<Tuple<int,int>> CountBasins(int y, int x, string[] arr, HashSet<Tuple<int,int>> previousPoints)
        {
            HashSet<Tuple<int,int>> result = new();
            result.Add(Tuple.Create(x,y));

            if(x + 1 < arr[0].Length && arr[y][x+1] != '9' && previousPoints.Add(Tuple.Create(y,x+1)))
            {
                foreach(var item in CountBasins(y,x+1,arr,previousPoints))
                {
                    result.Add(item);
                }
            }
            if(x - 1 >= 0 && arr[y][x-1] != '9' && previousPoints.Add(Tuple.Create(y,x-1)))
            {
                foreach(var item in CountBasins(y,x-1,arr, previousPoints))
                {
                    result.Add(item);
                }
            }
            if(y + 1 < arr.Length && arr[y+1][x] != '9' && previousPoints.Add(Tuple.Create(y+1,x)))
            {
                foreach(var item in CountBasins(y+1,x,arr, previousPoints))
                {
                    result.Add(item);
                }
            }
            if(y - 1 >= 0 && arr[y-1][x] != '9'&& previousPoints.Add(Tuple.Create(y-1,x)))
            {
                foreach(var item in CountBasins(y-1,x,arr, previousPoints))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
