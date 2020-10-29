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

import technicalContractDataSrc from '@/assets/images/main-details-icons/technical-contract-data.png';

import useStyle from './styles';

const TechnicalContractDataVehicleDataCard = () => {
  const classes = useStyle();
  const { t } = useTranslation();
  const header = (
    <>
      <img src={technicalContractDataSrc} alt="general vehicle data" />
      <Typography variant="h4" className={classes.title}>
        {t('detailsPage.technicalContractData.title')}
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
          <InputLabel>{t('detailsPage.technicalContractData.maintenance')}</InputLabel>
          <OutlinedInput
            value="Befristet"
            label={t('detailsPage.technicalContractData.maintenance')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.technicalContractData.mileage')}</InputLabel>
          <OutlinedInput
            value="5000 km"
            label={t('detailsPage.technicalContractData.mileage')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.technicalContractData.endOfMaintenance')}</InputLabel>
          <OutlinedInput
            value="12.03.2021"
            label={t('detailsPage.technicalContractData.endOfMaintenance')}
            disabled
          />
        </FormControl>
      </Grid>
    </>
  );

  return <MainDetailsCardContainer header={header} body={body} />;
};

export default TechnicalContractDataVehicleDataCard;
