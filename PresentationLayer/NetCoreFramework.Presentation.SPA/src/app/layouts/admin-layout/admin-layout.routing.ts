import { Routes } from '@angular/router';

import { DashboardComponent } from '../../dashboard/dashboard.component';
import { StudentListComponent} from '../../students/studentList/studentList.component';
import { StudentDetailsComponent } from 'app/students/studentDetails/studentDetails.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'students',  component: StudentListComponent },
    { path: 'students/studentDetails',  component: StudentDetailsComponent }
];
