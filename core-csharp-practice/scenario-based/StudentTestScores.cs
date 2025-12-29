/*. Scenario: Develop a program to manage student test scores. The program should:
 ● Store the scores of n students in an array.
 ● Calculate and display the average score.
 ● Find and display the highest and lowest scores.
 ● Identify and display the scores above the average.
 ● Handle invalid input like negative scores or non-numeric input.
 */

using System;

public class StudentTestScores{
      public static float CalculateAverage(int[] scores){
            int sum = 0;
            for(int i=0;i<scores.Length;i++){
                  sum += scores[i];
            }
            return (float)sum / scores.Length;
      }

      public static int highestScore(int[] scores){
            int highest = scores[0];
            for(int i=1;i<scores.Length;i++){
                  if(scores[i] > highest){
                        highest = scores[i];
                  }
            }
            return highest;
      }

      public static int lowestScore(int[] scores){
            int lowest = scores[0];
            for(int i=1;i<scores.Length;i++){
                  if(scores[i] < lowest){
                        lowest = scores[i];
                  }
            }
            return lowest;
      }

      public static void ScoresAboveAverage(int[] scores, float average){
            Console.WriteLine("Scores above average:");
            for(int i=0;i<scores.Length;i++){
                  if(scores[i] > average){
                        Console.WriteLine(scores[i]);
                  }
            }     
      }

      public static void Main(string[] args){
            Console.WriteLine("Enter the number of students:");
            int n=Convert.ToInt32(Console.ReadLine());
            if(n<0){
                  Console.WriteLine("Invalid input. Number of students cannot be negative.");
                  return;
            }
            int[] scores = new int[n];
            for(int i=0;i<n;i++){
                  Console.WriteLine($"Enter score for student {i+1}:");
                  int score;
                  if(!int.TryParse(Console.ReadLine(), out score) || score < 0){
                        Console.WriteLine("Invalid input. Score cannot be negative.");
                        i--;
                        continue;
                  }
                  scores[i] = score;
            }

            float average = CalculateAverage(scores);
            int highest = highestScore(scores);
            int lowest = lowestScore(scores);

            Console.WriteLine($"Average Score: {average}");
            Console.WriteLine($"Highest Score: {highest}");
            Console.WriteLine($"Lowest Score: {lowest}");
            ScoresAboveAverage(scores, average);
      }
}