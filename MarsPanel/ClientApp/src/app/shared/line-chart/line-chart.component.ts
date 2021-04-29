import { XYData } from './../chart-widget.model';
import { Component, Input, OnInit, } from '@angular/core';
import * as Highcharts from 'highcharts';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})

export class LineChartComponent implements OnInit {
  @Input() public data: XYData = {dataPoints : [[5, 2], [6, 3], [8, 2]]};
  //@Input() public data: XYData = {} as XYData;


  public Highcharts: typeof Highcharts = Highcharts;
  public chartOptions: Highcharts.Options = {
    series: [{
      data: this.data.dataPoints,
      type: 'line'
    }]
  }

  ngOnInit(): void {
    console.log('line data = ' + this.data.dataPoints);
  }

};
