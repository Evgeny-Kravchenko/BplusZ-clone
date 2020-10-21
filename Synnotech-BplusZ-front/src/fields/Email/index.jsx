import React, { useCallback } from 'react';
import PropTypes from 'prop-types';

import { fieldToTextField } from 'formik-material-ui';
import { TextField as MuiTextField } from '@material-ui/core';

const Email = (props) => {
  const {
    form: { setFieldValue },
    field: { name },
  } = props;
  const onChange = useCallback(
    (event) => {
      const { value } = event.target;
      setFieldValue(name, value || '');
    },
    [setFieldValue, name]
  );
  return (
    <MuiTextField
      {...fieldToTextField(props)}
      color="secondary"
      onChange={onChange}
    />
  );
};

Email.propTypes = {
  form: PropTypes.instanceOf(Object).isRequired,
  field: PropTypes.instanceOf(Object).isRequired,
};

export default Email;
