import { NgModule } from '@angular/core';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { IconsProviderModule } from '../icons-provider.module';
import { NgZorroAntdModule } from '../ng-zorro-antd.module';
import {  StudentRoutingModule } from './student-routing.module';
import {  StudentComponent } from './student.component';


import { WelcomeComponent } from './welcome/welcome.component';


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
