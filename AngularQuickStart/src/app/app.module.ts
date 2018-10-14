import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { EmployeeComponent } from './Employee/employee.component';
import { EmployeeListComponent } from './Employee/employeeList.component';
import { EmployeeCountComponent } from './Employee/EmployeeCount.component';
import Employeelistpipe = require("./Employee/employeelist.pipe");
import employeeListPipe = Employeelistpipe.EmployeeListPipe;

@NgModule({
    imports: [BrowserModule],
    declarations: [AppComponent, EmployeeComponent, EmployeeListComponent, employeeListPipe, EmployeeCountComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }
