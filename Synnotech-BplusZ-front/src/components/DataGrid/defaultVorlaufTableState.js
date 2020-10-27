import generateVehicleClassConfig from './vehicleClass.config';
import generateVehicleVorlaufConfig from "./vorlaufStatus.config";

const generateDefaultVorlaufState = (t) => {
  return {
    vorlaufVehicleClass: generateVehicleClassConfig(t),
    vorlaufVehicleStatus: generateVehicleVorlaufConfig(t),
    page: 0,
    searchField: '',
    searchValue: '',
    sortField: '',
    order: '',
  };
};

export default generateDefaultVorlaufState;
