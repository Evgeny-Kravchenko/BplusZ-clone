import React, { useState, useEffect } from 'react';
import { useTranslation } from 'react-i18next';
import PropTypes from 'prop-types';

import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableRow,
  Link,
  Avatar,
  TablePagination,
  Box,
} from '@material-ui/core';

import FiberManualRecordIcon from '@material-ui/icons/FiberManualRecord';

import TablePaginationActions from '@/components/TablePaginationActions';
import TableBestandHeader from '@/components/TableBestandHeader';
import AdditionalMenuGroup from '@/components/AdditionalMenuGroup';

import { defineColor, getComparator, stableSort, searchByField } from '@/helpers';

import { OWN_VEHICLE_COLOR, RENT_VEHICLE_COLOR } from '@/constants';

import useStyle from './styles';

import rows from './mock-data';

import generateAdditionalMenuListConfig from './additionalMenuListConfig';

const TableBestand = ({
  bestandVehicleClass,
  bestandVehicleClassDefault,
  handleBestandVehicleClass,
  bestandVehicleStatus,
  bestandVehicleStatusDefault,
  handleBestandVehicleStatus,
}) => {
  const classes = useStyle();
  const { t } = useTranslation();

  const [page, setPage] = useState(0);
  const [isSearchByLicenseNumber, setSearchByLicenseNumber] = useState(false);
  const [order, setOrder] = useState('asc');
  const [orderBy, setOrderBy] = useState('');
  const [valueForSearchByField, setValueForSearchByField] = useState('');
  const [filedForSearching, setFieldForSearching] = useState('');

  const rowsPerPage = 10;

  const handleSearchByLicenseNumber = (value) => {
    setValueForSearchByField(value);
    setFieldForSearching('licenseNumber');
  };

  const handleRequestSort = (event, property) => {
    const isAsc = orderBy === property && order === 'asc';
    setOrder(isAsc ? 'desc' : 'asc');
    setOrderBy(property);
  };

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
  };

  const handleCloseSearchInput = () => {
    setSearchByLicenseNumber(false);
  };

  window.addEventListener('click', handleCloseSearchInput);

  useEffect(() => {
    return window.removeEventListener('click', handleCloseSearchInput);
  }, []);

  return (
    <Box>
      <TableContainer component={Paper} className={classes.dataGridRoot}>
        <Table aria-label="simple table">
          <TableBestandHeader
            isSearchByLicenseNumber={isSearchByLicenseNumber}
            setSearchByLicenseNumber={setSearchByLicenseNumber}
            onRequestSort={handleRequestSort}
            order={order}
            orderBy={orderBy}
            onSearchByLicenseNumber={handleSearchByLicenseNumber}
            bestandVehicleClass={bestandVehicleClass}
            bestandVehicleClassDefault={bestandVehicleClassDefault}
            handleBestandVehicleClass={handleBestandVehicleClass}
            bestandVehicleStatus={bestandVehicleStatus}
            bestandVehicleStatusDefault={bestandVehicleStatusDefault}
            handleBestandVehicleStatus={handleBestandVehicleStatus}
          />
          <TableBody>
            {stableSort(
              searchByField(valueForSearchByField, rows, filedForSearching),
              getComparator(order, orderBy)
            )
              .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              .map((row, index) => (
                <TableRow key={row.id} className={!(index % 2) ? classes.tableEvenRow : ''}>
                  <TableCell component="th" scope="row">
                    {row.licenseNumber}
                  </TableCell>
                  <TableCell>{row.constrType}</TableCell>
                  <TableCell>{row.brandAndModel}</TableCell>
                  <TableCell>{row.vehicleStatus}</TableCell>
                  <TableCell>
                    <Link href="#branch-office" className={classes.link} underline="always">
                      {row.branchOffice}
                    </Link>
                  </TableCell>
                  <TableCell>
                    <Avatar
                      className={classes.avatar}
                      style={{
                        backgroundColor:
                          row.vehicleBelonging === 'M' ? RENT_VEHICLE_COLOR : OWN_VEHICLE_COLOR,
                      }}
                    >
                      {row.vehicleBelonging}
                    </Avatar>
                  </TableCell>
                  <TableCell>
                    {row.infoLink && (
                      <Link href="#info-link" className={classes.link} underline="always">
                        {row.infoLink}
                      </Link>
                    )}
                  </TableCell>
                  <TableCell className={classes.eventsStatusCell} align="center">
                    <FiberManualRecordIcon
                      className={classes.statusEvents}
                      style={{ color: defineColor(row.eventsStatus) }}
                    />
                  </TableCell>
                  <TableCell className={classes.actionsCell} align="right">
                    <AdditionalMenuGroup menuListConfig={generateAdditionalMenuListConfig(t)} />
                  </TableCell>
                </TableRow>
              ))}
          </TableBody>
        </Table>
      </TableContainer>
      <TablePagination
        className={classes.pagination}
        rowsPerPageOptions={[5, 10, 25]}
        rowsPerPage={rowsPerPage}
        count={rows.length}
        page={page}
        onChangePage={handleChangePage}
        labelRowsPerPage={`${t('mainPage.pagination', { page: 10 })}`}
        ActionsComponent={TablePaginationActions}
        component="div"
      />
    </Box>
  );
};

TableBestand.propTypes = {
  bestandVehicleClass: PropTypes.instanceOf(Object).isRequired,
  bestandVehicleClassDefault: PropTypes.instanceOf(Object).isRequired,
  handleBestandVehicleClass: PropTypes.func.isRequired,
  bestandVehicleStatus: PropTypes.instanceOf(Object).isRequired,
  bestandVehicleStatusDefault: PropTypes.instanceOf(Object).isRequired,
  handleBestandVehicleStatus: PropTypes.func.isRequired,
};

export default TableBestand;
