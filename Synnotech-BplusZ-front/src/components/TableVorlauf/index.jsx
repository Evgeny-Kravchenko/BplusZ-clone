import React, {useEffect, useState} from 'react';
import PropTypes from 'prop-types';
import { useTranslation } from 'react-i18next';

import {
  Paper,
  Table,
  TableContainer,
  TablePagination,
  Box,
  TableBody,
  TableRow,
  TableCell,
  Link,
} from '@material-ui/core';

import TablePaginationActions from '@/components/TablePaginationActions';
import TableVorlaufHeader from '@/components/TableVorlaufHeader';
import AdditionalMenuGroup from '@/components/AdditionalMenuGroup';

import { getComparator, stableSort, searchByField } from '@/helpers';

import useStyle from './styles';

import rows from './mock-data';

import generateAdditionalMenuListConfig from './additionalMenuListConfig';

const TableVorlauf = ({
  vorlaufVehicleClass,
  vorlaufVehicleClassDefault,
  handleVorlaufVehicleClass,
  vorlaufStatus,
  vorlaufDefaultStatus,
  handleVorlaufStatus,
}) => {
  const classes = useStyle();
  const { t } = useTranslation();

  const [page, setPage] = useState(0);
  const [isSearchByLicenseNumber, setSearchByLicenseNumber] = useState(false);
  const [isSearchByInvestNumber, setSearchByInvestNumber] = useState(false);
  const [order, setOrder] = useState('asc');
  const [orderBy, setOrderBy] = useState('');
  const [valueForSearchByField, setValueForSearchByField] = useState('');
  const [filedForSearching, setFieldForSearching] = useState('');

  const rowsPerPage = 10;

  const handleSearchByLicenseNumber = (value) => {
    setValueForSearchByField(value);
    setFieldForSearching('licenseNumber');
  };

  const handleSearchByInvestNumber = (value) => {
    setValueForSearchByField(value);
    setFieldForSearching('investNumber');
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
    setSearchByInvestNumber(false);
  };

  window.addEventListener('click', handleCloseSearchInput);

  useEffect(() => {
    return window.removeEventListener('click', handleCloseSearchInput);
  }, []);

  return (
    <Box>
      <TableContainer component={Paper} className={classes.dataGridRoot}>
        <Table aria-label="simple table">
          <TableVorlaufHeader
            isSearchByLicenseNumber={isSearchByLicenseNumber}
            setSearchByLicenseNumber={setSearchByLicenseNumber}
            isSearchByInvestNumber={isSearchByInvestNumber}
            setSearchByInvestNumber={setSearchByInvestNumber}
            onRequestSort={handleRequestSort}
            order={order}
            orderBy={orderBy}
            onSearchByLicenseNumber={handleSearchByLicenseNumber}
            onSearchByInvestNumber={handleSearchByInvestNumber}
            vorlaufVehicleClass={vorlaufVehicleClass}
            vorlaufVehicleClassDefault={vorlaufVehicleClassDefault}
            handleVorlaufVehicleClass={handleVorlaufVehicleClass}
            vorlaufStatus={vorlaufStatus}
            vorlaufDefaultStatus={vorlaufDefaultStatus}
            handleVorlaufStatus={handleVorlaufStatus}
          />
          <TableBody className={classes.tableBody}>
            {stableSort(
              searchByField(valueForSearchByField, rows, filedForSearching),
              getComparator(order, orderBy)
            )
              .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              .map((row, index) => (
                <TableRow key={row.id} className={!(index % 2) ? classes.tableEvenRow : ''}>
                  <TableCell component="th" scope="row">
                    {row.investNumber}
                  </TableCell>
                  <TableCell>{row.licenseNumber}</TableCell>
                  <TableCell>{row.vehicleClass}</TableCell>
                  <TableCell>{row.brandAndModel}</TableCell>
                  <TableCell>{row.constructionType}</TableCell>
                  <TableCell>{row.vorlaufStatus}</TableCell>
                  <TableCell>
                    <Link href="#branch-office" className={classes.link} underline="always">
                      {row.branchOffice}
                    </Link>
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
        labelRowsPerPage="Rows per page: 10"
        ActionsComponent={TablePaginationActions}
        component="div"
      />
    </Box>
  );
};

TableVorlauf.propTypes = {
  vorlaufVehicleClass: PropTypes.instanceOf(Object).isRequired,
  vorlaufVehicleClassDefault: PropTypes.instanceOf(Object).isRequired,
  handleVorlaufVehicleClass: PropTypes.func.isRequired,
  vorlaufStatus: PropTypes.instanceOf(Object).isRequired,
  vorlaufDefaultStatus: PropTypes.instanceOf(Object).isRequired,
  handleVorlaufStatus: PropTypes.func.isRequired,
};

export default TableVorlauf;
