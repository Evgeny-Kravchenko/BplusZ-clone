import React from 'react';
import { useTranslation } from 'react-i18next';
import { Tabs, Tab, makeStyles, withStyles } from '@material-ui/core';

import generateTabsConfig from './configTabs';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,

    '& .MuiTab-textColorInherit.Mui-selected': {
      color: theme.palette.secondary.main,
    },
  },
}));

const StyledTabs = withStyles((theme) => {
  return {
    root: {
      minHeight: '35px',
      height: '35px',
    },
    indicator: {
      display: 'flex',
      justifyContent: 'center',
      backgroundColor: 'transparent',
      '& > span': {
        width: '100%',
        backgroundColor: theme.palette.secondary.main,
      },
    },
  };
})((props) => {
  return <Tabs {...props} TabIndicatorProps={{ children: <span /> }} />;
});

const StyledTab = withStyles((theme) => ({
  root: {
    minHeight: '23px',
    height: '23px',
    minWidth: '0',
    padding: `0 ${theme.spacing(2.5)}`,
    marginRight: theme.spacing(2.5),
    '&:focus': {
      opacity: 1,
    },
    selected: {
      color: theme.palette.secondary.main,
    },
  },
}))((props) => <Tab disableRipple {...props} />);

const CustomizedTabs = () => {
  const classes = useStyles();
  const [value, setValue] = React.useState(0);
  const { t } = useTranslation();

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <div className={classes.root}>
      <StyledTabs value={value} onChange={handleChange}>
        {generateTabsConfig(t).map((item) => (
          <StyledTab key={item} label={t(item)} />
        ))}
      </StyledTabs>
    </div>
  );
};

export default CustomizedTabs;
