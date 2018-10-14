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
var EmployeeListComponent = /** @class */ (function () {
    function EmployeeListComponent() {
        this.employees = [
            { code: 'emp101', name: 'Anuj1', gender: 'Female', Salary: 44000 },
            { code: 'emp102', name: 'Anuj2', gender: 'Female', Salary: 42000 },
            { code: 'emp103', name: 'Anuj3', gender: 'Male', Salary: 43000 },
            { code: 'emp104', name: 'Anuj4', gender: 'Male', Salary: 45000 },
            { code: 'emp105', name: 'Anuj5', gender: 'Female', Salary: 46000 }
        ];
    }
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
            styleUrls: ['app/Employee/employeeList.component.css']
        }),
        __metadata("design:paramtypes", [])
    ], EmployeeListComponent);
    return EmployeeListComponent;
}());
exports.EmployeeListComponent = EmployeeListComponent;
//# sourceMappingURL=employeeList.component.js.map