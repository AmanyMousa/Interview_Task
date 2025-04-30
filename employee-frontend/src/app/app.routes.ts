import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeAddEditComponent } from './employee-add-edit/employee-add-edit.component';

export const routes: Routes = [
  { path: '', component: EmployeeListComponent },
  {path: 'employee-list', component: EmployeeListComponent },
  {path: 'employee-edite/:id', component: EmployeeAddEditComponent },


  { path: '**', redirectTo: '' }
];

