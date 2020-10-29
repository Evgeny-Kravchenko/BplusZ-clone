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

import technicalContractDataSrc from '@/assets/images/main-details-icons/technical-contract-data.png';

import useStyle from './styles';

const TechnicalContractDataVehicleDataCard = () => {
  const classes = useStyle();
  const header = (
    <>
      <img src={technicalContractDataSrc} alt="general vehicle data" />
      <Typography variant="h4" className={classes.title}>
        Technical contract data
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
          <InputLabel>Maintenance & Repair type of contract</InputLabel>
          <OutlinedInput value="Befristet" label="Maintenance & Repair type of contract" disabled />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>Mileage Maintenance & Repair</InputLabel>
          <OutlinedInput value="5000 km" label="Mileage Maintenance & Repair" disabled />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>End of Maintenance & Repair</InputLabel>
          <OutlinedInput value="12.03.2021" label="End of Maintenance & Repair " disabled />
        </FormControl>
      </Grid>
    </>
  );

  return <MainDetailsCardContainer header={header} body={body} />;
};

export default TechnicalContractDataVehicleDataCard;
