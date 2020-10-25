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

const descendingComparator = (a, b, orderBy) => {
  if (b[orderBy] < a[orderBy]) {
    return -1;
  }
  if (b[orderBy] > a[orderBy]) {
    return 1;
  }
  return 0;
};

const getComparator = (order, orderBy) => {
  return order === 'desc'
    ? (a, b) => descendingComparator(a, b, orderBy)
    : (a, b) => -descendingComparator(a, b, orderBy);
};

const stableSort = (array, comparator) => {
  const stabilizedThis = array.map((el, index) => [el, index]);
  stabilizedThis.sort((a, b) => {
    const order = comparator(a[0], b[0]);
    if (order !== 0) return order;
    return a[1] - b[1];
  });
  return stabilizedThis.map((el) => el[0]);
};

const searchByField = (value, arr, field) => {
  if (value) {
    return arr.filter((item) => item[field].includes(value));
  }
  return [...arr];
};

const generatorId = () => {
  let id = 0;
  return () => {
    id += 1;
    return id;
  };
};

const generatorIdInstance = generatorId();

export { defineColor, getComparator, stableSort, searchByField, generatorIdInstance };
