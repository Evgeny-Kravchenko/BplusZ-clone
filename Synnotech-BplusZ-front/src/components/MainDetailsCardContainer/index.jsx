import React from 'react';
import PropTypes from 'prop-types';

import { Grid } from '@material-ui/core';

import useStyle from './styles';

const MainDetailsCardContainer = ({ header, body }) => {
  const classes = useStyle();
  return (
    <Grid container item className={classes.cardContainer}>
      <Grid container item className={classes.headerContainer}>
        {header}
      </Grid>
      <Grid container item className={classes.bodyContainer} spacing={2}>
        {body}
      </Grid>
    </Grid>
  );
};

MainDetailsCardContainer.propTypes = {
  header: PropTypes.node.isRequired,
  body: PropTypes.node.isRequired,
};

export default MainDetailsCardContainer;
