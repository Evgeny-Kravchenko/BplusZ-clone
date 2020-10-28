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

const TableBestandHeader = (props) => {
  const { tableBestandState, handleTableBestandState } = props;
  const { sortField, order, searchValue } = tableBestandState;

  const classes = useStyle();
  const { t } = useTranslation();

  const [isSearchByLicenseNumber, setSearchByLicenseNumber] = useState(false);

  const handleOpenSearchInput = (event) => {
    event.stopPropagation();
    setSearchByLicenseNumber(true);
  };

  const handleCloseSearchInput = () => {
    setSearchByLicenseNumber(false);
  };

  window.addEventListener('click', handleCloseSearchInput);

  useEffect(() => {
    return window.removeEventListener('click', handleCloseSearchInput);
  }, []);

  const handleOnClickSearchInput = (event) => {
    event.stopPropagation();
  };

  const createSortHandler = (property) => () => {
    const isAsc = sortField === property && order === 'asc';
    handleTableBestandState({
      ...tableBestandState,
      sortField: property,
      order: isAsc ? 'desc' : 'asc',
    });
  };

  const handleOnChangeSearchByLicenseNumber = (event) => {
    const value = event.target.value.trim();

    handleTableBestandState({
      ...tableBestandState,
      searchField: 'licenceNumber',
      searchValue: value,
    });
  };

  return (
    <TableHead>
      <TableRow>
        <TableCell
          className={classes.licenseNumberHeader}
          sortDirection={sortField === 'License number' ? order : false}
        >
          {!isSearchByLicenseNumber && (
            <IconButton size="small" onClick={handleOpenSearchInput} style={{ marginRight: '5px' }}>
              <SearchIcon className={classes.searchIcon} />
            </IconButton>
          )}
          {!isSearchByLicenseNumber && (
            <TableSortLabel
              active={sortField === 'licenseNumber'}
              direction={sortField === 'licenseNumber' ? order : 'asc'}
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
              defaultValue={searchValue}
            />
          )}
        </TableCell>
        <TableCell className={classes.constructorTypeHeader}>
          <FilterBadge
            handleTableBestandState={handleTableBestandState}
            checkboxesListName="bestandVehicleClass"
            tableBestandState={tableBestandState}
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
        <TableCell className={classes.vehicleStatusHeader}>
          <FilterBadge
            handleTableBestandState={handleTableBestandState}
            checkboxesListName="bestandVehicleStatus"
            tableBestandState={tableBestandState}
          />
          <TableSortLabel
            active={sortField === 'status'}
            direction={sortField === 'status' ? order : 'asc'}
            onClick={createSortHandler('status')}
          >
            {t('mainPage.vehicleStatus')}
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
        <TableCell className={classes.artHeader}>
          <TableSortLabel
            active={sortField === 'type'}
            direction={sortField === 'type' ? order : 'asc'}
            onClick={createSortHandler('type')}
          >
            {t('mainPage.art')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.infoHeader}>
          <TableSortLabel
            active={sortField === 'info'}
            direction={sortField === 'info' ? order : 'asc'}
            onClick={createSortHandler('info')}
          >
            {t('mainPage.info')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.eventsHeader}>
          <TableSortLabel
            active={sortField === 'appointment'}
            direction={sortField === 'appointment' ? order : 'asc'}
            onClick={createSortHandler('appointment')}
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
  tableBestandState: PropTypes.instanceOf(Object).isRequired,
  handleTableBestandState: PropTypes.func.isRequired,
};

export default TableBestandHeader;
