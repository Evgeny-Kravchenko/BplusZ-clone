import generateVehicleClassConfig from './vehicleClass.config';
import generateVehicleStatusConfig from "./vehicleStatus.config";

const generateDefaultBestandTableState = (t) => {
  return {
    bestandVehicleClass: generateVehicleClassConfig(t),
    bestandVehicleStatus: generateVehicleStatusConfig(t),
    page: 0,
    searchField: '',
    searchValue: '',
    sortField: '',
    order: '',
  };
};

export default generateDefaultBestandTableState;
