using System;
using Xunit;

namespace MarsPanel.Tests.Services
{
    public class ApodDeserializeTests
    {
        [Fact]
        public void Test1()
        {
            public string input_json = "{\"date\":\"2021-04-23\",\"explanation\":\"Recorded during 2017, timelapse sequences from the International Space Station are compiled in this serene video of planet Earth at Night. Fans of low Earth orbit can start by enjoying the view as green and red aurora borealis slather up the sky. The night scene tracks from northwest to southeast across North America, toward the Gulf of Mexico and the Florida coast. A second sequence follows European city lights, crosses the Mediterranean Sea, and passes over a bright Nile river in northern Africa. Seen from the orbital outpost, erratic flashes of lightning appear in thunder storms below and stars rise above the planet's curved horizon through a faint atmospheric airglow. Of course, from home you can always check out the vital signs of Planet Earth Now.  Celebrate: Earth Day\",\"media_type\":\"video\",\"service_version\":\"v1\",\"title\":\"Flying Over the Earth at Night II\",\"url\":\"https://www.youtube.com/embed/zIqG42AD4Gw?rel=0\"}\n";
            
        }
    }
}