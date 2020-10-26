import React from 'react';
import PropTypes from 'prop-types';

import { Checkbox, FormControlLabel, FormGroup } from '@material-ui/core';

import useStyle from './styles';

const CheckboxesGroup = ({ checkBoxesConfig, checkBoxesDefault, handleOnChange }) => {
  const classes = useStyle();

  const checkBoxesLabels = Object.keys(checkBoxesConfig);

  const handleChange = (event) => {
    if (event.target.name === 'all' && event.target.checked) {
      handleOnChange(checkBoxesDefault);
    } else {
      handleOnChange({
        ...checkBoxesConfig,
        [event.target.name]: event.target.checked,
        all: false,
      });
    }
  };
  return (
    <FormGroup className={classes.checkboxesContainer}>
      {checkBoxesLabels.map((label) => (
        <FormControlLabel
          key={label}
          control={
            <Checkbox checked={checkBoxesConfig[label]} onChange={handleChange} name={label} />
          }
          label={label}
        />
      ))}
    </FormGroup>
  );
};

CheckboxesGroup.propTypes = {
  checkBoxesConfig: PropTypes.instanceOf(Object),
  checkBoxesDefault: PropTypes.instanceOf(Object),
  handleOnChange: PropTypes.func.isRequired,
};

CheckboxesGroup.defaultProps = {
  checkBoxesConfig: {},
  checkBoxesDefault: {},
};

export default CheckboxesGroup;
