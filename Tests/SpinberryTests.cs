using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettySlotAutomation.Tests
{
    public class SpinberryTests : BaseTest
    {

        [Test]
        public void SpinberryPageSucceededLoaded_When_NavigatingToHomePage()
        {
            SpinberryPage.Navigate();

            SpinberryPage.AcceptCookies();

            
        }
    }
}
