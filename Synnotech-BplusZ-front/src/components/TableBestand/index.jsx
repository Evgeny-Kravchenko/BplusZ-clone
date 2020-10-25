import React, { useState } from 'react';
import { useTranslation } from 'react-i18next';

import {
  IconButton,
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

import MoreVertIcon from '@material-ui/icons/MoreVert';
import FiberManualRecordIcon from '@material-ui/icons/FiberManualRecord';

import TablePaginationActions from '@/components/TablePaginationActions';
import TableBestandHeader from '@/components/TableBestandHeader';

import { defineColor, getComparator, stableSort, searchByField } from '@/helpers';

import { OWN_VEHICLE_COLOR, RENT_VEHICLE_COLOR } from '@/constants';

import useStyle from './styles';

import rows from './mock-data';

const TableBestand = () => {
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

  return (
    <Box>
      <TableContainer component={Paper} className={classes.dataGridRoot}>
        <Table aria-label="simple table" onClick={handleCloseSearchInput}>
          <TableBestandHeader
            isSearchByLicenseNumber={isSearchByLicenseNumber}
            setSearchByLicenseNumber={setSearchByLicenseNumber}
            onRequestSort={handleRequestSort}
            order={order}
            orderBy={orderBy}
            onSearchByLicenseNumber={handleSearchByLicenseNumber}
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
                    <IconButton size="small">
                      <MoreVertIcon />
                    </IconButton>
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
        labelRowsPerPage={`${t('mainPage.pagination')}: 10`}
        ActionsComponent={TablePaginationActions}
        component='div'
      />
    </Box>
  );
};

export default TableBestand;
