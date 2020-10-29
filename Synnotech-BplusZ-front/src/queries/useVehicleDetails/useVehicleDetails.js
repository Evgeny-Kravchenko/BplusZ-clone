import { GENERAL_VEHICLE_DETAILS } from '@/constants';
import axios from 'axios';
import { useQuery } from 'react-query';
import formatter from './formatter';

const useVehicleDetails = (params) => {
  return useQuery([GENERAL_VEHICLE_DETAILS, params], async (key, id) => {
    const { data } = await axios.get(`${GENERAL_VEHICLE_DETAILS}/${id}`);
    return formatter(data);
  });
};

export default useVehicleDetails;
