import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MojeKarteComponent } from './moje-karte.component';

describe('MojeKarteComponent', () => {
  let component: MojeKarteComponent;
  let fixture: ComponentFixture<MojeKarteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MojeKarteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MojeKarteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
