using System.Drawing;

namespace TagsCloudVisualization.Task_2;

public class VisualizationCloudLayout
{
    public readonly int Width;
    public readonly int Height;
    public readonly Color BackgroundColor;
    public readonly Color[] RectanglePalette;

    public VisualizationCloudLayout(int width, int height, Color backgroundColor, IEnumerable<Color> rectanglePalette)
    {
        Width = width;
        Height = height;
        BackgroundColor = backgroundColor;
        RectanglePalette = rectanglePalette.ToArray();
    }

    public Bitmap CreateAnImage(CircularCloudLayouter cloudLayouter, int amountRectangles,
        int startWidthRectangles, int endWidthRectangles,
        int startHeightRectangles, int endHeightRectangles, IEnumerable<Rectangle> rectangles = null)
    {
        var image = new Bitmap(Width, Height);

        rectangles = rectangles ?? CloudLayout.GenerateCloudLayout(
            amountRectangles,
            startWidthRectangles, endWidthRectangles,
            startHeightRectangles, endHeightRectangles,
            cloudLayouter);
        var graphics = Graphics.FromImage(image);
        
        DrawCloudLayout(graphics, rectangles);

        return image;
    }

    private void DrawCloudLayout(Graphics graphics, IEnumerable<Rectangle> rectangles)
    {
        var random = new Random();

        graphics.FillRectangle(new SolidBrush(BackgroundColor), 0, 0, Width, Height);

        foreach (var rect in rectangles)
        {
            var color = RectanglePalette[random.Next(RectanglePalette.Length)];

            graphics.FillRectangle(new SolidBrush(color), rect);
            graphics.DrawRectangle(new Pen(Color.Black, 1), rect);
        }
    }
}
