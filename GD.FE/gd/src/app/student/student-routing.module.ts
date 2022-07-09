import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentComponent } from './student.component';
import { WelcomeComponent } from './welcomeStudent/welcomeStudent.component';

const routes: Routes = [
  { path: '', component: StudentComponent },
  { path: 'welcome', component: WelcomeComponent }
];

@NgModule({
  imports: [    RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentRoutingModule { }
