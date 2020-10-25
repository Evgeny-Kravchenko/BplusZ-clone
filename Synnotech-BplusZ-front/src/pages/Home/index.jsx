import React from 'react';
import { useTranslation } from 'react-i18next';

import { Grid, Typography } from '@material-ui/core';

import Header from '@/components/Header';
import DataGrid from '@/components/DataGrid';

import useStyles from './styles';

const HomePage = () => {
  const classes = useStyles();
  const { t } = useTranslation();
  return (
    <Grid container className={classes.pageContainer}>
      <Grid item className={classes.headerContainer}>
        <Header />
      </Grid>
      <Grid container item className={classes.logoBlock}>
        <div className="disguiseStyles" />
        <Typography variant="h1">{t('mainPage.title')}</Typography>
      </Grid>
      <DataGrid />
    </Grid>
  );
};

export default HomePage;
