import React from 'react';

import {
  IconButton,
  Typography,
  Grid,
  FormControl,
  InputLabel,
  OutlinedInput,
  RadioGroup,
  FormLabel,
  FormControlLabel,
  Radio,
} from '@material-ui/core';

import VisibilityIcon from '@material-ui/icons/Visibility';

import MainDetailsCardContainer from '@/components/MainDetailsCardContainer';

import techicalComponentsVehicleDataSrc from '@/assets/images/main-details-icons/technical-components.png';

import useStyle from './styles';

const TechicalComponentsVehicleDataCard = () => {
  const classes = useStyle();
  const header = (
    <>
      <img src={techicalComponentsVehicleDataSrc} alt="general vehicle data" />
      <Typography variant="h4" className={classes.title}>
        Tecnical components
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
          <InputLabel htmlFor="status">Manufacturer Construction</InputLabel>
          <OutlinedInput value="LKW" label="Manufacturer Construction" disabled />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel htmlFor="typeOfConstruction">Type of construction</InputLabel>
          <OutlinedInput value="BDF" label="Type of construction" disabled />
        </FormControl>
      </Grid>
      <Grid item md={6} className={classes.checkBoxContainer}>
        <FormControl component="fieldset">
          <FormLabel component="legend" className={classes.checkboxTitle}>
            Loading platform
          </FormLabel>
          <RadioGroup className={classes.checkboxLabel}>
            <FormControlLabel value="female" control={<Radio />} label="yes" checked disabled />
          </RadioGroup>
        </FormControl>
      </Grid>
      <Grid item md={6} className={classes.checkBoxContainer}>
        <FormControl component="fieldset">
          <FormLabel component="legend" className={classes.checkboxTitle}>
            Parking air conditioner
          </FormLabel>
          <RadioGroup className={classes.checkboxLabel}>
            <FormControlLabel value="female" control={<Radio />} label="no" disabled />
          </RadioGroup>
        </FormControl>
      </Grid>
    </>
  );

  return <MainDetailsCardContainer header={header} body={body} />;
};

export default TechicalComponentsVehicleDataCard;
