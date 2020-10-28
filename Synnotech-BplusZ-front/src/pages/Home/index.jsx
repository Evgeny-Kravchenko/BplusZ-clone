import React, { Suspense } from 'react';
import { Switch } from 'react-router-dom';

import { Grid, LinearProgress } from '@material-ui/core';

import Header from '@/components/Header';
import Routes from '@/components/Routes';

import { useAuth } from '@/contexts/auth';

import useStyles from './styles';

import routes from './routes';

const HomePage = () => {
  const classes = useStyles();
  const { authorized } = useAuth();

  return (
    <Grid container className={classes.pageContainer}>
      <Grid item className={classes.headerContainer}>
        <Header />
      </Grid>
      <Suspense fallback={<LinearProgress />}>
        <Switch>
          {routes.map((route) => {
            const routeType = route.private ? 'Private' : 'Public';
            const Route = Routes[routeType];
            return <Route key={route.path} {...route} authorized={authorized} />;
          })}
        </Switch>
      </Suspense>
    </Grid>
  );
};

export default HomePage;
