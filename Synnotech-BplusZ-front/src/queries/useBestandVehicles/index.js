import { ALL_VEHICLES_STOCK } from '@/constants';
import axios from 'axios';
import qs from 'querystring';
import { usePaginatedQuery } from 'react-query';

import { getAllowedCheckboxes, translateCheckboxesToDutch } from '@/helpers';

import formatter from './formatter';

const useBestandVehicles = ({ tableBestandState, t, i18n }) => {
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
      const allowedVehicleClasses =
        i18n.language === 'de'
          ? getAllowedCheckboxes(bestandVehicleClass, t)
          : translateCheckboxesToDutch(getAllowedCheckboxes(bestandVehicleClass, t));
      const allowedStatuses =
        i18n.language === 'de'
          ? getAllowedCheckboxes(bestandVehicleStatus, t)
          : translateCheckboxesToDutch(getAllowedCheckboxes(bestandVehicleStatus, t));
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
