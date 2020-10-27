import React from 'react';
import PropTypes from 'prop-types';
import { useTranslation } from 'react-i18next';

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
  Grid,
  CircularProgress,
  Typography,
} from '@material-ui/core';

import FiberManualRecordIcon from '@material-ui/icons/FiberManualRecord';

import TablePaginationActions from '@/components/TablePaginationActions';
import TableBestandHeader from '@/components/TableBestandHeader';
import AdditionalMenuGroup from '@/components/AdditionalMenuGroup';

import useBestandVehicles from '@/queries/useBestandVehicles';

import { defineColor } from '@/helpers';

import { OWN_VEHICLE_COLOR, RENT_VEHICLE_COLOR } from '@/constants';

import useStyle from './styles';

import generateAdditionalMenuListConfig from './additionalMenuListConfig';

const TableBestand = (props) => {
  const classes = useStyle();
  const { t } = useTranslation();

  const { tableBestandState, handleTableBestandState } = props;
  const { page } = tableBestandState;

  const rowsPerPage = 10;

  const handleChangePage = (event, newPage) => {
    handleTableBestandState({
      ...tableBestandState,
      page: newPage,
    });
  };

  const { isLoading, resolvedData, isError } = useBestandVehicles(tableBestandState);
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
          <TableBestandHeader
            tableBestandState={tableBestandState}
            handleTableBestandState={handleTableBestandState}
          />
          <TableBody>
            {!isLoading &&
              !isError &&
              result.map((row, index) => (
                <TableRow key={row.id} className={!(index % 2) ? classes.tableEvenRow : ''}>
                  <TableCell component="th" scope="row">
                    {row.licenceNumber}
                  </TableCell>
                  <TableCell>{row.vehicleClass}</TableCell>
                  <TableCell>{row.brandAndModel}</TableCell>
                  <TableCell>{row.status}</TableCell>
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
                          row.type[0] === 'M' ? RENT_VEHICLE_COLOR : OWN_VEHICLE_COLOR,
                      }}
                    >
                      {row.type[0]}
                    </Avatar>
                  </TableCell>
                  <TableCell>
                    {row.infoLink && (
                      <Link href="#info-link" className={classes.link} underline="always">
                        {row.info}
                      </Link>
                    )}
                  </TableCell>
                  <TableCell className={classes.eventsStatusCell} align="center">
                    <FiberManualRecordIcon
                      className={classes.statusEvents}
                      style={{ color: defineColor(row.appointment) }}
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
      {isLoading && (
        <Grid container justify="center" className={classes.loadingContainer}>
          <CircularProgress color="secondary" />
        </Grid>
      )}
      {result?.length === 0 && !isError && (
        <Typography variant="body1" align="center" className={classes.noDataMessage}>
          No data with such parameters
        </Typography>
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
          labelRowsPerPage={`${t('mainPage.pagination', { page: 10 })}`}
          ActionsComponent={TablePaginationActions}
          component="div"
        />
      )}
    </Box>
  );
};

TableBestand.propTypes = {
  tableBestandState: PropTypes.instanceOf(Object).isRequired,
  handleTableBestandState: PropTypes.func.isRequired,
};

export default TableBestand;
