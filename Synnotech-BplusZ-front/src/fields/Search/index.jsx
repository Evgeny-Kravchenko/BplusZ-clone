import React from 'react';
import PropTypes from 'prop-types';
import { useTranslation } from 'react-i18next';

import { InputAdornment, TextField } from '@material-ui/core';
import SearchIcon from '@material-ui/icons/Search';

import useStyle from './styles';

const Search = ({ handleGlobalSearchOnChange }) => {
  const classes = useStyle();
  const { t } = useTranslation();

  const handleSearchOnChange = (event) => {
    handleGlobalSearchOnChange(event.target.value);
  };

  return (
    <TextField
      color="secondary"
      id="filled-search"
      placeholder={t('mainPage.search')}
      type="search"
      onChange={handleSearchOnChange}
      InputProps={{
        startAdornment: (
          <InputAdornment position="end">
            <SearchIcon />
          </InputAdornment>
        ),
        classes,
      }}
    />
  );
};

Search.propTypes = {
  handleGlobalSearchOnChange: PropTypes.func.isRequired,
};

export default Search;
