import React from 'react';
import { useTranslation } from 'react-i18next';

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
  const { t } = useTranslation();
  const header = (
    <>
      <img src={techicalComponentsVehicleDataSrc} alt="general vehicle data" />
      <Typography variant="h4" className={classes.title}>
        {t('detailsPage.technicalComponents.title')}
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
          <InputLabel htmlFor="status">
            {t('detailsPage.technicalComponents.manufacturerConstruction')}
          </InputLabel>
          <OutlinedInput
            value="LKW"
            label={t('detailsPage.technicalComponents.manufacturerConstruction')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel htmlFor="typeOfConstruction">
            {t('detailsPage.technicalComponents.typeOfConstruction')}
          </InputLabel>
          <OutlinedInput
            value="BDF"
            label={t('detailsPage.technicalComponents.typeOfConstruction')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6} className={classes.checkBoxContainer}>
        <FormControl component="fieldset">
          <FormLabel component="legend" className={classes.checkboxTitle}>
            {t('detailsPage.technicalComponents.loadingPlatform')}
          </FormLabel>
          <RadioGroup className={classes.checkboxLabel}>
            <FormControlLabel
              control={<Radio />}
              label={t('detailsPage.technicalComponents.isChecked')}
              checked
              disabled
            />
          </RadioGroup>
        </FormControl>
      </Grid>
      <Grid item md={6} className={classes.checkBoxContainer}>
        <FormControl component="fieldset">
          <FormLabel component="legend" className={classes.checkboxTitle}>
            Parking air conditioner
          </FormLabel>
          <RadioGroup className={classes.checkboxLabel}>
            <FormControlLabel
              value="female"
              control={<Radio />}
              label={t('detailsPage.technicalComponents.isNotChecked')}
              disabled
            />
          </RadioGroup>
        </FormControl>
      </Grid>
    </>
  );

  return <MainDetailsCardContainer header={header} body={body} />;
};

export default TechicalComponentsVehicleDataCard;
