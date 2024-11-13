using System.Drawing;

namespace TagsCloudVisualization;

internal interface CircularCloudLayouter
{
    CircularCloudLayouter(Point center);
    Rectangle PutNextRectangle(Size rectangleSize);
}
