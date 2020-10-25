import React from 'react';
import PropTypes from 'prop-types';
import { Formik, Form, Field } from 'formik';

import { Box, Link, Button, Grid, Typography, CircularProgress } from '@material-ui/core';

import { Email, Password } from '@/fields';

import { INVALID_EMAIL_OR_PASSOWRD } from '@/constants';

import {
  useStyleForSubmitButton,
  useStyleForBoxOfLink,
  useStyleForTitle,
  useStyleFormGrid,
  useStyleForFormField,
} from './styles';

import generateValidationSchema from './validation-schema';

const LoginForm = ({ onSubmit, isLoading, error }) => {
  const formGridClasses = useStyleFormGrid();
  const titleClasses = useStyleForTitle();
  const boxOfLinkClasses = useStyleForBoxOfLink();
  const submitButtonClasses = useStyleForSubmitButton();
  const formFieldClasses = useStyleForFormField();
  const validationSchema = generateValidationSchema();
  return (
    <Grid item className={formGridClasses.root}>
      <Typography className={titleClasses.root} variant="h1">
        Willkommen im BplusZ Portal
      </Typography>
      <Formik
        initialValues={{ email: '', password: '' }}
        validationSchema={validationSchema}
        onSubmit={onSubmit}
      >
        {() => (
          <Form>
            <Box className={formFieldClasses.root} marginBottom={4}>
              <Field
                fullWidth
                component={Email}
                name="email"
                type="email"
                label="Email"
                disabled={false}
              />
            </Box>
            <Box className={formFieldClasses.root} marginBottom={1.5}>
              <Field
                fullWidth
                component={Password}
                type="password"
                label="Kennwort"
                name="password"
                disabled={false}
              />
            </Box>
            <Box className={boxOfLinkClasses.root}>
              <Link href="#forgot-password" color="secondary">
                Kennwort vergessen
              </Link>
            </Box>

            <Typography className={formGridClasses.errorMessage} variant="body1" color="error">
              {error && INVALID_EMAIL_OR_PASSOWRD}
            </Typography>

            <Box>
              <Button
                className={submitButtonClasses.root}
                type="submit"
                variant="contained"
                color="secondary"
                disabled={isLoading}
              >
                {isLoading ? <CircularProgress size="2rem" /> : 'Anmelden'}
              </Button>
            </Box>
          </Form>
        )}
      </Formik>
    </Grid>
  );
};

LoginForm.propTypes = {
  onSubmit: PropTypes.func.isRequired,
  isLoading: PropTypes.bool.isRequired,
  error: PropTypes.instanceOf(Error),
};
LoginForm.defaultProps = {
  error: null,
};

export default LoginForm;
