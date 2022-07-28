using System;
using System.Collections.Generic;

namespace MarsPanel.NasaOpenApi.Models
{
    public class JSO
    {
        public DateTime First_UTC;
        public DateTime Last_UTC;
        public int Month_ordinal;
        public string Northern_season;
        public Sensor pre;
        public Sensor at;
        public Sensor hws;
        public string Season;
        public string Southern_season;
        public WD WD;

    }

}
