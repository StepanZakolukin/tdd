using FluentAssertions;
using NUnit.Framework;
using System.Drawing;


namespace TagsCloudVisualization;


[TestFixture]
public class CircularCloudLayouterTests
{
    [Test]
    public void CircularCloudLayouter_CorrectInitialization_NoExceptions()
    {
        var createAConstructor = () => new CircularCloudLayouter(new Point(960, 540));

        createAConstructor
            .Should()
            .NotThrow();
    }

    [Test]
    public void PutNextRectangle_RandomSizes_MustBeTheRightSize()
    {
        var cloud = new CircularCloudLayouter(new Point(960, 540));
        var random = new Random();

        for (var i = 0; i < 50; i++)
        {
            var width = random.Next(30, 200);
            var actualSize = new Size(width, random.Next(width / 6, width / 3));

            var rectangle = cloud.PutNextRectangle(actualSize);

            actualSize
                .Should()
                .Be(rectangle.Size);
        }
    }

    [Test]
    public void PutNextRectangle_RandomSizes_ShouldNotIntersect()
    {
        var cloud = new CircularCloudLayouter(new Point(960, 540));
        var listRectangles = new List<Rectangle>();
        var random = new Random();
        
        for (int i = 0; i < 100; i++)
        {
            var width = random.Next(30, 200);

            var rectangle = cloud.PutNextRectangle(new(width, random.Next(width / 6, width / 3)));

            listRectangles.Any(rect => rect.IntersectsWith(rectangle))
                .Should()
                .BeFalse("Прямоугольники не должны пересекаться");

            listRectangles.Add(rectangle);
        }
    }
}
