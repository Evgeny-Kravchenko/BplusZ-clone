import React from 'react';

import {
  Grid,
  Typography,
  IconButton,
  Select,
  MenuItem,
  InputLabel,
  makeStyles,
  FormControl,
  TextField,
} from '@material-ui/core';

import VisibilityIcon from '@material-ui/icons/Visibility';

import generalVehicleDataSrc from '@/assets/images/main-details-icons/general-vehicle-data.png';

import statuses from './status.config';
import vehicleClasses from './vehicleClasses.config';

const useStyle = makeStyles((theme) => {
  return {
    cardContainer: {
      backgroundColor: theme.palette.primary.main,
      padding: `0 ${theme.spacing(1.6)} ${theme.spacing(2.9)} ${theme.spacing(1.6)}`,
      border: '1px solid #E5E5E5',
      borderRadius: '4px',
    },
    headerContainer: {
      alignItems: 'center',
      padding: theme.spacing(0.9),
      borderBottom: '1px solid #E5E5E5',
    },
    title: {
      fontSize: '1.8rem',
      paddingLeft: theme.spacing(1.4),
    },
    moreDetailsIcon: {
      '&:hover': {
        fill: theme.palette.secondary.main,
      },
    },
    body: {
      paddingTop: theme.spacing(2.1),
      '& .MuiFormControl-root': {
        width: '100%',
      },
    },
  };
});

const MainDetailsCard = () => {
  const classes = useStyle();
  return (
    <Grid container item className={classes.cardContainer}>
      <Grid container item className={classes.headerContainer}>
        <img src={generalVehicleDataSrc} alt="general vehicle data" />
        <Typography variant="h4" className={classes.title}>
          Allgemeine Fahrzeugdaten
        </Typography>
        <div style={{ flexGrow: 1 }} />
        <IconButton size="small">
          <VisibilityIcon className={classes.moreDetailsIcon} />
        </IconButton>
      </Grid>
      <Grid container item className={classes.body} spacing={2}>
        <Grid item md={6}>
          <FormControl color="secondary" variant="outlined">
            <InputLabel>Status</InputLabel>
            <Select>
              {statuses.map((option) => (
                <MenuItem key={option}></MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>
        <Grid item md={6}>
          <TextField
            id="outlined-search"
            label="Class of vehicle"
            type="text"
            variant="outlined"
            color="secondary"
          />
        </Grid>
        <Grid item md={6}>
          <TextField
            id="outlined-select-currency-native"
            select
            label="Class of vehicle"
            SelectProps={{
              native: true,
            }}
            variant="outlined"
            color="secondary"
          >
            {vehicleClasses.map((option) => (
              <option key={option} value={option}>
                {option}
              </option>
            ))}
          </TextField>
        </Grid>
        <Grid item md={6}>
          <TextField
            id="outlined-select-currency-native"
            select
            label="Manufacturer"
            SelectProps={{
              native: true,
            }}
            variant="outlined"
            color="secondary"
          />
        </Grid>
        <Grid item md={6}>
          <TextField
            id="outlined-search"
            label="Manufacturer"
            type="text"
            variant="outlined"
            color="secondary"
          />
        </Grid>
        <Grid item md={6}>
          <TextField
            id="outlined-search"
            label="Current mileage"
            type="text"
            variant="outlined"
            color="secondary"
          />
        </Grid>
      </Grid>
    </Grid>
  );
};

export default MainDetailsCard;
