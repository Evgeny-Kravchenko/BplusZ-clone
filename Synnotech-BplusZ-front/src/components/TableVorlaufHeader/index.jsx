import React from 'react';
import { useTranslation } from 'react-i18next';
import PropTypes from 'prop-types';

import {
  IconButton,
  TableCell,
  TableHead,
  TableRow,
  TextField,
  TableSortLabel,
} from '@material-ui/core';

import SearchIcon from '@material-ui/icons/Search';

import FilterBadge from '@/components/FilterBadge';

import useStyle from './styles';

const TableVorlaufHeader = (props) => {
  const {
    isSearchByLicenseNumber,
    setSearchByLicenseNumber,
    isSearchByInvestNumber,
    setSearchByInvestNumber,
    onRequestSort,
    order,
    orderBy,
    onSearchByLicenseNumber,
    onSearchByInvestNumber,
  } = props;

  const classes = useStyle();
  const { t } = useTranslation();

  const handleOpenSearchByLicenseInput = (event) => {
    event.stopPropagation();
    setSearchByLicenseNumber(true);
  };

  const handleOnClickSearchByLicenseInput = (event) => {
    event.stopPropagation();
  };

  const createSortHandler = (property) => (event) => {
    onRequestSort(event, property);
  };

  const handleOnChangeSearchByLicenseNumber = (event) => {
    onSearchByLicenseNumber(event.target.value);
  };

  const handleOpenSearchByInvestNumber = (event) => {
    event.stopPropagation();
    setSearchByInvestNumber(true);
  };

  const handleOnClickSearchByInvestInput = (event) => {
    event.stopPropagation();
  };

  const handleOnChangeSearchByInvestNumber = (event) => {
    onSearchByInvestNumber(event.target.value);
  };

  return (
    <TableHead>
      <TableRow>
        <TableCell className={classes.investNumberHeader} align="right">
          {!isSearchByInvestNumber && (
            <TableSortLabel
              active={orderBy === 'investNumber'}
              direction={orderBy === 'investNumber' ? order : 'asc'}
              onClick={createSortHandler('investNumber')}
            >
              {t('mainPage.investNumber')}
            </TableSortLabel>
          )}
          {isSearchByInvestNumber && (
            <TextField
              className={classes.searchByLicenseInput}
              placeholder={t('mainPage.search')}
              variant="outlined"
              onClick={handleOnClickSearchByInvestInput}
              onChange={handleOnChangeSearchByInvestNumber}
            />
          )}
          {!isSearchByInvestNumber && (
            <IconButton
              size="small"
              onClick={handleOpenSearchByInvestNumber}
              style={{ marginLeft: '5px' }}
            >
              <SearchIcon className={classes.searchIcon} />
            </IconButton>
          )}
        </TableCell>
        <TableCell
          className={classes.licenseNumberHeader}
          sortDirection={orderBy === 'licenseNumber' ? order : false}
          align="right"
        >
          {!isSearchByLicenseNumber && (
            <TableSortLabel
              active={orderBy === 'licenseNumber'}
              direction={orderBy === 'licenseNumber' ? order : 'asc'}
              onClick={createSortHandler('licenseNumber')}
            >
              {t('mainPage.licenseNumber')}
            </TableSortLabel>
          )}
          {isSearchByLicenseNumber && (
            <TextField
              className={classes.searchByLicenseInput}
              placeholder={t('mainPage.search')}
              variant="outlined"
              onClick={handleOnClickSearchByLicenseInput}
              onChange={handleOnChangeSearchByLicenseNumber}
            />
          )}
          {!isSearchByLicenseNumber && (
            <IconButton
              size="small"
              onClick={handleOpenSearchByLicenseInput}
              style={{ marginLeft: '5px' }}
            >
              <SearchIcon className={classes.searchIcon} />
            </IconButton>
          )}
        </TableCell>
        <TableCell className={classes.vehicleClassHeader}>
          <FilterBadge />
          {t('mainPage.vehicleClass')}
        </TableCell>
        <TableCell className={classes.brandAndModelHeader} align="right">
          <TableSortLabel
            active={orderBy === 'brandAndModel'}
            direction={orderBy === 'brandAndModel' ? order : 'asc'}
            onClick={createSortHandler('brandAndModel')}
          >
            {t('mainPage.brandAndModel')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.constructionTypeHeader} align="right">
          <TableSortLabel
            active={orderBy === 'constructionType'}
            direction={orderBy === 'constructionType' ? order : 'asc'}
            onClick={createSortHandler('constructionType')}
          >
            {t('mainPage.constructionType')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.vorlaufStatusHeader} align="right">
          <FilterBadge />
          {t('mainPage.vorlaufStatus')}
        </TableCell>
        <TableCell className={classes.branchOfficeHeader} align="right">
          <TableSortLabel
            active={orderBy === 'branchOffice'}
            direction={orderBy === 'branchOffice' ? order : 'asc'}
            onClick={createSortHandler('branchOffice')}
          >
            {t('mainPage.branchOffice')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.actionsHeader} align="right">
          {t('mainPage.actions')}
        </TableCell>
      </TableRow>
    </TableHead>
  );
};

TableVorlaufHeader.propTypes = {
  isSearchByLicenseNumber: PropTypes.bool.isRequired,
  isSearchByInvestNumber: PropTypes.bool.isRequired,
  setSearchByLicenseNumber: PropTypes.func.isRequired,
  onRequestSort: PropTypes.func.isRequired,
  onSearchByLicenseNumber: PropTypes.func.isRequired,
  onSearchByInvestNumber: PropTypes.func.isRequired,
  setSearchByInvestNumber: PropTypes.func.isRequired,
  order: PropTypes.string.isRequired,
  orderBy: PropTypes.string.isRequired,
};

export default TableVorlaufHeader;
