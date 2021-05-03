using System.Collections.Generic;

namespace MarsPanel.DataTransferObjects{
    public class Pressure {

        public List<(int,double)> pressure_timeseries_av = new List<(int, double)>{};
        public List<(int,double)> pressure_timeseries_ct = new List<(int, double)>{};
        public List<(int,double)> pressure_timeseries_mn = new List<(int, double)>{};
        public List<(int,double)> pressure_timeseries_mx = new List<(int, double)>{};
    }
}