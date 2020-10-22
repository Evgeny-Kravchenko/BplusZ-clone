import React from 'react';
import PropTypes from 'prop-types';
import { useHistory } from 'react-router-dom';

import { Grid, Typography, Button, Box } from '@material-ui/core';
import ArrowForwardIosIcon from '@material-ui/icons/ArrowForwardIos';

import useStyle from './styles';

const ErrorPage404 = ({ authorized }) => {
  const history = useHistory();
  const classes = useStyle();

  const handleClickOnClick = () => {
    if (authorized) {
      history.push('/');
    } else {
      history.push('/login');
    }
  };

  return (
    <Grid container className={classes.errorPageContainer}>
      <Grid item className={classes.errorImageContainer}>
        <div className="disguiseStyles" />
      </Grid>
      <Grid item container className={classes.messageErrorContainer}>
        <Box className={classes.messagePaper}>
          <Typography variant="h1">404</Typography>
          <Typography variant="h3">Something missing</Typography>
          <Typography variant="body1">
            The page is missing or you assembled the link incorrectly.
          </Typography>
          <Button
            disableRipple
            disableElevation
            disableFocusRipple
            className={classes.buttonToMainPage}
            component="button"
            color="secondary"
            href="#"
            onClick={handleClickOnClick}
            endIcon={<ArrowForwardIosIcon />}
          >
            Go to main page
          </Button>
        </Box>
      </Grid>
    </Grid>
  );
};

ErrorPage404.propTypes = {
  authorized: PropTypes.bool,
};

ErrorPage404.defaultProps = {
  authorized: false,
};

export default ErrorPage404;
