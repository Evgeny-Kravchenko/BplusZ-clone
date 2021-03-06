import { makeStyles } from '@material-ui/core';

import { TABLE_LINK_COLOR } from '@/constants';

const useStyle = makeStyles((theme) => ({
  dataGridRoot: {
    width: '100%',
    backgroundColor: theme.palette.primary.main,
    boxShadow: '0px 0px 4px rgba(0, 0, 0, 0.12), 0px 2px 2px rgba(0, 0, 0, 0.08)',

    '& .MuiTableRow-root': {
      height: '51px',
    },

    '& .MuiTableCell-root': {
      borderBottom: 'none',
      padding: theme.spacing(0),
      paddingLeft: theme.spacing(4.5),
    },

    '& .MuiTableRow-head': {
      height: '56px',
      borderBottom: '1px solid #E0E0E0',
    },
    '& .MuiTableCell-head': {
      padding: theme.spacing(0),
      paddingLeft: theme.spacing(4.5),
      color: theme.palette.info.dark,
    },
  },
  searchByLicenseInput: {
    '& .MuiInputBase-input': {
      width: '100%',
      boxSizing: 'border-box',

      '&:focus': {
        outline: `1px solid ${theme.palette.primary.dark}`,
      },
    },
    '& .MuiOutlinedInput-root': {
      borderRadius: '2px',
    },
  },
  searchIcon: {
    width: '20px',
  },
  investNumberHeader: {
    width: '15%',
    paddingLeft: `${theme.spacing(4)}!important`,

    '& .MuiButtonBase-root': {
      color: theme.palette.info.dark,
    },
  },
  licenseNumberHeader: {
    maxWidth: '14%',
    paddingLeft: `${theme.spacing(4)}!important`,

    '& .MuiButtonBase-root': {
      color: theme.palette.info.dark,
    },
  },
  vehicleClassHeader: {
    width: '12%',
  },
  brandAndModelHeader: {
    width: '14%',
  },
  constructionTypeHeader: {
    width: '13%',
  },
  vorlaufStatusHeader: {
    width: '13%',
  },
  branchOfficeHeader: {
    width: '13%',
  },
  actionsHeader: {
    width: '6%',
    paddingRight: `${theme.spacing(3.2)}!important`,
  },
  tableEvenRow: {
    backgroundColor: theme.palette.info.main,
  },
  link: {
    color: TABLE_LINK_COLOR,
  },
  actionsCell: {
    paddingRight: `${theme.spacing(2.7)}!important`,
  },
}));

export default useStyle;
