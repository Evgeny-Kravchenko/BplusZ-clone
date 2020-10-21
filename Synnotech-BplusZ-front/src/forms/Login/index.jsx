import React from 'react';
import { Formik, Form, Field } from 'formik';
import { useTranslation } from 'react-i18next';

import { Box, Link, Button, Grid, Typography, CircularProgress } from '@material-ui/core';

import { Email, Password } from '@/fields';
import {
  useStyleForSubmitButton,
  useStyleForBoxOfLink,
  useStyleForTitle,
  useStyleFormGrid,
  useStyleForFormField,
} from './styles';
import generateValidationSchema from './validation-schema';

const LoginForm = () => {
  const formGridClasses = useStyleFormGrid();
  const titleClasses = useStyleForTitle();
  const boxOfLinkClasses = useStyleForBoxOfLink();
  const submitButtonClasses = useStyleForSubmitButton();
  const formFieldClasses = useStyleForFormField();
  const { t } = useTranslation();
  const validationSchema = generateValidationSchema(t);
  return (
    <Grid item className={formGridClasses.root}>
      <Typography className={titleClasses.root} variant="h1">
        {t('authPage.title')}
      </Typography>
      <Formik
        initialValues={{ email: '', password: '' }}
        validationSchema={validationSchema}
        onSubmit={(values, { setSubmitting }) => {
          setTimeout(() => {
            setSubmitting(false);
          }, 2000);
        }}
      >
        {({ isSubmitting }) => {
          return (
            <Form>
              <Box className={formFieldClasses.root} marginBottom={4}>
                <Field
                  fullWidth
                  component={Email}
                  name="email"
                  type="email"
                  label={t('authPage.emailFiledPlaceholder')}
                />
              </Box>
              <Box className={formFieldClasses.root} marginBottom={1.5}>
                <Field
                  fullWidth
                  component={Password}
                  type="password"
                  label={t('authPage.passwordFieldPlaceholder')}
                  name="password"
                />
              </Box>
              <Box className={boxOfLinkClasses.root}>
                <Link href="#forgot-password">{t('authPage.forgotPasswordLink')}</Link>
              </Box>
              <Box>
                <Button
                  className={submitButtonClasses.root}
                  type="submit"
                  variant="contained"
                  color="secondary"
                  disabled={isSubmitting}
                >
                  {isSubmitting ? <CircularProgress size='2rem'/> : t('authPage.signinButton')}
                </Button>
              </Box>
            </Form>
          );
        }}
      </Formik>
    </Grid>
  );
};

export default LoginForm;
