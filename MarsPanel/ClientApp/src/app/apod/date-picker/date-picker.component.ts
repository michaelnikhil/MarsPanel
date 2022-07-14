import { Component, EventEmitter, Output } from '@angular/core';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import * as moment from 'moment';
@Component({
  selector: 'date-picker',
  templateUrl: './date-picker.component.html',
  styleUrls: ['./date-picker.component.css']
})
export class DatePickerComponent   {
  @Output() public selectedDate = new EventEmitter<string>();
  format = 'DD  HH:mm:ss';

  onDateSelected(event: MatDatepickerInputEvent<Date>) {
    if (event.value) {
      const dateConvert = moment(new Date(event.value.toString())).format('YYYY-MM-DD');
      this.selectedDate.emit(dateConvert);
    }
  }
}
