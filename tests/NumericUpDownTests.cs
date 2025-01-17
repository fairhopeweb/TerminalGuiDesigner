﻿namespace UnitTests;

[Category("Core")]
[TestFixture(typeof(int))]
[TestFixture(typeof(long))]
[TestFixture(typeof(double))]
[TestFixture(typeof(float))]
[TestFixture(typeof(decimal))]
public class NumericUpDownTests<T> : Tests
    where T : notnull
{
    
    [Test]
    [Category("Code Generation")]
    public void NumericUpDownPreserveValue()
    {
        T testValue = (T)Convert.ChangeType(1.25, typeof(T));
        using var backIn = RoundTrip<View, NumericUpDown<T>>( (d, v) =>
        {

            // Expected designable properties
            Assert.That(d.GetDesignableProperty("Text"), Is.Null);
            Assert.That(v.Text, Is.EqualTo("0"));
            Assert.That(v.GetActualText(),Is.EqualTo("0"));

            // Expected default properties when created by ViewFactory
            Assert.That(v.Width?.IsAuto(out _, out _, out _), Is.True);

            // Your test logic here
            v.Value = testValue;
            v.Increment = testValue;

        }, out _);

        // Assertions here
        Assert.That(backIn.Value,Is.EqualTo(testValue));
        Assert.That(backIn.Increment, Is.EqualTo(testValue));
    }
}

