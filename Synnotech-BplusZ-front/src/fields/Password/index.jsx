import React, { useState } from 'react';

import {
  IconButton,
  InputAdornment,
  TextField as MuiTextField,
} from '@material-ui/core';
import { fieldToTextField } from 'formik-material-ui';
import VisibilityOutlinedIcon from '@material-ui/icons/VisibilityOutlined';
import VisibilityOffOutlinedIcon from '@material-ui/icons/VisibilityOffOutlined';

const Password = (props) => {
  const [showPassword, setShowPassword] = useState(false);
  const onSwitchPasswordShowing = () => setShowPassword(!showPassword);
  return (
    <MuiTextField
      {...fieldToTextField(props)}
      type={showPassword ? 'text' : 'password'}
      InputProps={{
        endAdornment: (
          <InputAdornment position="end">
            <IconButton onClick={onSwitchPasswordShowing}>
              {!showPassword ? <VisibilityOutlinedIcon /> : <VisibilityOffOutlinedIcon />}
            </IconButton>
          </InputAdornment>
        ),
        inputProps: {
          maxLength: 32,
        },
      }}
    />
  );
};

export default Password;
