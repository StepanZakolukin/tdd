using System.Drawing;

namespace TagsCloudVisualization.Task_2;

public static class CloudLayout
{ 
    public static IEnumerable<Rectangle> GenerateCloudLayout(int amountRectangles,
        int startWidthRectangles, int endWidthRectangles,
        int startHeightRectangles, int endHeightRectangles,
        CircularCloudLayouter cloudLayouter)
        => GenerateRectangleSizes(amountRectangles,
            startWidthRectangles, endWidthRectangles,
            startHeightRectangles, endHeightRectangles)
            .Select(cloudLayouter.PutNextRectangle);

    private static IEnumerable<Size> GenerateRectangleSizes(
        int amountData,
        int startWidth, int endWidth,
        int startHeight, int endHeight)
    {
        var random = new Random();

        for (var i = 0; i < amountData; i++)
        {
            var width = random.Next(startWidth, endWidth + 1);
            var height = random.Next(startHeight, endHeight + 1);

            yield return new Size(width, height);
        }
    }
}
