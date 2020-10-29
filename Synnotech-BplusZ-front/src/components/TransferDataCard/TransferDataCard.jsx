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

import transferDataSrc from '@/assets/images/main-details-icons/transfer-data.png';

import useStyle from './styles';

const TransferDataCard = () => {
  const classes = useStyle();
  const { t } = useTranslation();
  const header = (
    <>
      <img src={transferDataSrc} alt="general vehicle data" />
      <Typography variant="h4" className={classes.title}>
        {t('detailsPage.transferData.title')}
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
          <InputLabel>{t('detailsPage.transferData.branchOffice')}</InputLabel>
          <OutlinedInput
            value="Berlin"
            label={t('detailsPage.transferData.branchOffice')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.transferData.transferRate')}</InputLabel>
          <OutlinedInput
            value="390 €"
            label={t('detailsPage.transferData.transferRate')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.transferData.startOfContract')}</InputLabel>
          <OutlinedInput
            value="10.04.2020"
            label={t('detailsPage.transferData.startOfContract')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.transferData.endOfContract')}</InputLabel>
          <OutlinedInput
            value="12.03.2021"
            label={t('detailsPage.transferData.endOfContract')}
            disabled
          />
        </FormControl>
      </Grid>
    </>
  );

  return <MainDetailsCardContainer header={header} body={body} />;
};

export default TransferDataCard;
