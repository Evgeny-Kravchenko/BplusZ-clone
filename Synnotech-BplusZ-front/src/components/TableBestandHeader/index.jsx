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

const TableBestandHeader = (props) => {
  const {
    isSearchByLicenseNumber,
    setSearchByLicenseNumber,
    onRequestSort,
    order,
    orderBy,
    onSearchByLicenseNumber,
  } = props;

  const classes = useStyle();
  const { t } = useTranslation();

  const handleOpenSearchInput = (event) => {
    event.stopPropagation();
    setSearchByLicenseNumber(true);
  };

  const handleOnClickSearchInput = (event) => {
    event.stopPropagation();
  };

  const createSortHandler = (property) => (event) => {
    onRequestSort(event, property);
  };

  const handleOnChangeSearchByLicenseNumber = (event) => {
    onSearchByLicenseNumber(event.target.value);
  };

  return (
    <TableHead>
      <TableRow>
        <TableCell
          className={classes.licenseNumberHeader}
          sortDirection={orderBy === 'License number' ? order : false}
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
              onClick={handleOnClickSearchInput}
              onChange={handleOnChangeSearchByLicenseNumber}
            />
          )}
          {!isSearchByLicenseNumber && (
            <IconButton size="small" onClick={handleOpenSearchInput} style={{ marginLeft: '5px' }}>
              <SearchIcon className={classes.searchIcon} />
            </IconButton>
          )}
        </TableCell>
        <TableCell className={classes.brandAndModelHeader}>
          <FilterBadge />
          {t('mainPage.vehicleClass')}
        </TableCell>
        <TableCell className={classes.constructorTypeHeader} align="right">
          <TableSortLabel
            active={orderBy === 'brandAndModel'}
            direction={orderBy === 'brandAndModel' ? order : 'asc'}
            onClick={createSortHandler('brandAndModel')}
          >
            {t('mainPage.brandAndModel')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.vehicleStatusHeader}>
          <FilterBadge />
          {t('mainPage.vehicleStatus')}
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
        <TableCell className={classes.artHeader} align="right">
          <TableSortLabel
            active={orderBy === 'vehicleBelonging'}
            direction={orderBy === 'vehicleBelonging' ? order : 'asc'}
            onClick={createSortHandler('vehicleBelonging')}
          >
            {t('mainPage.art')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.infoHeader} align="right">
          <TableSortLabel
            active={orderBy === 'infoLink'}
            direction={orderBy === 'infoLink' ? order : 'asc'}
            onClick={createSortHandler('infoLink')}
          >
            {t('mainPage.info')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.eventsHeader} align="right">
          <TableSortLabel
            active={orderBy === 'eventsStatus'}
            direction={orderBy === 'eventsStatus' ? order : 'asc'}
            onClick={createSortHandler('eventsStatus')}
          >
            {t('mainPage.events')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.actionsHeader} align="right">
          {t('mainPage.actions')}
        </TableCell>
      </TableRow>
    </TableHead>
  );
};

TableBestandHeader.propTypes = {
  isSearchByLicenseNumber: PropTypes.bool.isRequired,
  setSearchByLicenseNumber: PropTypes.func.isRequired,
  onRequestSort: PropTypes.func.isRequired,
  order: PropTypes.string.isRequired,
  orderBy: PropTypes.string.isRequired,
  onSearchByLicenseNumber: PropTypes.func.isRequired,
};

export default TableBestandHeader;
