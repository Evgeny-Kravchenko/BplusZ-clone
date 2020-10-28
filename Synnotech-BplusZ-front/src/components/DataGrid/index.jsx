import React, { useState, useEffect } from 'react';
import { useTranslation } from 'react-i18next';

import { Grid, Box } from '@material-ui/core';

import DataToolBar from '@/components/DataToolBar';
import Switcher from '@/components/Switcher';
import TableBestand from '@/components/TableBestand';
import TableVorlauf from '@/components/TableVorlauf';

import { useLang } from '@/contexts/language';

import useStyle from './styles';

import generateDefaultBestandTableState from './defaultBestandTableState';
import generateDefaultVorlaufState from './defaultVorlaufTableState';

const DataGrid = () => {
  const classes = useStyle();
  const { t } = useTranslation();

  const [isBestand, setCurrentTable] = useState(true);
  const [tableBestandState, setBestandTableState] = useState(generateDefaultBestandTableState(t));
  const [tableVorlaufState, setVorlaufTableStatus] = useState(generateDefaultVorlaufState(t));

  const { lang } = useLang();

  useEffect(() => {
    setBestandTableState(generateDefaultBestandTableState(t));
    setVorlaufTableStatus(generateDefaultVorlaufState(t));
  }, [lang, t]);

  const handleTableBestandState = (state) => {
    setBestandTableState(state);
  };

  const handleTableVorlaufState = (state) => {
    setVorlaufTableStatus(state);
  };

  const handleChangingTable = () => {
    setCurrentTable(!isBestand);
  };

  const handleGlobalSearchOnChange = (value) => {
    if (isBestand) {
      handleTableBestandState({ ...tableBestandState, searchValue: value, searchField: '' });
    } else {
      handleTableVorlaufState({ ...tableVorlaufState, searchValue: value, searchFiled: '' });
    }
  };

  return (
    <Grid container item className={classes.dataContainer}>
      <DataToolBar handleGlobalSearchOnChange={handleGlobalSearchOnChange} />
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
