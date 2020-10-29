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

import transferDataSrc from '@/assets/images/main-details-icons/transfer-data.svg';

import { convertDate } from '@/helpers';

import useStyle from './styles';

const TransferDataCard = ({ data }) => {
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
            value={data?.branchOffice || ''}
            label={t('detailsPage.transferData.branchOffice')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.transferData.transferRate')}</InputLabel>
          <OutlinedInput
            value={data?.transferRate || ''}
            label={t('detailsPage.transferData.transferRate')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.transferData.startOfContract')}</InputLabel>
          <OutlinedInput
            value={convertDate(data?.startOfContract) || ''}
            label={t('detailsPage.transferData.startOfContract')}
            disabled
          />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>{t('detailsPage.transferData.endOfContract')}</InputLabel>
          <OutlinedInput
            value={convertDate(data?.endOfContract) || ''}
            label={t('detailsPage.transferData.endOfContract')}
            disabled
          />
        </FormControl>
      </Grid>
    </>
  );

  return <MainDetailsCardContainer header={header} body={body} />;
};

TransferDataCard.propTypes = {
  data: PropTypes.instanceOf(Object),
};

TransferDataCard.defaultProps = {
  data: {},
};

export default TransferDataCard;
