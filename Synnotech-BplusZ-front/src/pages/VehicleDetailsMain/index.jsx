import React from 'react';
import { useHistory } from 'react-router-dom';
import PropTypes from 'prop-types';

import { Link, Grid, Typography } from '@material-ui/core';

import KeyboardBackspaceIcon from '@material-ui/icons/KeyboardBackspace';

import ContainerView from '@/components/ContainerView/ContainerView';

import useStyle from './styles';

const DetailsVehicleMain = () => {
  const history = useHistory();
  const classes = useStyle();

  return (
    <Grid container className={classes.containerPage}>
      <Grid container item className={classes.goBackAndTitleContainer}>
        <Link color="secondary" onClick={() => history.goBack()}>
          <KeyboardBackspaceIcon />
        </Link>
        <Typography variant="h2" className={classes.vehicleTitle}>
          Fahrzeug BZ-LL 906
        </Typography>
      </Grid>
      <Grid item>
        <ContainerView header={<div>header</div>} body={<div>body</div>} />
      </Grid>
    </Grid>
  );
};

DetailsVehicleMain.propTypes = {
  match: PropTypes.instanceOf(Object).isRequired,
};

export default DetailsVehicleMain;
