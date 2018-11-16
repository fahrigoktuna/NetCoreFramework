import { DashboardComponent } from '../../dashboard/dashboard.component';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { TableListComponent } from '../../table-list/table-list.component';
import { TypographyComponent } from '../../typography/typography.component';
import { IconsComponent } from '../../icons/icons.component';
import { NotificationsComponent } from '../../notifications/notifications.component';
import { StudentListComponent } from '../../students/studentList/studentList.component';
import { StudentDetailsComponent } from 'app/students/studentDetails/studentDetails.component';
export var AdminLayoutRoutes = [
    { path: 'dashboard', component: DashboardComponent },
    { path: 'user-profile', component: UserProfileComponent },
    { path: 'table-list', component: TableListComponent },
    { path: 'typography', component: TypographyComponent },
    { path: 'icons', component: IconsComponent },
    { path: 'notifications', component: NotificationsComponent },
    { path: 'students', component: StudentListComponent },
    { path: 'students/studentDetails', component: StudentDetailsComponent }
];
//# sourceMappingURL=admin-layout.routing.js.map