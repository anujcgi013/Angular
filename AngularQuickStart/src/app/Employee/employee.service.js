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
var http_1 = require("@angular/http");
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/operator/throw");
var EmployeeService = /** @class */ (function () {
    function EmployeeService(_http) {
        this._http = _http;
    }
    EmployeeService.prototype.getEmployee = function () {
        return this._http.get("http://localhost:57950/api/Employee")
            .map(function (response) { return response.json(); })
            .catch(this.handleError);
        //[
        //    { code: 'emp101', name: 'Anuj1', gender: 'Female', salary: 44000 },
        //    { code: 'emp102', name: 'Anuj2', gender: 'Female', salary: 42000 },
        //    { code: 'emp103', name: 'Anuj3', gender: 'Male', salary: 43000 },
        //    { code: 'emp104', name: 'Anuj4', gender: 'Male', salary: 45000 },
        //    { code: 'emp105', name: 'Anuj5', gender: 'Female', salary: 46000 }
        //];
    };
    EmployeeService.prototype.handleError = function (error) {
        return Observable_1.Observable.throw(error);
    };
    EmployeeService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], EmployeeService);
    return EmployeeService;
}());
exports.EmployeeService = EmployeeService;
//# sourceMappingURL=employee.service.js.map