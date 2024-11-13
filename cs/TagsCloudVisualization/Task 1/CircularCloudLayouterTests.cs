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
}
