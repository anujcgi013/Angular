"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var employee_service_1 = require("./employee.service");
var EmployeeListComponent = /** @class */ (function () {
    function EmployeeListComponent(_employeeSerives) {
        this._employeeSerives = _employeeSerives;
        this.selectedEmployeeRadioButton = "All";
        this.statusMessage = "Loading Data, Please Wait....";
    }
    EmployeeListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._employeeSerives.getEmployee()
            .subscribe(function (employeeData) { return _this.employees = employeeData; }, function (error) { _this.statusMessage = "Error in service, please try again..."; });
    };
    EmployeeListComponent.prototype.onEmployeeCountRadioButtonChange = function (selectedRadioButton) {
        this.selectedEmployeeRadioButton = selectedRadioButton;
    };
    EmployeeListComponent.prototype.getAllEmployeeCount = function () {
        return this.employees.length;
    };
    EmployeeListComponent.prototype.getAllMaleEmployeeCount = function () {
        return this.employees.filter(function (x) { return x.gender === "Male"; }).length;
    };
    EmployeeListComponent.prototype.getAllFemaleEmployeeCount = function () {
        return this.employees.filter(function (x) { return x.gender === "Female"; }).length;
    };
    EmployeeListComponent = __decorate([
        core_1.Component({
            selector: 'list-employee',
            templateUrl: 'app/Employee/employeeList.component.html',
            styleUrls: ['app/Employee/employeeList.component.css'],
            providers: [employee_service_1.EmployeeService]
        }),
        __metadata("design:paramtypes", [employee_service_1.EmployeeService])
    ], EmployeeListComponent);
    return EmployeeListComponent;
}());
exports.EmployeeListComponent = EmployeeListComponent;
//# sourceMappingURL=employeeList.component.js.map