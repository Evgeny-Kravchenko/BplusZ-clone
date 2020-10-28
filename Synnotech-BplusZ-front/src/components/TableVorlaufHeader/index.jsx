import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { useTranslation } from 'react-i18next';

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
  const { tableVorlaufState, handleTableVorlaufState } = props;
  const { sortField, order, searchValue, searchField } = tableVorlaufState;

  const classes = useStyle();
  const { t } = useTranslation();

  const [isSearchByLicenseNumber, setSearchByLicenseNumber] = useState(false);
  const [isSearchByInvestNumber, setSearchByInvestNumber] = useState(false);

  const handleOpenSearchByLicenseInput = (event) => {
    event.stopPropagation();
    setSearchByLicenseNumber(true);
  };

  const handleOpenSearchByInvestInput = (event) => {
    event.stopPropagation();
    setSearchByInvestNumber(true);
  };

  const handleCloseSearchInputs = () => {
    setSearchByLicenseNumber(false);
    setSearchByInvestNumber(false);
  };

  const handleOnClickSearchInput = (event) => {
    event.stopPropagation();
  };

  window.addEventListener('click', handleCloseSearchInputs);

  useEffect(() => {
    return window.removeEventListener('click', handleCloseSearchInputs);
  }, []);

  const createSortHandler = (property) => () => {
    const isAsc = sortField === property && order === 'asc';
    handleTableVorlaufState({
      ...tableVorlaufState,
      sortField: property,
      order: isAsc ? 'desc' : 'asc',
    });
  };

  const handleOnChangeSearchInput = (event, searchFieldName) => {
    const value = event.target.value.trim();

    handleTableVorlaufState({
      ...tableVorlaufState,
      searchField: searchFieldName,
      searchValue: value,
    });
  };

  return (
    <TableHead>
      <TableRow>
        <TableCell className={classes.investNumberHeader}>
          {!isSearchByInvestNumber && (
            <IconButton
              size="small"
              onClick={handleOpenSearchByInvestInput}
              style={{ marginRight: '5px' }}
            >
              <SearchIcon className={classes.searchIcon} />
            </IconButton>
          )}
          {!isSearchByInvestNumber && (
            <TableSortLabel
              active={sortField === 'numberOfInvestment'}
              direction={sortField === 'numberOfInvestment' ? order : 'asc'}
              onClick={createSortHandler('numberOfInvestment')}
            >
              {t('mainPage.investNumber')}
            </TableSortLabel>
          )}
          {isSearchByInvestNumber && (
            <TextField
              className={classes.searchByLicenseInput}
              placeholder={t('mainPage.search')}
              variant="outlined"
              onClick={handleOnClickSearchInput}
              onChange={(event) => handleOnChangeSearchInput(event, 'numberOfInvestment')}
              defaultValue={searchField === 'numberOfInvestment' ? searchValue : null}
            />
          )}
        </TableCell>
        <TableCell
          className={classes.licenseNumberHeader}
          sortDirection={sortField === 'licenseNumber' ? order : false}
        >
          {!isSearchByLicenseNumber && (
            <IconButton
              size="small"
              onClick={handleOpenSearchByLicenseInput}
              style={{ marginRight: '5px' }}
            >
              <SearchIcon className={classes.searchIcon} />
            </IconButton>
          )}
          {!isSearchByLicenseNumber && (
            <TableSortLabel
              active={sortField === 'licenceNumber'}
              direction={sortField === 'licenceNumber' ? order : 'asc'}
              onClick={createSortHandler('licenceNumber')}
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
              onChange={(event) => handleOnChangeSearchInput(event, 'licenseNumber')}
              defaultValue={searchField === 'licenseNumber' ? searchValue : null}
            />
          )}
        </TableCell>
        <TableCell className={classes.vehicleClassHeader}>
          <FilterBadge
            handleTableBestandState={handleTableVorlaufState}
            checkboxesListName="vorlaufVehicleClass"
            tableBestandState={tableVorlaufState}
          />
          <TableSortLabel
            active={sortField === 'vehicleClass'}
            direction={sortField === 'vehicleClass' ? order : 'asc'}
            onClick={createSortHandler('vehicleClass')}
          >
            {t('mainPage.vehicleClass')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.brandAndModelHeader}>
          <TableSortLabel
            active={sortField === 'manufacturer'}
            direction={sortField === 'manufacturer' ? order : 'asc'}
            onClick={createSortHandler('manufacturer')}
          >
            {t('mainPage.brandAndModel')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.constructionTypeHeader}>
          <TableSortLabel
            active={sortField === 'constructionType'}
            direction={sortField === 'constructionType' ? order : 'asc'}
            onClick={createSortHandler('constructionType')}
          >
            {t('mainPage.constructionType')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.vorlaufStatusHeader}>
          <FilterBadge
            handleTableBestandState={handleTableVorlaufState}
            checkboxesListName="vorlaufVehicleStatus"
            tableBestandState={tableVorlaufState}
          />
          <TableSortLabel
            active={sortField === 'state'}
            direction={sortField === 'state' ? order : 'asc'}
            onClick={createSortHandler('state')}
          >
            {t('mainPage.vorlaufStatus')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.branchOfficeHeader}>
          <TableSortLabel
            active={sortField === 'branchOffice'}
            direction={sortField === 'branchOffice' ? order : 'asc'}
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
  tableVorlaufState: PropTypes.instanceOf(Object).isRequired,
  handleTableVorlaufState: PropTypes.func.isRequired,
};

export default TableVorlaufHeader;
