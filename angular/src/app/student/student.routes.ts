import { Routes } from '@angular/router';
import { authGuard } from '@abp/ng.core';
import { StudentComponent } from './student.component';

export const studentRoutes: Routes = [
  {
    path: '',
    component: StudentComponent,
    canActivate: [authGuard],
  },
];