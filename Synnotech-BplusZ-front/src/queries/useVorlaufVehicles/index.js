import { ALL_VEHICLES_ADVANCE } from '@/constants';
import axios from 'axios';
import qs from 'querystring';
import { usePaginatedQuery } from 'react-query';

import { getAllowedCheckboxes, translateCheckboxesToDutch } from '@/helpers';

import formatter from './formatter';

const useVorlaufVehicles = (params) => {
  return usePaginatedQuery([ALL_VEHICLES_ADVANCE, params], async (key, options) => {
    const {
      page,
      searchValue,
      searchField,
      vorlaufVehicleClass,
      vorlaufVehicleStatus,
      sortField,
      order,
    } = options;
    const skip = (page + 1) * 10 - 10;
    const take = 10;
    const allowedVehicleClasses = translateCheckboxesToDutch(
      getAllowedCheckboxes(vorlaufVehicleClass)
    );
    const allowedStates = translateCheckboxesToDutch(getAllowedCheckboxes(vorlaufVehicleStatus));
    const isAscendingSortOrder = order === 'asc';
    const queryParams = {
      AllowedStates: allowedStates,
      AllowedVehicleClasses: allowedVehicleClasses,
      Skip: skip,
      Take: take,
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
    const { data } = await axios.get(`${ALL_VEHICLES_ADVANCE}?${qs.stringify(queryParams)}`);
    const { result, count } = data;
    return { count, result: result.map(formatter) };
  });
};

export default useVorlaufVehicles;
