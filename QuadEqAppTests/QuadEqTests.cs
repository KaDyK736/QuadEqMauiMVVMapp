using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadEqAppTests
{
    public class QuadEqTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void TestOneX()
        {
            QuadEquation eq = new QuadEquation(1, 2, 1);
            var X = eq.Solve();
            Assert.That(X.Count, Is.EqualTo(1));
            Assert.That(X[0], Is.EqualTo(-1));
        }

        [Test]
        public void TestTwoXs()
        {
            QuadEquation eq = new QuadEquation(2, 3, 1);
            var X = eq.Solve();
            Assert.That(X.Count, Is.EqualTo(2));
            Assert.That(X[0], Is.EqualTo(-0.5));
            Assert.That(X[1], Is.EqualTo(-1));
        }

        [Test]
        public void TestZeroXs()
        {
            QuadEquation eq = new QuadEquation(3, 1, 1);
            var X = eq.Solve();
            Assert.That(X.Count, Is.EqualTo(0));
        }
    }
}

