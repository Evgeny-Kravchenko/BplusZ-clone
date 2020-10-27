import {
  MISSED_APPOINTMENT_COLOR,
  RESCHEDULED_APPOINTMENT_COLOR,
  IN_WORK_COLOR,
  MISSED_APPOINTMENT_STRING,
  RESCHEDULED_APPOINTMENT_STRING,
  IN_WORK_STRING,
  UNKNOWN_STATUS_COLOR,
} from '@/constants';

const defineColor = (a) => {
  switch (a) {
    case IN_WORK_STRING: {
      return IN_WORK_COLOR;
    }
    case MISSED_APPOINTMENT_STRING: {
      return MISSED_APPOINTMENT_COLOR;
    }
    case RESCHEDULED_APPOINTMENT_STRING: {
      return RESCHEDULED_APPOINTMENT_COLOR;
    }
    default: {
      return UNKNOWN_STATUS_COLOR;
    }
  }
};

const generatorId = () => {
  let id = 0;
  return () => {
    id += 1;
    return id;
  };
};

const generatorIdInstance = generatorId();

const getAllowedCheckboxes = (checkboxesList) => {
  let allowedCheckboxes;
  const isAll = checkboxesList.all;
  const isNothing = Object.values(checkboxesList).every((item) => !item);
  if (isAll) {
    allowedCheckboxes = [];
  } else if (isNothing) {
    allowedCheckboxes = ['unknown'];
  } else {
    allowedCheckboxes = Object.entries(checkboxesList)
      .filter((vehicleClass) => vehicleClass[1])
      .map((vehicleClass) => vehicleClass[0]);
  }
  return [...allowedCheckboxes];
};

const translatedCheckboxes = {
  truck: 'LKW',
  car: 'PKW',
  semitrailer: 'Auflieger',
  van: 'Transporter',
  ['change van body']: 'Wechselkoffer',
  ['truck trailer']: 'Anhänger',
  ['on the road']: 'Auf Achse',
  ['exploitation']: 'In Verwertung',
  ['no use']: 'Ohne Einsatz',
  garage: 'Werkstatt',
  ['needs review']: 'Bedarfsanalyse',
  ['in verification by GF']: 'Prüfung GF',
  ['In propasal stage']: 'Angebotsphase',
  ordered: 'Bestellung',
  activating: 'Aktivierung',
  'process canceled': 'Storniert',
  ['to be replaced']: 'Wird ersetzt',
};

const translateCheckboxesToDutch = (checkboxLabels) => {
  return checkboxLabels.map((label) => translatedCheckboxes[label]);
};

export { defineColor, generatorIdInstance, getAllowedCheckboxes, translateCheckboxesToDutch };
