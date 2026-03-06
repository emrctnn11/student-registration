import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'StudentRegistration',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44323/',
    redirectUri: baseUrl,
    clientId: 'StudentRegistration_App',
    responseType: 'code',
    scope: 'offline_access StudentRegistration',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44323',
      rootNamespace: 'StudentRegistration',
    },
  },
} as Environment;
