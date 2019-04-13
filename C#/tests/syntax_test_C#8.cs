/// SYNTAX TEST "Packages/C#/C#.sublime-syntax"

// https://devblogs.microsoft.com/dotnet/do-more-with-patterns-in-c-8-0/
// https://devblogs.microsoft.com/dotnet/take-c-8-0-for-a-spin/
// https://devblogs.microsoft.com/dotnet/building-c-8-0/

Index i1 = 3;  // number 3 from beginning
Index i2 = ^4; // number 4 from end
int[] a = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
Console.WriteLine($"{a[i1]}, {a[i2]}"); // "3, 6"
var slice = a[i1..i2]; // { 3, 4, 5 }

foreach (var name in names[1..^1]) {}

interface ILogger
{
    void Log(LogLevel level, string message);
    void Log(Exception ex) => Log(LogLevel.Error, ex.ToString()); // New overload
}
 
class ConsoleLogger : ILogger
{
    public void Log(LogLevel level, string message) { ... }
    // Log(Exception) gets default implementation
}
	
IEnumerable<string> GetEnrollees()
{
    foreach (var p in People)
    {
        if (p is Student { Graduated: false, Name: string name }) yield return name;
    }
}


var area = figure switch 
{
    Line _      => 0,
    Rectangle r => r.Width * r.Height,
    Circle c    => Math.PI * c.Radius * c.Radius,
    _           => throw new UnknownFigureException(figure)
};

Point[] ps = { new (1, 4), new (3,-2), new (9, 5) }; // all Points

// await foreach (var name in GetNamesAsync())

// https://docs.microsoft.com/en-us/dotnet/csharp/write-safe-efficient-code
public struct Point3D
{
    private static Point3D origin = new Point3D(0,0,0);

    public static ref readonly Point3D Origin => ref origin;

    // other members removed for space
    
    private static double CalculateDistance(in Point3D point1, in Point3D point2)
    {
        double xDifference = point1.X - point2.X;
        double yDifference = point1.Y - point2.Y;
        double zDifference = point1.Z - point2.Z;

        return Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
    }
}

var originValue = Point3D.Origin;
ref readonly var originReference = ref Point3D.Origin;
