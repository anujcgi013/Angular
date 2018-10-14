import { Component } from '@angular/core'

@Component({
    selector: 'my-employee',
    templateUrl: 'app/Employee/employee.component.html',
    styleUrls: ['app/Employee/employee.component.css']

})

export class EmployeeComponent {
    firstName: string = "Anuj";
    lastName: string = "Yadav";
    gender: string = "Male";
    age: number = 25;
    showDetails: boolean = false

    toggleDetails():void {
        this.showDetails = !this.showDetails;
    }
}