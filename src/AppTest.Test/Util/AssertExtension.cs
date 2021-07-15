using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppTest.Test.Util
{
    public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException expection, string message)
        {
            if (expection.Message == message)
                Assert.True(true);
            else
                Assert.False(true, $"Await for message '{message}'");
        }
    }
}
