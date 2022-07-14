import { Component, Input } from '@angular/core';
import { IApod } from '../apod';

@Component({
  selector: 'apod-detail',
  templateUrl: './apod-detail.component.html',
  styleUrls: ['./apod-detail.component.css']
})
export class ApodDetailComponent {

  @Input() public pageTitle!: string;
  @Input() public apod!: IApod;
}
