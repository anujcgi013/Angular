import { Component, OnInit } from '@angular/core';
import { IEmployee } from './Employee'
import { EmployeeService } from './employee.service'

@Component({
    selector: 'list-employee',
    templateUrl: 'app/Employee/employeeList.component.html',
    styleUrls: ['app/Employee/employeeList.component.css'],
    providers: [EmployeeService]
})
export class EmployeeListComponent implements OnInit {
    employees: IEmployee[];
    selectedEmployeeRadioButton: string = "All";
    statusMessage: string = "Loading Data, Please Wait....";

    constructor(private _employeeSerives: EmployeeService) {

    }

    ngOnInit(): void {
        this._employeeSerives.getEmployee()
            .subscribe((employeeData) => this.employees = employeeData,
                (error) => { this.statusMessage = "Error in service, please try again..." });
    }

    onEmployeeCountRadioButtonChange(selectedRadioButton: string): void {
        this.selectedEmployeeRadioButton = selectedRadioButton;
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