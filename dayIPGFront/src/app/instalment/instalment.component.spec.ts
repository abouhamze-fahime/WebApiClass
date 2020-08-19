import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InstalmentComponent } from './instalment.component';

describe('InstalmentComponent', () => {
  let component: InstalmentComponent;
  let fixture: ComponentFixture<InstalmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InstalmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstalmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
