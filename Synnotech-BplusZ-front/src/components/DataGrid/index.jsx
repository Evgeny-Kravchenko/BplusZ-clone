import React, { useState } from 'react';
import { useTranslation } from 'react-i18next';

import { Grid, Box } from '@material-ui/core';

import DataToolBar from '@/components/DataToolBar';
import Switcher from '@/components/Switcher';
import TableBestand from '@/components/TableBestand';
import TableVorlauf from '@/components/TableVorlauf';

import useStyle from './styles';

import generateDefaultBestandTableState from './defaultBestandTableState';
import generateDefaultVorlaufState from './defaultVorlaufTableState';

const DataGrid = () => {
  const classes = useStyle();
  const { t } = useTranslation();

  const [isBestand, setCurrentTable] = useState(true);
  const [tableBestandState, setBestandTableState] = useState(generateDefaultBestandTableState(t));
  const [tableVorlaufState, setVorlaufTableStatus] = useState(generateDefaultVorlaufState(t));

  const handleTableBestandState = (state) => {
    setBestandTableState(state);
  };

  const handleTableVorlaufState = (state) => {
    setVorlaufTableStatus(state);
  };

  const handleChangingTable = () => {
    setCurrentTable(!isBestand);
  };

  return (
    <Grid container item className={classes.dataContainer}>
      <DataToolBar />
      <Grid item className={classes.dataGridContainer}>
        <Box my={1.1}>
          <Switcher onChange={handleChangingTable} />
        </Box>
        {isBestand ? (
          <TableBestand
            tableBestandState={tableBestandState}
            handleTableBestandState={handleTableBestandState}
          />
        ) : (
          <TableVorlauf
            tableVorlaufState={tableVorlaufState}
            handleTableVorlaufState={handleTableVorlaufState}
          />
        )}
      </Grid>
    </Grid>
  );
};

export default DataGrid;
