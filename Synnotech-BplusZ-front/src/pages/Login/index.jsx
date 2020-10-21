import React from 'react';
import { Grid } from '@material-ui/core';

import LoginForm from '@/forms/Login';
import Preview from '@/components/Preview';

import { useContainerStyles, usePreviewGridStyles, useAuthFormGridStyles } from './styles';

const LoginPage = () => {
  const containerClasses = useContainerStyles();
  const previewGridStyles = usePreviewGridStyles();
  const authFormGridClasses = useAuthFormGridStyles();
  return (
    <>
      <Grid container className={containerClasses.root}>
        <Grid item container alignItems="center" md={4} className={previewGridStyles.root}>
          <Preview />
        </Grid>
        <Grid
          item
          container
          justify="center"
          alignItems="center"
          md={8}
          className={authFormGridClasses.root}
        >
          <div className="disguiseStyles" />
          <LoginForm />
        </Grid>
      </Grid>
    </>
  );
};
export default LoginPage;
