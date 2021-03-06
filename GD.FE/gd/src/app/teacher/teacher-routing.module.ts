import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TeacherComponent } from './teacher.component';
import { WelcomeComponent } from './welcome/welcome.component';

const routes: Routes = [
  {
      path: 'giaovien',
      component: TeacherComponent,
      children: [
          { path: 'welcome', component: WelcomeComponent }
      ]
  }
];

@NgModule({
  imports: [    RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TeacherRoutingModule { }
