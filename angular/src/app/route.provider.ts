import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/home',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/',
        name: '::Menu:Departments',
        iconClass: 'fas fa-building',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/students',
        name: '::Menu:Students',
        iconClass: 'fas fa-user-graduate',
        order: 3,
        layout: eLayoutType.application,
      },
    ]);
  };
}