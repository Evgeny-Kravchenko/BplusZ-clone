import React from 'react';
import { useTranslation } from 'react-i18next';

import { Grid, Typography } from '@material-ui/core';

import { usePreviewGridStyle, usePartnersGridStyles } from './styles';
import partners from './config';

const Preview = () => {
  const previewGridStylesClasses = usePreviewGridStyle();
  const partnersGridStylesClasses = usePartnersGridStyles();
  const { t } = useTranslation();
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
          <Grid item key={partner.src} xs={partner.src ? 6 : false} xl={4}>
            <img src={partner.src} alt={partner.alt} />
          </Grid>
        ))}
      </Grid>
      <Grid item>
        <Typography variant="body1">{t('authPage.description')}</Typography>
      </Grid>
    </Grid>
  );
};

export default Preview;
