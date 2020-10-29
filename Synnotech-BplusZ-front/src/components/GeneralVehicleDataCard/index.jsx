import React from 'react';

import {
  IconButton,
  Typography,
  Grid,
  FormControl,
  InputLabel,
  OutlinedInput,
} from '@material-ui/core';

import VisibilityIcon from '@material-ui/icons/Visibility';

import MainDetailsCardContainer from '@/components/MainDetailsCardContainer';

import generalVehicleDataSrc from '@/assets/images/main-details-icons/general-vehicle-data.png';

import useStyle from './styles';

const GeneralVehicleData = () => {
  const classes = useStyle();
  const header = (
    <>
      <img src={generalVehicleDataSrc} alt="general vehicle data" />
      <Typography variant="h4" className={classes.title}>
        General vehicle data
      </Typography>
      <div style={{ flexGrow: 1 }} />
      <IconButton size="small">
        <VisibilityIcon className={classes.moreDetailsIcon} />
      </IconButton>
    </>
  );
  const body = (
    <>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel htmlFor="status">Status</InputLabel>
          <OutlinedInput
            name="status"
            id="status"
            value="Auf Achse
"
            label="Status"
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel htmlFor="vinNumber">VIN Number</InputLabel>
          <OutlinedInput
            name="vinNumber"
            id="vinNumber"
            value="LGHJ6787687866786"
            label="VIN Number"
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>Class of vehicle</InputLabel>
          <OutlinedInput value="LKW" label="Class of vehicle" disabled />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>Manufacturer</InputLabel>
          <OutlinedInput value="Mercedes-Benz" label="Manufacturer" disabled />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>Model</InputLabel>
          <OutlinedInput value="10 000 km" label="Model" disabled />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>Current mileage</InputLabel>
          <OutlinedInput value="Atego" label="Current mileage" disabled />
        </FormControl>
      </Grid>
    </>
  );

  return <MainDetailsCardContainer header={header} body={body} />;
};

export default GeneralVehicleData;
