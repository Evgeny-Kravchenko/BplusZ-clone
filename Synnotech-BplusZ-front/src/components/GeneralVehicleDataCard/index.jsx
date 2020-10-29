import React from 'react';
import PropTypes from 'prop-types';
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

const GeneralVehicleData = ({ data }) => {
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
            value={data?.status || ''}
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
            value={data?.chassisNumber || ''}
            label={t('detailsPage.generalVehicleData.vinNumber')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.generalVehicleData.classOfVehicle')}</InputLabel>
          <OutlinedInput
            value={data?.vehicleClass || ''}
            label={t('detailsPage.generalVehicleData.classOfVehicle')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.generalVehicleData.manufacturer')}</InputLabel>
          <OutlinedInput
            value={data?.manufacturer || ''}
            label={t('detailsPage.generalVehicleData.manufacturer')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.generalVehicleData.model')}</InputLabel>
          <OutlinedInput
            value={data?.model || ''}
            label={t('detailsPage.generalVehicleData.model')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.generalVehicleData.currentMileage')}</InputLabel>
          <OutlinedInput
            value={data?.currentMileage || ''}
            label={t('detailsPage.generalVehicleData.currentMileage')}
            disabled
          />
        </FormControl>
      </Grid>
    </>
  );

  return <MainDetailsCardContainer header={header} body={body} />;
};

GeneralVehicleData.propTypes = {
  data: PropTypes.instanceOf(Object),
};

GeneralVehicleData.defaultProps = {
  data: {},
};

export default GeneralVehicleData;
