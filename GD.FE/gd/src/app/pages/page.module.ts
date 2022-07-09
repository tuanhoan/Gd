import { NgModule } from '@angular/core';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { IconsProviderModule } from '../icons-provider.module';
import { NgZorroAntdModule } from '../ng-zorro-antd.module';
import { PageRoutingModule } from './page-routing.module';
import { PageComponent } from './page.component';


import { WelcomeComponent } from './welcome/welcome.component';


@NgModule({
  imports: [PageRoutingModule,
    NgZorroAntdModule,
    IconsProviderModule
  ],
  declarations: [PageComponent],
  exports: [PageComponent]
})
export class WelcomeModule { }
