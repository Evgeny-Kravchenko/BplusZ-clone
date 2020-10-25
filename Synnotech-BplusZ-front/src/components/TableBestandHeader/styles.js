import { makeStyles } from '@material-ui/core/styles';

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
  licenseNumberHeader: {
    maxWidth: '14%',
    textAlign: 'left',

    '& .MuiButtonBase-root': {
      color: theme.palette.info.dark,
    },
  },
  constructorTypeHeader: {
    width: '13%',
    textAlign: 'left',
  },
  brandAndModelHeader: {
    width: '14%',
    textAlign: 'left',
  },
  vehicleStatusHeader: {
    width: '13%',
    textAlign: 'left',
  },
  branchOfficeHeader: {
    width: '17%',
    textAlign: 'left',
  },
  artHeader: {
    width: '9%',
    textAlign: 'left',
    paddingLeft: `${theme.spacing(2.5)}!important`,
  },
  infoHeader: {
    width: '6%',
    textAlign: 'left',
    paddingLeft: `${theme.spacing(2)}!important`,
  },
  eventsHeader: {
    width: '8%',
    textAlign: 'left',
    paddingLeft: `${theme.spacing(2)}!important`,
  },
  actionsHeader: {
    width: '6%',
    paddingRight: `${theme.spacing(3.2)}!important`,
    textAlign: 'left',
  },
  tableEvenRow: {
    backgroundColor: theme.palette.info.main,
  },
  link: {
    color: TABLE_LINK_COLOR,
  },
  eventsStatusCell: {
    paddingLeft: '0!important',
  },
  statusEvents: {
    width: '7px',
    height: '7px',
    color: 'red',
  },
  actionsCell: {
    paddingRight: `${theme.spacing(2.7)}!important`,
  },
  avatar: {
    width: '33px',
    height: '33px',
    fontSize: '1.4rem',
  },
  pagination: {
    display: 'block',
    marginLeft: 'auto',
    borderBottom: 'none',

    '& .MuiButtonBase-root': {
      paddingRight: theme.spacing(0),
      '&:hover': {
        backgroundColor: 'transparent',
      },
    },

    '& .MuiTablePagination-selectRoot': {
      display: 'none',
    },

    '& .MuiTablePagination-caption': {
      marginRight: theme.spacing(2),
    },
  },
}));

export default useStyle;
