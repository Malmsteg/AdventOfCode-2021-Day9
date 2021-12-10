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
            Console.Write(count);
            foreach(var item in points)
            {
                // if(item.Item1 == 0 && item.Item2== 0)
                // else if(item.Item1 == text.Length-1 && item.Item2 == 0)
                // else if(item.Item1 == 0 && item.Item1 == text[0].Length-1)
                // else if(item.Item1 == 0)
                // else if(item.Item1 == text.Length-1)
                // else if(item.Item2 == 0)
                // else if(item.Item2 == text[0].Length-1)

            }
        }
    }
}
