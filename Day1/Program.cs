//Part 1
// string[] lines = File.ReadAllLines(@"D:\Repos\AdventOfCode2024\Day1\data.txt");
// var leftList = new List<string>();
// var rightList = new List<string>();
// foreach (var line in lines)
// {
//     var numbers = line.Split(' ')
//         .Where(x => !string.IsNullOrEmpty(x))
//         .ToList();
//     leftList.Add(numbers[0]);
//     rightList.Add(numbers[1]);
// }
//
// leftList = leftList.OrderDescending().ToList();
// rightList = rightList.OrderDescending().ToList();
//
//
// var count = 0;
// for (int i = 0; i < leftList.Count; i++)
// {
//     count += Math.Abs(Int32.Parse(leftList[i]) - Int32.Parse(rightList[i]));
// }
//
// Console.WriteLine($"Output: {count}");

// Part 2
string[] lines = File.ReadAllLines(@"D:\Repos\AdventOfCode2024\Day1\data.txt");
var leftList = new List<string>();
var rightList = new List<string>();
foreach (var line in lines)
{
    var numbers = line.Split(' ')
        .Where(x => !string.IsNullOrEmpty(x))
        .ToList();
    leftList.Add(numbers[0]);
    rightList.Add(numbers[1]);
}

leftList = leftList.OrderDescending().ToList();
rightList = rightList.OrderDescending().ToList();


var count = 0;
for (int i = 0; i < leftList.Count; i++)
{
    var noOf = rightList.Count(x => x == leftList[i]);
    count += Int32.Parse(leftList[i]) * noOf;
}

Console.WriteLine($"Output: {count}");