using System.Drawing;
using TagsCloudVisualization.Task_2;


namespace TagsCloudVisualization;

internal class Program
{
    static void Main(string[] args)
    {
        var colors = new[] { Color.Red, Color.Green, Color.Brown, Color.Yellow, Color.Blue };

        var visual = new VisualizationCloudLayout(800, 600, Color.White, colors);

        visual.CreateAnImage(new Point(400, 300), 175, 30, 100, 5, 25)
            .Save("../../../../TagsCloudVisualization/Task 2/CentralСloud.png");

        visual.CreateAnImage(new Point(250, 150), 50, 30, 80, 5, 25)
            .Save("../../../../TagsCloudVisualization/Task 2/SmalСloud.png");
    }
}
