var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { StudentService } from 'app/services/student.service';
import { UtilService } from 'app/services/util/util.service';
var StudentListComponent = /** @class */ (function () {
    function StudentListComponent(studentService, utilService) {
        this.studentService = studentService;
        this.utilService = utilService;
        this.studentList = [];
    }
    //   {id:1,fullName:'aswdas', registrationDate:'2018.11.15'},
    //   {id:1,fullName:'aswdas 2', registrationDate:'2018.11.15'},
    //   {id:1,fullName:'aswdas 3', registrationDate:'2018.11.15'}
    // ];
    StudentListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.studentService.getStudentList().subscribe(function (data) {
            _this.studentList = data;
        });
        this.studentList.forEach(function (value) {
            console.log(value.registrationDate);
            value.registrationDate = _this.utilService.Deserialize(value.registrationDate);
            console.log(value.registrationDate);
        });
    };
    StudentListComponent = __decorate([
        Component({
            selector: 'app-studentList',
            templateUrl: './studentList.component.html',
            styleUrls: ['./studentList.component.scss'],
            providers: [StudentService]
        }),
        __metadata("design:paramtypes", [StudentService, UtilService])
    ], StudentListComponent);
    return StudentListComponent;
}());
export { StudentListComponent };
//# sourceMappingURL=studentList.component.js.map