import React from 'react';
import { useTranslation } from 'react-i18next';

import { Checkbox, FormControlLabel, FormGroup } from '@material-ui/core';

import useStyle from './styles';

const CheckboxesGroup = ({ tableBestandState, handleTableBestandState, checkboxesListName }) => {
  const classes = useStyle();
  const { t } = useTranslation();

  const checkboxesList = tableBestandState[checkboxesListName];

  const checkBoxesLabels = Object.keys(checkboxesList);

  const handleChange = (event) => {
    if (event.target.name === 'all' && event.target.checked) {
      const newChekboxesList = {};
      Object.keys(checkboxesList).forEach((key) => (newChekboxesList[key] = false));
      handleTableBestandState({
        ...tableBestandState,
        [checkboxesListName]: { ...newChekboxesList, [event.target.name]: event.target.checked },
      });
    } else {
      handleTableBestandState({
        ...tableBestandState,
        [checkboxesListName]: {
          ...checkboxesList,
          [event.target.name]: event.target.checked,
          [t('mainPage.checkboxes.all')]: false,
        },
      });
    }
  };

  return (
    <FormGroup className={classes.checkboxesContainer}>
      {checkBoxesLabels.map((label) => (
        <FormControlLabel
          key={label}
          control={
            <Checkbox checked={checkboxesList[label]} onChange={handleChange} name={label} />
          }
          label={label}
        />
      ))}
    </FormGroup>
  );
};

CheckboxesGroup.propTypes = {};

CheckboxesGroup.defaultProps = {};

export default CheckboxesGroup;
