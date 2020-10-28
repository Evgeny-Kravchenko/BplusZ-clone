import React from 'react';

import { Grid, makeStyles } from '@material-ui/core';

const useStyle = makeStyles((theme) => {
  return {
    container: {
      flexDirection: 'column',
      flexWrap: 'nowrap',
      borderRadius: '4px',
      overflow: 'hidden',
    },
    header: {
      height: '81px',
      backgroundColor: theme.palette.primary.main,
    },
    body: {
      backgroundColor: theme.palette.info.main,
    },
  };
});

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

export default ContainerView;
