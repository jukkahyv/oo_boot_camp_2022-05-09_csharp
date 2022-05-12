using Exercises.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exercises.Tests.Unit
{
    public class NodeTest
    {
        [Fact] public void CanReach()
        {
            var a = "A".Node();
            var b = "B".Node().LinksTo(a);
            Assert.True(b.CanReach(a));
            Assert.False(a.CanReach(b));
        }

        [Fact] public void CanReachMultipleSteps()
        {
            var a = "A".Node();
            var b = "B".Node();
            var c = "C".Node();
            var d = "D".Node();
            var e = "E".Node();
            var f = "F".Node();
            b = b.LinksTo(a, c, f);
            c.LinksTo(d, e);
            d.LinksTo(e);

            Assert.True(b.CanReach(e));
            Assert.False(f.CanReach(b));
        }

        [Fact] public void CanReachCircular()
        {

        }
    }
}
