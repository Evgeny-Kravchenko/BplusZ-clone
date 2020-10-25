import React from 'react';
import PropTypes from 'prop-types';

import { Checkbox, FormControlLabel, FormGroup } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

const useStyle = makeStyles((theme) => ({
  checkboxesContainer: {
    width: '205px',
    padding: theme.spacing(1.5),

    '& .MuiFormControlLabel-root': {
      fontSize: '1.2rem',
    },
  },
}));

const CheckboxesGroup = ({ checkBoxes }) => {
  const classes = useStyle();
  const [state, setState] = React.useState({
    ...checkBoxes,
  });
  const checkBoxesLabels = Object.keys(checkBoxes);

  const handleChange = (event) => {
    setState({ ...state, [event.target.name]: event.target.checked });
  };
  return (
    <FormGroup className={classes.checkboxesContainer} column>
      {checkBoxesLabels.map((label) => (
        <FormControlLabel
          control={<Checkbox checked={state[label]} onChange={handleChange} name={label} />}
          label={label}
        />
      ))}
    </FormGroup>
  );
};

CheckboxesGroup.propTypes = {
  checkBoxes: PropTypes.arrayOf(PropTypes.instanceOf(Object)).isRequired,
};

export default CheckboxesGroup;
