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
  const allowed = checkboxesList.filter(({ value }) => value).map(({ key }) => key);
  if (allowed.length === 1 && allowed[0] === 'alle') {
    return checkboxesList.filter(({ key }) => key !== 'alle').map(({ key }) => key);
  }
  if (allowed.length === 0) {
    return ['unknown'];
  }
  return allowed;
};

const convertDate = (stringDate) => {
  return (
    stringDate &&
    new Date('2020-01-24T00:00:00').toLocaleString('de-DE', {
      day: '2-digit',
      month: '2-digit',
      year: 'numeric',
    })
  );
};

export {
  defineColor,
  generatorIdInstance,
  getAllowedCheckboxes,
  convertDate,
};
