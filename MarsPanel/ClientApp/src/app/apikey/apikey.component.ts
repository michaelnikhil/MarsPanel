import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'apikey',
  templateUrl: './apikey.component.html',
  styleUrls: ['./apikey.component.css']
})
export class ApikeyComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
  ) {}

  checkoutForm = this.formBuilder.group({
    apikey: ''
  });  
  ngOnInit(): void {
  }
  onSubmit(): void {
    // Process checkout data here

    console.log(this.checkoutForm.value);
  }
}
