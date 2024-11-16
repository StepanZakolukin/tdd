using System.Drawing;


namespace TagsCloudVisualization;

public class CircularCloudLayouter
{
    public int DistanceBetweenTurns { get; private set; }
    public int InitialRadiusOfTheSpiral { get; private set; }
    public double AngleOfRotationInRadians { get; private set; }
    public double AngleChangeStep { get; private set; }

    readonly LinkedList<Rectangle> cloudOfRectangles;

    public readonly Point Center;

    public CircularCloudLayouter(Point center)
    {
        Center = center;
        AngleChangeStep = 0.017;
        cloudOfRectangles = [];
        DistanceBetweenTurns = 30;
        InitialRadiusOfTheSpiral = 30;
    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        if (cloudOfRectangles.Count == 0)
            InitialRadiusOfTheSpiral = Math.Min(rectangleSize.Width, rectangleSize.Height) / 2;

        DistanceBetweenTurns = Math.Min(DistanceBetweenTurns,
                Math.Min(rectangleSize.Width, rectangleSize.Height) / 2);

        return ChooseTheLocationForTheRectangle(rectangleSize);
    }

    private Rectangle ChooseTheLocationForTheRectangle(Size rectangleSize)
    {
        var currentPoint = GetANewPoint();
        var rectangle = GetANewRectangle(currentPoint, rectangleSize);

        while (cloudOfRectangles.Any(rect => rect.IntersectsWith(rectangle)))
        {
            AngleOfRotationInRadians += AngleChangeStep;
            currentPoint = GetANewPoint();
            rectangle = GetANewRectangle(currentPoint, rectangleSize);
        }

        cloudOfRectangles.AddFirst(rectangle);
        return rectangle;
    }

    private Rectangle GetANewRectangle(Point centerPoint, Size rectangleSize) =>
        new(new(centerPoint.X - rectangleSize.Width / 2,
            centerPoint.Y - rectangleSize.Height / 2), rectangleSize);

    private Point GetANewPoint()
    {
        var coefficient = InitialRadiusOfTheSpiral + AngleOfRotationInRadians * DistanceBetweenTurns;
        var x = coefficient * Math.Cos(AngleOfRotationInRadians) + Center.X;
        var y = coefficient * Math.Sin(AngleOfRotationInRadians) + Center.Y;

        return new((int)x, (int)y);
    }
}
