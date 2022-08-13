import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from '../store/state';
import * as fromActions from '../store/actions';
@Component({
  selector: 'apikey',
  templateUrl: './apikey.component.html',
  styleUrls: ['./apikey.component.css']
})
export class ApikeyComponent {

  key!: Observable<string>;
  
  constructor(
    private formBuilder: FormBuilder,private store: Store<AppState>
  ) {
    store.select(state => state.apikeyValue).subscribe(res => {
      this.key = res;
    });
  }

  checkoutForm = this.formBuilder.nonNullable.group({
    apikey: ['']
});  

  onSubmit(): void {
      var tt = this.checkoutForm.controls['apikey'].value;
      this.store.dispatch(fromActions.updateApiKey({key: tt}));
    }
}
