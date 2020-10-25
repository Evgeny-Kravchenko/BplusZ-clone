import React from 'react';

import { Grid, Typography } from '@material-ui/core';

import { PREVIEW_DESCRIPTION } from '@/constants';

import { usePreviewGridStyle, usePartnersGridStyles } from './styles';
import partners from './config';

const Preview = () => {
  const previewGridStylesClasses = usePreviewGridStyle();
  const partnersGridStylesClasses = usePartnersGridStyles();
  return (
    <Grid container className={previewGridStylesClasses.root}>
      <Grid
        item
        container
        direction="row"
        alignItems="flex-end"
        className={partnersGridStylesClasses.root}
      >
        {partners.map((partner) => (
          <Grid item key={partner.src} xs={partner.src ? 6 : false} lg={4}>
            <img src={partner.src} alt={partner.alt} />
          </Grid>
        ))}
      </Grid>
      <Grid item>
        <Typography variant="body1">{PREVIEW_DESCRIPTION}</Typography>
      </Grid>
    </Grid>
  );
};

export default Preview;
