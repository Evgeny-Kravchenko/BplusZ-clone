import { ALL_VEHICLES_STOCK } from '@/constants';
import axios from 'axios';
import qs from 'querystring';
import { usePaginatedQuery } from 'react-query';

import { getAllowedCheckboxes } from '@/helpers';

import formatter from './formatter';

const useBestandVehicles = ({ tableBestandState }) => {
  return usePaginatedQuery(
    [ALL_VEHICLES_STOCK, tableBestandState],
    async (key, options) => {
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
      const allowedVehicleClasses = getAllowedCheckboxes(bestandVehicleClass);
      const allowedStatuses = getAllowedCheckboxes(bestandVehicleStatus);
      const isAscendingSortOrder = order === 'asc';
      const queryParams = {
        allowedStatuses,
        allowedVehicleClasses,
        skip,
        take,
      };
      if (searchValue) {
        queryParams.searchTerm = searchValue;
      }
      if (searchField) {
        queryParams.searchField = searchField;
      }
      if (sortField) {
        queryParams.sortField = sortField;
      }
      if (order) {
        queryParams.isAscendingSortOrder = isAscendingSortOrder;
      }
      const { data } = await axios.get(`${ALL_VEHICLES_STOCK}?${qs.stringify(queryParams)}`);
      const { result, count } = data;
      return { count, result: result.map(formatter) };
    },
    { retry: 1, refetchOnWindowFocus: false }
  );
};

export default useBestandVehicles;
