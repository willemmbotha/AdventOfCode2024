//Part 1
string lines = File.ReadAllText(@"D:\Repos\AdventOfCode2024\Day3\data.txt");

// foreach (var line in lines)
// {
//
// }
var concatlines = string.Empty;

var enabled = true;
for (int i = 0; i < lines.Length; i++)
{
   if (i < lines.Length && lines[i] == 'd')
   {
      if (lines[i + 2] == 'n')
      {
         enabled = false;
      }else if (lines[i + 2] == '(')
      {
         enabled = true;
      }
   }
   if (enabled)
   {
      concatlines += lines[i];
   }
}

var test = concatlines.Split("mul(");
var total = 0;

foreach (var calc in test)
{

   var value2 = calc.Split(')');
   if (value2.Length > 0)
   {
      var values = value2[0].Split(',');
  
      if (values.Length > 1 && 
          values[0].All(char.IsDigit) && 
          values[1].All(char.IsDigit) 
          )
      {
         Int32.TryParse(values[0],  out var int1);
         Int32.TryParse(values[1],  out var int2);
         total += int1 * int2;
         Console.WriteLine($"{int1} * {int2} = {total}");
      }
 
   }
}

Console.WriteLine(total);