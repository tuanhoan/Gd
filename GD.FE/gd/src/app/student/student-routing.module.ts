import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentComponent } from './student.component';
import { WelcomeStudentComponent } from './welcomeStudent/welcomeStudent.component';

const routes: Routes = [
  {
      path: 'sinhvien',
      component: StudentComponent,
      children: [
          { path: 'welcomestudent', component: WelcomeStudentComponent }
      ]
  }
];
@NgModule({
  imports: [    RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentRoutingModule { }
