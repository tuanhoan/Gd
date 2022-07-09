import { NgModule } from '@angular/core';
import { IconsProviderModule } from '../icons-provider.module';
import { NgZorroAntdModule } from '../ng-zorro-antd.module';
import {  StudentRoutingModule } from './student-routing.module';
import {  StudentComponent } from './student.component';


import { WelcomeComponent } from './welcomeStudent/welcomeStudent.component';


@NgModule({
  imports: [StudentRoutingModule,
    NgZorroAntdModule,
    IconsProviderModule
  ],
  declarations: [StudentComponent,
    WelcomeComponent],
  exports: [StudentComponent,
    WelcomeComponent]
})
export class StudentModule { }