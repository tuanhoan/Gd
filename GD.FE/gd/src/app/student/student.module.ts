import { NgModule } from '@angular/core';
import { IconsProviderModule } from '../icons-provider.module';
import { NgZorroAntdModule } from '../ng-zorro-antd.module';
import {  StudentRoutingModule } from './student-routing.module';
import {  StudentComponent } from './student.component';
import { WelcomeStudentComponent } from './welcomeStudent/welcomeStudent.component';


@NgModule({
  imports: [StudentRoutingModule,
    NgZorroAntdModule,
    IconsProviderModule
  ],
  declarations: [StudentComponent,
    WelcomeStudentComponent],
  exports: [StudentComponent,
    WelcomeStudentComponent]
})
export class StudentModule { }
