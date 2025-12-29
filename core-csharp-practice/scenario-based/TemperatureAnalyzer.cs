/*Arrays – Weekly Temperature Analysis
Scenario: You have hourly temperature recordings for a full week stored in a 2D array (7 days × 24 hours).  
Task: Write a function that can:
 • Identify which day was the hottest and which was the coldest
 • Calculate the average temperature for each day
*/

using System;     

public class TemperatureAnalyzer{
    public static int HottestDay(float[,] temperatures){
      int hottestDayIndex = 0;
      float maxTemp = float.MinValue;

      for(int day=0;day<7;day++){
            float dailyMax = float.MinValue;
            for(int hour=0;hour<24;hour++){
                  if(temperatures[day,hour] > dailyMax){
                        dailyMax = temperatures[day,hour];
                  }
            }
            if(dailyMax > maxTemp){
                  maxTemp = dailyMax;
                  hottestDayIndex = day;
            }
      }
      return hottestDayIndex;
      }

      public static int ColdestDay(float[,] temperatures){
            int coldestDayIndex = 0;
            float minTemp = float.MaxValue;

            for(int day=0;day<7;day++){
                  float dailyMin = float.MaxValue;
                  for(int hour=0;hour<24;hour++){
                        if(temperatures[day,hour] < dailyMin){
                              dailyMin = temperatures[day,hour];
                        }
                  }
                  if(dailyMin < minTemp){
                        minTemp = dailyMin;
                        coldestDayIndex = day;
                  }
            }
            return coldestDayIndex;
      }

      public static float[] AverageTemperaturePerDay(float[,] temperatures){
            float[] averageTemps = new float[7];

            for(int day=0;day<7;day++){
                  float dailySum = 0;
                  for(int hour=0;hour<24;hour++){
                        dailySum += temperatures[day,hour];
                  }
                  averageTemps[day] = dailySum / 24;
            }
            return averageTemps;
      }
      public static void Main(string[] args){
            float[,] weeklyTemperatures = new float[7,24];
            Random rand = new Random();
            for(int day=0;day<7;day++){
                  for(int hour=0;hour<24;hour++){
                        weeklyTemperatures[day,hour] = (float)(rand.NextDouble()*60-10); 
                  }
            }

            int choice;
            do{
                  Console.WriteLine("\n=== Temperature Analyzer ===");
                  Console.WriteLine("1. Find Hottest Day");
                  Console.WriteLine("2. Find Coldest Day");
                  Console.WriteLine("3. Show Average Temperatures");
                  Console.WriteLine("4. Show All Analysis");
                  Console.WriteLine("0. Exit");
                  Console.Write("Enter choice: ");
                  choice = Convert.ToInt32(Console.ReadLine());

                  switch(choice){
                        case 1:
                              Console.WriteLine("Hottest Day: Day " + HottestDay(weeklyTemperatures));
                              break;
                        case 2:
                              Console.WriteLine("Coldest Day: Day " + ColdestDay(weeklyTemperatures));
                              break;
                        case 3:
                              float[] avgTemps = AverageTemperaturePerDay(weeklyTemperatures);
                              Console.WriteLine("Average Temperatures per Day:");
                              for(int i=0;i<7;i++){
                                    Console.WriteLine($"Day {i}: {avgTemps[i]:F2}°C");
                              }
                              break;
                        case 4:
                              Console.WriteLine("Hottest Day: Day " + HottestDay(weeklyTemperatures));
                              Console.WriteLine("Coldest Day: Day " + ColdestDay(weeklyTemperatures));
                              float[] averageTemperatures = AverageTemperaturePerDay(weeklyTemperatures);
                              Console.WriteLine("Average Temperatures per Day:");
                              for(int i=0;i<7;i++){
                                    Console.WriteLine($"Day {i}: {averageTemperatures[i]:F2}°C");
                              }
                              break;
                        case 0:
                              Console.WriteLine("Goodbye!");
                              break;
                        default:
                              Console.WriteLine("Invalid choice!");
                              break;
                  }
            } while(choice != 0);
      }
}