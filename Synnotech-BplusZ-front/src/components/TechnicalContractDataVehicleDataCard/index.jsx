import React from 'react';
import PropTypes from "prop-types";
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

import technicalContractDataSrc from '@/assets/images/main-details-icons/technical-contract-data.svg';

import { convertDate } from '@/helpers';

import useStyle from './styles';

const TechnicalContractDataVehicleDataCard = ({ data }) => {
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
            value={data?.maintainanceAndRepair || ''}
            label={t('detailsPage.technicalContractData.maintenance')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.technicalContractData.mileage')}</InputLabel>
          <OutlinedInput
            value={convertDate(data?.startMaintainanceAndRepair) || ''}
            label={t('detailsPage.technicalContractData.mileage')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.technicalContractData.endOfMaintenance')}</InputLabel>
          <OutlinedInput
            value={convertDate(data?.endOfMaintainanceAndRepair) || ''}
            label={t('detailsPage.technicalContractData.endOfMaintenance')}
            disabled
          />
        </FormControl>
      </Grid>
    </>
  );

  return <MainDetailsCardContainer header={header} body={body} />;
};

TechnicalContractDataVehicleDataCard.propTypes = {
  data: PropTypes.instanceOf(Object),
};

TechnicalContractDataVehicleDataCard.defaultProps = {
  data: {},
};

export default TechnicalContractDataVehicleDataCard;
