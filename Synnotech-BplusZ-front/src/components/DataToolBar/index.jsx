import React from 'react';
import { useTranslation } from 'react-i18next';

import { Button, Grid } from '@material-ui/core';

import Search from '@/fields/Search';

import useStyle from './styles';

const DataToolBar = () => {
  const classes = useStyle();
  const { t } = useTranslation();
  return (
    <Grid item container>
      <Grid item className={classes.buttonsContainer}>
        <Button variant="contained" color="secondary">
          {t('mainPage.newInvestmentBtn')}
        </Button>
        <Button variant="contained" color="secondary">
          {t('mainPage.reportingBtn')}
        </Button>
        <Button variant="contained" color="secondary">
          {t('mainPage.KMInventoryBtn')}
        </Button>
      </Grid>
      <Grid item className={classes.searchContainer}>
        <Search />
      </Grid>
    </Grid>
  );
};

export default DataToolBar;
