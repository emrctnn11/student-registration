import { Routes } from '@angular/router';
import { authGuard } from '@abp/ng.core';
import { DepartmentComponent } from './department.component';

export const departmentRoutes: Routes = [
  {
    path: '',
    component: DepartmentComponent,
    canActivate: [authGuard],
  },

  
];

