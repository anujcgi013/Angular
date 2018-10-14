import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector: "employee-count",
    templateUrl: "app/Employee/EmployeeCount.component.html",
    styleUrls: ["app/employee/employeeCount.component.css"]
})

export class EmployeeCountComponent {

    selectRadioButtonValue: string = "All";

    @Output()
    countRadioButtonSelectionChanged: EventEmitter<string> = new EventEmitter<string>();

    @Input()
    all: number;

    @Input()
    male: number;

    @Input()
    female: number;

    onRadioButtonSelectionChanged() {
        this.countRadioButtonSelectionChanged.emit(this.selectRadioButtonValue);
    }
} 