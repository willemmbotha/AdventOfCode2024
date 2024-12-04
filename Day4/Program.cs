//Part 1

using System.Text.RegularExpressions;

string[] lines = File.ReadAllLines(@"D:\Repos\AdventOfCode2024\Day4\data.txt");

var counter = 0;

//Horizontal
for (int i = 0; i < lines.Length; i++)
{
    counter += Regex.Matches(lines[i], "XMAS").Count;
    counter += Regex.Matches(lines[i], "SAMX").Count;
}


//Vertical
for (int i = 0; i < lines.Length; i++)
{
    for (int j = 0; j < lines[i].Length; j++)
    {
        var verticalLine = string.Empty;
        for (int k = 0; k < lines.Length; k++)
        {
            verticalLine += lines[k][j].ToString();
        }
        counter += Regex.Matches(verticalLine, "XMAS").Count;
        counter += Regex.Matches(verticalLine, "SAMX").Count;
    }
}

//Diaganol
for (int i = 0; i < lines.Length; i++) //Row
{
    for (int j = 0; j < lines[i].Length; j++) //Col
    {
        var index = 0;
        var diagonalLine = string.Empty;
        var endOfGrid = true;
        while (endOfGrid)
        {
            diagonalLine += lines[j][index].ToString();

            if (index + 1 == lines[0].Length)
            {
                endOfGrid = false;
            }
            index++;
        }
        
        counter += Regex.Matches(diagonalLine, "XMAS").Count;
        counter += Regex.Matches(diagonalLine, "SAMX").Count;
    }
}


Console.WriteLine(counter);

public class LineEnumerator
{
    int dx, dy, dz;
    public LineEnumerator(int dx, int dy, int dz)
    {
        this.dx = dx;
        this.dy = dy;
        this.dz = dz;
    }
    public IEnumerable<bool> GetLine(bool[, ,] arr, int x0, int y0, int z0)
    {
        int xLength = arr.GetLength(0);
        int yLength = arr.GetLength(1);
        int zLength = arr.GetLength(2);

        while (x0 >= 0 && x0 < xLength &&
               y0 >= 0 && y0 < yLength &&
               z0 >= 0 && z0 < zLength)
        {
            yield return arr[x0, y0, z0];
            x0 += dx;
            y0 += dy;
            z0 += dz;
        }
    }
}