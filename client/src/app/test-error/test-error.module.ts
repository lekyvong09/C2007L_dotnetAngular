import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { TestErrorComponent } from './test-error.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    NotFoundComponent,
    ServerErrorComponent,
    TestErrorComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
  ]
})
export class TestErrorModule { }
