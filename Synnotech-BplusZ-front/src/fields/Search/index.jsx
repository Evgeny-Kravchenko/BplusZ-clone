import React from 'react';
import { useTranslation } from 'react-i18next';

import { InputAdornment, TextField } from '@material-ui/core';
import SearchIcon from '@material-ui/icons/Search';

import useStyle from './styles';

const Search = () => {
  const classes = useStyle();
  const { t } = useTranslation();
  return (
    <TextField
      color="secondary"
      id="filled-search"
      placeholder={t('mainPage.search')}
      type="search"
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

export default Search;
