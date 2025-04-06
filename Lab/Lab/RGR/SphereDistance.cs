namespace Lab.RGR;

public class SphereDistance
{
    public void Main(string[] args)
    {
        string input = "fullPath/input7.txt";
        
        string[] lines = File.ReadAllLines(input);
        
        string[] city1 = lines[0].Split(' ');
        string[] city2 = lines[1].Split(' ');
        
        int R = int.Parse(lines[2]);
        
        double s1 = double.Parse(city1[0]);
        double d1 = double.Parse(city1[1]);
        double s2 = double.Parse(city2[0]);
        double d2 = double.Parse(city2[1]);

        double lat1 = s1 * Math.PI / 180;
        double lon1 = d1 * Math.PI / 180;
        double lat2 = s2 * Math.PI / 180;
        double lon2 = d2 * Math.PI / 180;

        double deltaLon = Math.Abs(lon1 - lon2);
        deltaLon = Math.Min(deltaLon, 2 * Math.PI - deltaLon);

        double centralAngle = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + 
                                        Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(deltaLon));

        double distance = R * centralAngle;

        double result = Math.Round(distance, 3, MidpointRounding.AwayFromZero);
        
        string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string outputPath = Path.Combine(projectDir, "sphere.txt");

        using (StreamWriter output = new StreamWriter(outputPath))
        {
            output.Write(result);
            output.Flush();
            output.Close();
        }
        
        Console.WriteLine(result);
    }
}