import React from 'react';
import { useTranslation } from 'react-i18next';

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
  const { t } = useTranslation();
  const header = (
    <>
      <img src={generalVehicleDataSrc} alt="general vehicle data" />
      <Typography variant="h4" className={classes.title}>
        {t('detailsPage.generalVehicleData.title')}
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
          <InputLabel htmlFor="status">{t('detailsPage.generalVehicleData.status')}</InputLabel>
          <OutlinedInput
            value="Auf Achse"
            label={t('detailsPage.generalVehicleData.status')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel htmlFor="vinNumber">
            {t('detailsPage.generalVehicleData.vinNumber')}
          </InputLabel>
          <OutlinedInput
            value="LGHJ6787687866786"
            label={t('detailsPage.generalVehicleData.vinNumber')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.generalVehicleData.classOfVehicle')}</InputLabel>
          <OutlinedInput
            value="LKW"
            label={t('detailsPage.generalVehicleData.classOfVehicle')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.generalVehicleData.manufacturer')}</InputLabel>
          <OutlinedInput
            value="Mercedes-Benz"
            label={t('detailsPage.generalVehicleData.manufacturer')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.generalVehicleData.model')}</InputLabel>
          <OutlinedInput
            value="10 000 km"
            label={t('detailsPage.generalVehicleData.model')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.generalVehicleData.currentMileage')}</InputLabel>
          <OutlinedInput
            value="Atego"
            label={t('detailsPage.generalVehicleData.currentMileage')}
            disabled
          />
        </FormControl>
      </Grid>
    </>
  );

  return <MainDetailsCardContainer header={header} body={body} />;
};

export default GeneralVehicleData;
