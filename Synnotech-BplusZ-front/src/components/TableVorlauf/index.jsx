import React from 'react';
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
  CircularProgress,
  Grid,
  Typography,
} from '@material-ui/core';

import TablePaginationActions from '@/components/TablePaginationActions';
import TableVorlaufHeader from '@/components/TableVorlaufHeader';
import AdditionalMenuGroup from '@/components/AdditionalMenuGroup';

import useVorlaufVehicles from '@/queries/useVorlaufVehicles';

import useStyle from './styles';

import generateAdditionalMenuListConfig from './additionalMenuListConfig';

const TableVorlauf = (props) => {
  const classes = useStyle();
  const { t, i18n } = useTranslation();

  const { tableVorlaufState, handleTableVorlaufState } = props;
  const { page } = tableVorlaufState;

  const rowsPerPage = 10;

  const handleChangePage = (event, newPage) => {
    handleTableVorlaufState({
      ...tableVorlaufState,
      page: newPage,
    });
  };

  const { isLoading, resolvedData, isError } = useVorlaufVehicles({ tableVorlaufState, t, i18n });

  let count;
  let result;

  if (resolvedData) {
    count = resolvedData.count;
    result = resolvedData.result;
  }

  return (
    <Box>
      <TableContainer component={Paper} className={classes.dataGridRoot}>
        <Table aria-label="simple table">
          <TableVorlaufHeader
            tableVorlaufState={tableVorlaufState}
            handleTableVorlaufState={handleTableVorlaufState}
          />
          <TableBody>
            {!isLoading &&
              !isError &&
              result.map((row, index) => (
                <TableRow key={row.id} className={!(index % 2) ? classes.tableEvenRow : ''}>
                  <TableCell component="th" scope="row">
                    {row.numberOfInvestment}
                  </TableCell>
                  <TableCell>{row.licenceNumber}</TableCell>
                  <TableCell>{row.vehicleClass}</TableCell>
                  <TableCell>{row.brandAndModel}</TableCell>
                  <TableCell>{row.constructionType}</TableCell>
                  <TableCell>{row.state}</TableCell>
                  <TableCell>
                    <Link href="#branch-office" className={classes.link} underline="always">
                      {row.branchOffice}
                    </Link>
                  </TableCell>
                  <TableCell className={classes.actionsCell} align="right">
                    <AdditionalMenuGroup
                      menuListConfig={generateAdditionalMenuListConfig(t)}
                      id={row.id}
                    />
                  </TableCell>
                </TableRow>
              ))}
          </TableBody>
        </Table>
      </TableContainer>
      {isLoading && (
        <Grid container justify="center" className={classes.loadingContainer}>
          <CircularProgress color="secondary" />
        </Grid>
      )}
      {isError && !isLoading && (
        <Typography variant="body1" align="center" className={classes.noDataMessage} color="error">
          Something went wrong on the server. Try again later.
        </Typography>
      )}
      {!isLoading && !isError && (
        <TablePagination
          className={classes.pagination}
          rowsPerPageOptions={[5, 10, 25]}
          rowsPerPage={rowsPerPage}
          count={count}
          page={page}
          onChangePage={handleChangePage}
          labelRowsPerPage="Rows per page: 10"
          ActionsComponent={TablePaginationActions}
          component="div"
        />
      )}
    </Box>
  );
};

TableVorlauf.propTypes = {
  tableVorlaufState: PropTypes.instanceOf(Object).isRequired,
  handleTableVorlaufState: PropTypes.func.isRequired,
};

export default TableVorlauf;
