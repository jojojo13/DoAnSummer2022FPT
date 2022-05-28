import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobTitleListPageComponent } from './job-title-list-page.component';

describe('JobTitleListPageComponent', () => {
  let component: JobTitleListPageComponent;
  let fixture: ComponentFixture<JobTitleListPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JobTitleListPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(JobTitleListPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
