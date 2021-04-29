import { XYData } from './../chart-widget.model';
import { Component, Input, OnInit, SimpleChanges, } from '@angular/core';
import * as Highcharts from 'highcharts';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})

export class LineChartComponent implements OnInit {
  //@Input() public data: XYData = {dataPoints : [[5, 2], [6, 3], [8, 2]]};
  @Input()
  public chartTitle!: string;
  @Input()
  public data!: XYData;

  public Highcharts: typeof Highcharts = Highcharts;
  public chartOptions!: Highcharts.Options;

  ngOnInit(): void {
    console.log('line data = ' + this.data.dataPoints);
    this.chartOptions = {
      title:{text:this.chartTitle},
      series: [{
        data: this.data.dataPoints,
        type: 'line'
      }]
    }
  }
  
  ngOnChanges(changes: SimpleChanges) {
    console.log(changes.chartTitle.currentValue);
  }
};