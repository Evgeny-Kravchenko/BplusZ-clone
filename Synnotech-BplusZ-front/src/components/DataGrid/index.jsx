import React, { useState, useEffect } from 'react';
import { useTranslation } from 'react-i18next';

import { Grid, Box, Typography } from '@material-ui/core';

import DataToolBar from '@/components/DataToolBar';
import Switcher from '@/components/Switcher';
import TableBestand from '@/components/TableBestand';
import TableVorlauf from '@/components/TableVorlauf';
import ContainerView from '@/components/ContainerView/ContainerView';

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

  const header = <DataToolBar handleGlobalSearchOnChange={handleGlobalSearchOnChange} />;

  const body = (
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
  );

  return (
    <>
      <Grid container item className={classes.logoBlock}>
        <div className="disguiseStyles" />
        <Typography variant="h1">{t('mainPage.title')}</Typography>
      </Grid>
      <Grid container item className={classes.dataContainer}>
        <ContainerView header={header} body={body} />
      </Grid>
    </>
  );
};

export default DataGrid;
