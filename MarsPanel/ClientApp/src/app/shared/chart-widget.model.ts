export interface ChartData {
    title: string;
    value: number;
    color: string;
}

export interface ColumnChartData {
    categories: (Date | string)[];
    seriesData: SeriesData[];
    xAxis?: XAxis;
}

export interface LineChartData extends ColumnChartData {
    threshold: number;
}

export interface SeriesData {
    title: string;
    data: (DataPoint | number)[];
}

export interface DataPoint {
    x: number;
    y: number;
}

export interface XYData{
    dataPoints: ([number, number])[] ;
}

export interface XAxis {
    plotBands: PlotBands[];
}

export interface PlotBands {
    from: number;
    to: number;
    color: string;
}
