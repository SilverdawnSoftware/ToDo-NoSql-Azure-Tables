// ALLOWOVERWRITE-7119BD6B71D37803621FBE50172FFBB3

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpModule }    from '@angular/http';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { AdminRoutingModule } from "./modules/admin/AdminRoutingModule";
import {AppShell} from "./modules/shell/appshell";
import {CdkTableModule} from '@angular/cdk/table';
import { HttpClientModule } from '@angular/common/http';

import { MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatExpansionModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
  MatStepperModule,} from '@angular/material';




import {UserIndex} from './modules/admin/User/Views/UserIndex';
import {UserEdit} from './modules/admin/User/Views/UserEdit';


import {TaskIndex} from './modules/admin/Task/Views/TaskIndex';
import {TaskEdit} from './modules/admin/Task/Views/TaskEdit';


@NgModule({
  exports: [
    CdkTableModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
  ]
})
export class AppMaterialModule {}



@NgModule({
  imports: [BrowserModule, ReactiveFormsModule, BrowserAnimationsModule, HttpModule, AdminRoutingModule, AppMaterialModule,NgxDatatableModule,FlexLayoutModule,HttpClientModule],
  declarations: [AppShell 
  ,UserEdit,UserIndex
  ,TaskEdit,TaskIndex
  
  
  ],
  bootstrap: [AppShell]
})
export class AppModule {}

//platformBrowserDynamic().bootstrapModule(AppModule);
