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
    bestandVehicleClass,
    handleBestandVehicleClass,
    bestandVehicleStatus,
    bestandVehicleStatusDefault,
    bestandVehicleClassDefault,
    handleBestandVehicleStatus,
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
        >
          {!isSearchByLicenseNumber && (
            <IconButton size="small" onClick={handleOpenSearchInput} style={{ marginRight: '5px' }}>
              <SearchIcon className={classes.searchIcon} />
            </IconButton>
          )}
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
        </TableCell>
        <TableCell className={classes.constructorTypeHeader}>
          <FilterBadge
            checkBoxesConfig={bestandVehicleClass}
            checkBoxesDefault={bestandVehicleClassDefault}
            handleOnChangeCheckboxes={handleBestandVehicleClass}
          />
          <TableSortLabel
            active={orderBy === 'constrType'}
            direction={orderBy === 'constrType' ? order : 'asc'}
            onClick={createSortHandler('constrType')}
          >
            {t('mainPage.vehicleClass')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.brandAndModelHeader}>
          <TableSortLabel
            active={orderBy === 'brandAndModel'}
            direction={orderBy === 'brandAndModel' ? order : 'asc'}
            onClick={createSortHandler('brandAndModel')}
          >
            {t('mainPage.brandAndModel')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.vehicleStatusHeader}>
          <FilterBadge
            checkBoxesConfig={bestandVehicleStatus}
            checkBoxesDefault={bestandVehicleStatusDefault}
            handleOnChangeCheckboxes={handleBestandVehicleStatus}
          />
          <TableSortLabel
            active={orderBy === 'vehicleStatus'}
            direction={orderBy === 'vehicleStatus' ? order : 'asc'}
            onClick={createSortHandler('vehicleStatus')}
          >
            {t('mainPage.vehicleStatus')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.branchOfficeHeader}>
          <TableSortLabel
            active={orderBy === 'branchOffice'}
            direction={orderBy === 'branchOffice' ? order : 'asc'}
            onClick={createSortHandler('branchOffice')}
          >
            {t('mainPage.branchOffice')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.artHeader}>
          <TableSortLabel
            active={orderBy === 'vehicleBelonging'}
            direction={orderBy === 'vehicleBelonging' ? order : 'asc'}
            onClick={createSortHandler('vehicleBelonging')}
          >
            {t('mainPage.art')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.infoHeader}>
          <TableSortLabel
            active={orderBy === 'infoLink'}
            direction={orderBy === 'infoLink' ? order : 'asc'}
            onClick={createSortHandler('infoLink')}
          >
            {t('mainPage.info')}
          </TableSortLabel>
        </TableCell>
        <TableCell className={classes.eventsHeader}>
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
  bestandVehicleClass: PropTypes.instanceOf(Object).isRequired,
  bestandVehicleClassDefault: PropTypes.instanceOf(Object).isRequired,
  handleBestandVehicleClass: PropTypes.func.isRequired,
  bestandVehicleStatus: PropTypes.instanceOf(Object).isRequired,
  bestandVehicleStatusDefault: PropTypes.instanceOf(Object).isRequired,
  handleBestandVehicleStatus: PropTypes.func.isRequired,
};

export default TableBestandHeader;
