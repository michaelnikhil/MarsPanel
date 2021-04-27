import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsightWeatherComponent } from './insight-weather.component';

describe('InsightWeatherComponent', () => {
  let component: InsightWeatherComponent;
  let fixture: ComponentFixture<InsightWeatherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsightWeatherComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InsightWeatherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
