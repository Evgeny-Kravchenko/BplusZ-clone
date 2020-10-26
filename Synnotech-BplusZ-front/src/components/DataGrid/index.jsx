import React, { useState } from 'react';
import { useTranslation } from 'react-i18next';

import { Grid, Box } from '@material-ui/core';

import DataToolBar from '@/components/DataToolBar';
import Switcher from '@/components/Switcher';
import TableBestand from '@/components/TableBestand';
import TableVorlauf from '@/components/TableVorlauf';

import useStyle from './styles';

import generateVehicleClassConfig from './vehicleClass.config';
import generateVehicleStatusConfig from './vehicleStatus.config';
import generateVorlaufStatusConfig from './vorlaufStatus.config';

const DataGrid = () => {
  const classes = useStyle();
  const { t } = useTranslation();

  const [isDestand, setCurrentTable] = useState(true);
  const [bestandVehicleClass, setBestandVehicleClass] = useState(generateVehicleClassConfig(t));
  const [bestandVehicleStatus, setBestandVehicleStatus] = useState(generateVehicleStatusConfig(t));
  const [vorlaufVehicleClass, setVorlaufVehicleClass] = useState(generateVehicleClassConfig(t));
  const [vorlaufStatus, setVorlaufStatus] = useState(generateVorlaufStatusConfig(t));

  const handleChangingTable = () => {
    setCurrentTable(!isDestand);
  };

  const handleBestandVehicleClass = (newBestandVehicleClass) => {
    setBestandVehicleClass(newBestandVehicleClass);
  };

  const handleBestandVehicleStatus = (newBestandVehicleStatus) => {
    setBestandVehicleStatus(newBestandVehicleStatus);
  };

  const handleVorlaufVehicleClass = (newVorlaufVehicleClass) => {
    setVorlaufVehicleClass(newVorlaufVehicleClass);
  };

  const handleVorlaufStatus = (newVorlaufStatus) => {
    setVorlaufStatus(newVorlaufStatus);
  };

  return (
    <Grid container item className={classes.dataContainer}>
      <DataToolBar />
      <Grid item className={classes.dataGridContainer}>
        <Box my={1.1}>
          <Switcher onChange={handleChangingTable} />
        </Box>
        {isDestand ? (
          <TableBestand
            bestandVehicleClass={bestandVehicleClass}
            bestandVehicleClassDefault={generateVehicleClassConfig(t)}
            handleBestandVehicleClass={handleBestandVehicleClass}
            bestandVehicleStatus={bestandVehicleStatus}
            bestandVehicleStatusDefault={generateVehicleStatusConfig(t)}
            handleBestandVehicleStatus={handleBestandVehicleStatus}
          />
        ) : (
          <TableVorlauf
            vorlaufVehicleClass={vorlaufVehicleClass}
            vorlaufVehicleClassDefault={generateVehicleClassConfig(t)}
            handleVorlaufVehicleClass={handleVorlaufVehicleClass}
            vorlaufStatus={vorlaufStatus}
            vorlaufDefaultStatus={generateVorlaufStatusConfig(t)}
            handleVorlaufStatus={handleVorlaufStatus}
          />
        )}
      </Grid>
    </Grid>
  );
};

export default DataGrid;
