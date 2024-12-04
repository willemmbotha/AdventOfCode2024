//Part 1

using System.Text.Json.Serialization;
using Newtonsoft.Json;

string[] lines = File.ReadAllLines(@"D:\Repos\AdventOfCode2024\Day2\data.txt");

 var count = 0;
 
 foreach (var report in lines)
 {
     var levels = report.Split(' ').ToList();

     var invalidCounter = 0;

     if (IsLevelsValid(levels.ToArray()))
     {
         count++;
         Console.WriteLine($"{JsonConvert.SerializeObject(report)} {JsonConvert.SerializeObject(levels)} Base Safe");
     }
     else
     {
         for (int i = 0; i < levels.Count; i++)
         {
             var temp = levels.ToList();
             temp.RemoveAt(i);

             var valid = IsLevelsValid(temp.ToArray());
             if (valid)
             {
                 Console.WriteLine($"{JsonConvert.SerializeObject(report)} {JsonConvert.SerializeObject(temp)} Safe");
                 count++;
                 break;
             }
         }
     }
    
 }
 
 //454
//436
 //531
 Console.WriteLine(count);

 bool IsLevelsValid(string[] strings)
 {
     var lastDirection = "";
     var valid = true;
     for (int i = 0; i < strings.Length; i++)
     {
         var direction = "";
        
         if(i +1 == strings.Length )
             continue;
         
         var difference = GetDif(int.Parse(strings[i]), int.Parse(strings[i + 1]));
         if (difference > 0)
         {
             direction = "increasing";

         }
         else
         {
             direction = "decreasing";

         }
         
         if (string.IsNullOrEmpty(lastDirection))
         {
             lastDirection = direction;
         }
         
         if (Math.Abs(difference) >= 1 && Math.Abs(difference) <= 3 && lastDirection == direction)
         {
             valid =  true;
         }
         else
         {
             return false;
         }
        
         lastDirection = direction;
     }

     return valid;

 }
 
 int GetDif(int a, int b)
 {
     if (b > a)
     {
         return b - a;

     }
     else
     {
         return (a - b) * -1;
     }
 }