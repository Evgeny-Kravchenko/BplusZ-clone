import React, { useState } from 'react';

import { Grid, Box } from '@material-ui/core';

import DataToolBar from '@/components/DataToolBar';
import Switcher from '@/components/Switcher';
import TableBestand from '@/components/TableBestand';
import TableVorlauf from '@/components/TableVorlauf';

import useStyle from './styles';

const DataGrid = () => {
  const classes = useStyle();
  const [isDestand, setCurrentTable] = useState(true);

  const handleChangingTable = () => {
    setCurrentTable(!isDestand);
  };

  return (
    <Grid container item className={classes.dataContainer}>
      <DataToolBar />
      <Grid item className={classes.dataGridContainer}>
        <Box my={1.1}>
          <Switcher onChange={handleChangingTable} />
        </Box>
        {isDestand ? <TableBestand /> : <TableVorlauf />}
      </Grid>
    </Grid>
  );
};

export default DataGrid;
