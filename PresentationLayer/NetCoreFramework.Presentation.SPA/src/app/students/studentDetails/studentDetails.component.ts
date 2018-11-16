import { Component, OnInit } from '@angular/core';
import { Student } from 'app/models/Student';

@Component({
  selector: 'app-studentDetails',
  templateUrl: './studentDetails.component.html',
  styleUrls: ['./studentDetails.component.scss']
})
export class StudentDetailsComponent implements OnInit {

  student:Student = {id:1, fullName:'Detail FullName',registrationDate:new Date()};
  constructor() { }

  ngOnInit() {
  }

}
