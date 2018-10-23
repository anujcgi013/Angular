import { Injectable } from "@angular/core"
import { IEmployee } from "./employee";
import { Http, Response } from '@angular/http';
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/throw";

@Injectable()
export class EmployeeService {

    constructor(private _http: Http) { }

    getEmployee(): Observable<IEmployee[]> {
        return this._http.get("http://localhost:57950/api/Employee")
            .map((response: Response) => <IEmployee[]>response.json())
            .catch(this.handleError);

        //[
        //    { code: 'emp101', name: 'Anuj1', gender: 'Female', salary: 44000 },
        //    { code: 'emp102', name: 'Anuj2', gender: 'Female', salary: 42000 },
        //    { code: 'emp103', name: 'Anuj3', gender: 'Male', salary: 43000 },
        //    { code: 'emp104', name: 'Anuj4', gender: 'Male', salary: 45000 },
        //    { code: 'emp105', name: 'Anuj5', gender: 'Female', salary: 46000 }
        //];
    }

    handleError(error: Response) {
        return Observable.throw(error);
    }

}