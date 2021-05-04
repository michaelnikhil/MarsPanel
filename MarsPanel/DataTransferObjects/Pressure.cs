using System.Collections.Generic;

namespace MarsPanel.DataTransferObjects{
    public class Pressure {

        public Dictionary<int,double> pressure_timeseries_av = new Dictionary<int,double>(){};
        public Dictionary<int,double> pressure_timeseries_ct = new Dictionary<int,double>(){};
        public Dictionary<int,double> pressure_timeseries_mn = new Dictionary<int,double>(){};
        public Dictionary<int,double> pressure_timeseries_mx = new Dictionary<int,double>(){};
    }
}