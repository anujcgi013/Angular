import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './Employee/employee.component';
import { EmployeeListComponent } from './Employee/employeeList.component';
import { EmployeeCountComponent } from './Employee/EmployeeCount.component';
import Employeelistpipe = require("./Employee/employeelist.pipe");
import employeeListPipe = Employeelistpipe.EmployeeListPipe;
//import { SimpleComponent } from "./Other/Simple.component"]

@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule],
    declarations: [AppComponent, EmployeeComponent, EmployeeListComponent, employeeListPipe, EmployeeCountComponent], //SimpleComponent
    bootstrap: [AppComponent]
})
export class AppModule { }
