import { ALL_VEHICLES_STOCK } from '@/constants';
import axios from 'axios';
import qs from 'querystring';
import { usePaginatedQuery } from 'react-query';

import formatter from './formatter';

import { getAllowedCheckboxes, translateCheckboxesToDutch } from '@/helpers';

const useBestandVehicles = (options) => {
  return usePaginatedQuery([ALL_VEHICLES_STOCK, options], async (key, options) => {
    const {
      page,
      searchValue,
      searchField,
      bestandVehicleClass,
      bestandVehicleStatus,
      sortField,
      order,
    } = options;
    const skip = (page + 1) * 10 - 10;
    const take = 10;
    const allowedVehicleClasses = translateCheckboxesToDutch(
      getAllowedCheckboxes(bestandVehicleClass)
    );
    const allowedStatuses = getAllowedCheckboxes(bestandVehicleStatus);
    const isAscendingSortOrder = order === 'asc';
    const queryParams = {
      ['AllowedStatuses']: allowedStatuses,
      ['AllowedVehicleClasses']: allowedVehicleClasses,
      ['Skip']: skip,
      ['Take']: take,
    };
    if (searchValue) {
      queryParams['SearchTerm'] = searchValue;
    }
    if (searchField) {
      queryParams['SearchField'] = searchField;
    }
    if (sortField) {
      queryParams['SortField'] = sortField;
    }
    if (allowedStatuses) {
      queryParams['IsAscendingSortOrder'] = isAscendingSortOrder;
    }
    console.log(qs.stringify(queryParams));
    const { data } = await axios.get(`${ALL_VEHICLES_STOCK}?${qs.stringify(queryParams)}`);
    return data.map(formatter);
  });
};

export default useBestandVehicles;
