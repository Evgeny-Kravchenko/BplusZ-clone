import {
  MISSED_APPOINTMENT_STRING,
  RESCHEDULED_APPOINTMENT_STRING,
  IN_WORK_STRING,
} from '@/constants';

import { generatorIdInstance } from '@/helpers';

function createData(
  id,
  licenseNumber,
  constrType,
  brandAndModel,
  vehicleStatus,
  branchOffice,
  eventsStatus,
  infoLink,
  vehicleBelonging
) {
  return {
    id,
    licenseNumber,
    constrType,
    brandAndModel,
    vehicleStatus,
    branchOffice,
    eventsStatus,
    infoLink,
    vehicleBelonging,
  };
}

export default [
  createData(
    generatorIdInstance(),
    'AZ-LL 903',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Aerkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    'E',
    'M'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 902',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Lal Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 9031',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    RESCHEDULED_APPOINTMENT_STRING,
    'E',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'CZ-LL 9033',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Listik GmbH',
    MISSED_APPOINTMENT_STRING,
    '',
    'M'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 9043',
    'Transporter',
    'Aercedes-Benz Atego',
    'Werkstatt',
    'Aocal Logistik GmbH',
    RESCHEDULED_APPOINTMENT_STRING,
    '',
    'M'
  ),
  createData(
    generatorIdInstance(),
    'ZZ-LL 9013',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    MISSED_APPOINTMENT_STRING,
    'E',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90t3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    MISSED_APPOINTMENT_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 9b03',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    'E',
    'M'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90w3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    'E',
    'M'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
  createData(
    generatorIdInstance(),
    'BZ-LL 90h3',
    'Wechselkoffer',
    'Mercedes-Benz Atego',
    'Werkstatt',
    'Local Logistik GmbH',
    IN_WORK_STRING,
    '',
    'B'
  ),
];
