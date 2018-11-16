import { Component, OnInit } from '@angular/core';
import { Student } from 'app/models/Student';
import { StudentService } from 'app/services/student/student.service';
import { UtilService } from 'app/services/util/util.service';
import { Pipe} from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-studentList',
  templateUrl: './studentList.component.html',
  styleUrls: ['./studentList.component.scss']
})
export class StudentListComponent implements OnInit {

  constructor(private studentService: StudentService, private utilService: UtilService) {

  }

  studentList: Student[] = []
  //   {id:1,fullName:'aswdas', registrationDate:'2018.11.15'},
  //   {id:1,fullName:'aswdas 2', registrationDate:'2018.11.15'},
  //   {id:1,fullName:'aswdas 3', registrationDate:'2018.11.15'}
  // ];
  ngOnInit() {
    this.studentService.getStudentList().subscribe(
      data => {
        this.studentList = data;
      }
    );
  }

  formatDate(pDate:Date) : string{
   return this.utilService.formatDate(pDate);
  }

}
