import { lazy } from 'react';
import { VEHICLE_DETAILS_MAIN_ROUTE, HOME_PAGE_ROUTE } from '@/constants';

const DataGrid = lazy(() => import('@/components/DataGrid'));
const DetailsVehicleMain = lazy(() => import('@/pages/VehicleDetailsMain'));

export default [
  {
    private: true,
    component: DataGrid,
    exact: true,
    path: HOME_PAGE_ROUTE,
  },
  {
    private: true,
    component: DetailsVehicleMain,
    exact: true,
    path: VEHICLE_DETAILS_MAIN_ROUTE,
  },
];
