import { Component } from '@angular/core';
import { EmployeeComponent } from './components/employee/employee';

@Component({
  selector: 'app-root',
  imports: [EmployeeComponent],
  template: `<app-employee></app-employee>`
})
export class App {}