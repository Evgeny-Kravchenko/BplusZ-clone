import React from 'react';
import PropTypes from 'prop-types';

import { Checkbox, FormControlLabel, FormGroup } from '@material-ui/core';

import useStyle from './styles';

const CheckboxesGroup = ({ tableBestandState, handleTableBestandState, checkboxesListName }) => {
  const classes = useStyle();

  const checkboxesList = tableBestandState[checkboxesListName];

  const handleChange = (event) => {
    if (event.target.name === 'alle' && event.target.checked) {
      const newChekboxesList = checkboxesList.map(({ label, key }) => {
        if (key === 'alle' && event.target.checked) {
          return { label, key, value: true };
        }
        return { label, key, value: false };
      });
      handleTableBestandState({
        ...tableBestandState,
        [checkboxesListName]: newChekboxesList,
      });
    } else {
      handleTableBestandState({
        ...tableBestandState,
        [checkboxesListName]: checkboxesList.map(({ key, label, value }) => {
          if (key === 'alle') {
            return { key, label, value: false };
          }
          if (event.target.name === key) {
            return { key, label, value: event.target.checked };
          }
          return { key, value, label };
        }),
      });
    }
  };

  return (
    <FormGroup className={classes.checkboxesContainer}>
      {checkboxesList.map(({ label, key, value }) => (
        <FormControlLabel
          key={key}
          control={<Checkbox checked={value} onChange={handleChange} name={key} />}
          label={label}
        />
      ))}
    </FormGroup>
  );
};

CheckboxesGroup.propTypes = {
  tableBestandState: PropTypes.instanceOf(Object).isRequired,
  handleTableBestandState: PropTypes.func.isRequired,
  checkboxesListName: PropTypes.string.isRequired,
};

CheckboxesGroup.defaultProps = {};

export default CheckboxesGroup;
