import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StudentComponent } from './page.component';
import { WelcomeComponent } from './welcome/welcome.component';

const routes: Routes = [
  { path: '', component: StudentComponent },
  { path: 'welcome', component: WelcomeComponent }
];

@NgModule({
  imports: [    RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentRoutingModule { }
