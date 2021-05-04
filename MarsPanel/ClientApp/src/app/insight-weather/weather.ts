import { DataPoint } from './../shared/chart-widget.model';
import { XYData } from "../shared/chart-widget.model";

export interface IPressure {
    pressure_timeseries_av : [number,number][],
    pressure_timeseries_ct : [number,number][],
    pressure_timeseries_mn : [number,number][],       
    pressure_timeseries_mx : [number,number][],
 }
