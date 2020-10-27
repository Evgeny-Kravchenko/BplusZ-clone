import React from 'react';
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
} from '@material-ui/core';

import FiberManualRecordIcon from '@material-ui/icons/FiberManualRecord';

import TablePaginationActions from '@/components/TablePaginationActions';
import TableBestandHeader from '@/components/TableBestandHeader';
import AdditionalMenuGroup from '@/components/AdditionalMenuGroup';

import { defineColor } from '@/helpers';

import { OWN_VEHICLE_COLOR, RENT_VEHICLE_COLOR } from '@/constants';

import useStyle from './styles';

import rows from './mock-data';

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

  return (
    <Box>
      <TableContainer component={Paper} className={classes.dataGridRoot}>
        <Table aria-label="simple table">
          <TableBestandHeader
            tableBestandState={tableBestandState}
            handleTableBestandState={handleTableBestandState}
          />
          <TableBody>
            {(rowsPerPage > 0
              ? rows.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              : rows
            ).map((row, index) => (
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

TableBestand.propTypes = {};

export default TableBestand;
