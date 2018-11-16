import {Observable} from 'rxjs';
import {Student} from '../../models/Student';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable(
    {
        providedIn: 'root'
    }
)
export class StudentService {

    constructor(private httpClient : HttpClient){
      
    }
    webApiPath = "http://localhost:52451/api";
    getStudentList():Observable<Student[]>{
        return this.httpClient.get<Student[]>(this.webApiPath+'/students');
    }

}