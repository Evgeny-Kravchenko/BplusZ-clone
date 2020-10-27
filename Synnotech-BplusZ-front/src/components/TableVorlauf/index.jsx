import React from 'react';
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

import useStyle from './styles';

import rows from './mock-data';

import generateAdditionalMenuListConfig from './additionalMenuListConfig';

const TableVorlauf = (props) => {
  const classes = useStyle();
  const { t } = useTranslation();

  const { tableVorlaufState, handleTableVorlaufState } = props;
  const { page } = tableVorlaufState;

  const rowsPerPage = 10;

  const handleChangePage = (event, newPage) => {
    handleTableVorlaufState({
      ...tableVorlaufState,
      page: newPage,
    });
  };

  return (
    <Box>
      <TableContainer component={Paper} className={classes.dataGridRoot}>
        <Table aria-label="simple table">
          <TableVorlaufHeader
            tableVorlaufState={tableVorlaufState}
            handleTableVorlaufState={handleTableVorlaufState}
          />
          <TableBody>
            {(rowsPerPage > 0
              ? rows.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              : rows
            ).map((row, index) => (
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

TableVorlauf.propTypes = {};

export default TableVorlauf;
