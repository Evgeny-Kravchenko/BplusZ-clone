import { lazy } from 'react';
import { AUTH_PAGE_ROUTE, HOME_PAGE_ROUTE } from '@/constants';

const Login = lazy(() => import('@/pages/Login'));
const Home = lazy(() => import('@/pages/Home'));
const ErrorPage404 = lazy(() => import('@/pages/Error-page-404'));

export default [
  {
    component: Login,
    exact: true,
    path: AUTH_PAGE_ROUTE,
  },
  {
    private: true,
    component: Home,
    path: HOME_PAGE_ROUTE,
  },
  {
    component: ErrorPage404,
    path: '*',
  },
];
