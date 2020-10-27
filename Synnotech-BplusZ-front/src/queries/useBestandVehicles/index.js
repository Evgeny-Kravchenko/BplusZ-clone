import { ALL_VEHICLES_STOCK } from '@/constants';
import axios from 'axios';
import qs from 'querystring';
import { usePaginatedQuery } from 'react-query';

export const useBestandVehicles = (options) => {
  return usePaginatedQuery([ALL_VEHICLES_STOCK, options], (key, options) => {
    if (options['AllowedVehicleClasses'].includes('all')) {
      options['AllowedVehicleClasses'] = [];
    }
    if (options['AllowedVehicleStatus'].includes('all')) {
      options['AllowedVehicleStatus'] = [];
    }
    console.log(qs.stringify(options));
    const queryParams = {};
  });
};
