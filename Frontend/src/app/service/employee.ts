import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environments';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getEmployees() {
    return this.http.get(
      `${this.apiUrl}/getemployees`
    );
  }

  addEmployee(employee: any) {
    return this.http.post(
      `${this.apiUrl}/addemployee`,
      employee
    );
  }

  deleteEmployee(empId: number) {
    return this.http.delete(
      `${this.apiUrl}/deleteemployee/${empId}`
    );
  }
}