import { Component } from '@angular/core';

@Component({
    selector: 'list-employee',
    templateUrl: 'app/Employee/employeeList.component.html',
    styleUrls: ['app/Employee/employeeList.component.css']
})
export class EmployeeListComponent {
    employees: any[];

    constructor() {
        this.employees = [
            { code: 'emp101', name: 'Anuj1', gender: 'Female', Salary: 44000 },
            { code: 'emp102', name: 'Anuj2', gender: 'Female', Salary: 42000 },
            { code: 'emp103', name: 'Anuj3', gender: 'Male', Salary: 43000 },
            { code: 'emp104', name: 'Anuj4', gender: 'Male', Salary: 45000 },
            { code: 'emp105', name: 'Anuj5', gender: 'Female', Salary: 46000 }
        ];
    }

    getAllEmployeeCount(): number {
        return this.employees.length;

    }

    getAllMaleEmployeeCount(): number {
        return this.employees.filter(x => x.gender === "Male").length;
    }

    getAllFemaleEmployeeCount(): number {
        return this.employees.filter(x => x.gender === "Female").length;
    }

    //getEmployees(): void {
    //    this.employees = [
    //        { code: 'emp101', name: 'Anuj1', gender: 'Male', Salary: 44000, dateOfBirth: '05/Jan/1990' },
    //        { code: 'emp102', name: 'Anuj2', gender: 'Male', Salary: 42000, dateOfBirth: '05/Jan/1991' },
    //        { code: 'emp103', name: 'Anuj3', gender: 'Male', Salary: 43000, dateOfBirth: '05/Jan/1992' },
    //        { code: 'emp104', name: 'Anuj4', gender: 'Male', Salary: 45000, dateOfBirth: '05/Jan/1993' },
    //        { code: 'emp105', name: 'Anuj5', gender: 'Male', Salary: 46000, dateOfBirth: '05/Jan/1994' }
    //    ];
    //}

    //trackbyEmpCode(index: number, employee: any): void {
    //    return employee.code
    //}



}