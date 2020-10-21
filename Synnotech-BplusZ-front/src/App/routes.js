import { lazy } from 'react';
import { AUTH_PAGE_ROUTE, HOME_PAGE_ROUTE } from '@/constants';

const Login = lazy(() => import('@/pages/Login'));
const Home = lazy(() => import('@/pages/Home'));

export default [
  {
    component: Login,
    exact: true,
    path: AUTH_PAGE_ROUTE,
  },
  {
    private: true,
    component: Home,
    exact: true,
    path: HOME_PAGE_ROUTE,
  },
];
