import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector: "employee-count",
    templateUrl: "app/Employee/EmployeeCount.component.html",
    styleUrls: ["app/employee/employeeCount.component.css"]
})

export class EmployeeCountComponent {

    selectedRadioButtonValue: string = "All";

    @Output()
    countRadioButtonSelectionChanged = new EventEmitter<string>();

    @Input()
    all: number;

    @Input()
    male: number;

    @Input()
    female: number;

    onRadioButtonSelectionChanged() {
        this.countRadioButtonSelectionChanged.emit(this.selectedRadioButtonValue);
        console.log(this.selectedRadioButtonValue);
    }
} 