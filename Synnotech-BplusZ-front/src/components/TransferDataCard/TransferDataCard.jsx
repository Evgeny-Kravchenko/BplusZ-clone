import React from 'react';

import {
  IconButton,
  Typography,
  Grid,
  FormControl,
  InputLabel,
  OutlinedInput,
} from '@material-ui/core';

import VisibilityIcon from '@material-ui/icons/Visibility';

import MainDetailsCardContainer from '@/components/MainDetailsCardContainer';

import transferDataSrc from '@/assets/images/main-details-icons/transfer-data.png';

import useStyle from './styles';

const TransferDataCard = () => {
  const classes = useStyle();
  const header = (
    <>
      <img src={transferDataSrc} alt="general vehicle data" />
      <Typography variant="h4" className={classes.title}>
        Transfer data
      </Typography>
      <div style={{ flexGrow: 1 }} />
      <IconButton size="small">
        <VisibilityIcon className={classes.moreDetailsIcon} />
      </IconButton>
    </>
  );
  const body = (
    <>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>Branch office</InputLabel>
          <OutlinedInput value="Berlin" label="Branch office" disabled />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>Transfer rate</InputLabel>
          <OutlinedInput value="390 €" label="Transfer rate" disabled />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>Start of contract</InputLabel>
          <OutlinedInput value="10.04.2020" label="Start of contract" disabled />
        </FormControl>
      </Grid>
      <Grid item md={6}>
        <FormControl variant="outlined">
          <InputLabel>End of contract</InputLabel>
          <OutlinedInput value="12.03.2021" label="End of contract" disabled />
        </FormControl>
      </Grid>
    </>
  );

  return <MainDetailsCardContainer header={header} body={body} />;
};

export default TransferDataCard;
