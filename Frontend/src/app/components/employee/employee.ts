import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmployeeService } from '../../service/employee';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './employee.html',
  styleUrl: './employee.css'
})
export class EmployeeComponent implements OnInit {

  employees: any[] = [];

  employee = {
    empId: 0,
    empName: '',
    salary: 0,
    address: '',
    department: ''
  };

  constructor(
    private employeeService: EmployeeService,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.employeeService.getEmployees().subscribe({
      next: (data: any) => {

        console.log("API DATA:", data);

        this.employees = Array.isArray(data)
          ? data
          : data?.employees || data?.data || [];

        this.cd.detectChanges();
      },
      error: (err: any) => console.log(err)
    });
  }

  addEmployee(): void {
    this.employeeService.addEmployee(this.employee).subscribe({
      next: () => {
        this.loadEmployees();

        this.employee = {
          empId: 0,
          empName: '',
          salary: 0,
          address: '',
          department: ''
        };
      }
    });
  }

  deleteEmployee(empId: number): void {

  if (!confirm('Are you sure you want to delete this employee?')) {
    return;
  }

  this.employeeService.deleteEmployee(empId).subscribe({
    next: () => {

      alert('Employee deleted successfully');

      // reload table
      this.loadEmployees();
    },
    error: (err: any) => {
      console.log(err);
      alert('Error deleting employee');
    }
  });
}
}