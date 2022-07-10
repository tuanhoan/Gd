import { NgModule } from '@angular/core';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { IconsProviderModule } from '../icons-provider.module';
import { NgZorroAntdModule } from '../ng-zorro-antd.module';
import { TeacherRoutingModule } from './teacher-routing.module';
import { TeacherComponent } from './teacher.component';


import { WelcomeComponent } from './welcome/welcome.component';


@NgModule({
  imports: [
    TeacherRoutingModule,
    NgZorroAntdModule,
    IconsProviderModule
  ],
  declarations: [
    TeacherComponent,
    WelcomeComponent
  ],
  exports: [TeacherComponent,
    WelcomeComponent]
})
export class TeacherModule { }
