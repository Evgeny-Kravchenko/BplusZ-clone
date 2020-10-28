import React from 'react';
import PropTypes from 'prop-types';

import { Grid } from '@material-ui/core';

import useStyle from './styles';

const ContainerView = ({ header, body }) => {
  const classes = useStyle();
  return (
    <Grid container className={classes.container}>
      <Grid item className={classes.header}>
        {header}
      </Grid>
      <Grid item className={classes.body}>
        {body}
      </Grid>
    </Grid>
  );
};

ContainerView.propTypes = {
  header: PropTypes.node.isRequired,
  body: PropTypes.node.isRequired,
};

export default ContainerView;
