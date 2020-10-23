import React, { useState } from 'react';
import { AppBar, Toolbar, Button, Popover, Grid } from '@material-ui/core';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import ExpandLessIcon from '@material-ui/icons/ExpandLess';

import { useAuth } from '@/contexts/auth';

import LogOutIcon from '@/components/LogOutIcon';

import useStyles from './styles';
import partners from './config';

const Header = () => {
  const classes = useStyles();
  const [anchorProfileEl, setAnchorProfileEl] = useState(null);
  const [anchorLanguageMenuEl, setAnchorLanguageMenuEl] = useState(null);
  const [currentLang, setCurrentLang] = useState('ENG');

  const { handleRemoveToken } = useAuth();

  const isProfileMenuOpen = Boolean(anchorProfileEl);
  const isLanguageMenuOpen = Boolean(anchorLanguageMenuEl);

  const handleLanguageMenuOpen = (event) => {
    setAnchorLanguageMenuEl(event.currentTarget);
  };

  const handleLanguageMenuClose = (event) => {
    const currentLanguage = event.nativeEvent.target.textContent === 'English' ? 'ENG' : 'DEU';
    setCurrentLang(currentLanguage);
    setAnchorLanguageMenuEl(null);
  };

  const handleProfileMenuOpen = (event) => {
    setAnchorProfileEl(event.currentTarget);
  };

  const handleProfileMenuClose = (event) => {
    setAnchorProfileEl(null);
    if (event.nativeEvent.target.textContent === 'Log Out') {
      handleRemoveToken();
    }
  };

  const renderProfileMenu = (
    <Popover
      className={classes.paper}
      anchorEl={anchorProfileEl}
      anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}
      keepMounted
      transformOrigin={{ vertical: 'top', horizontal: 'center' }}
      open={isProfileMenuOpen}
      onClose={handleProfileMenuClose}
    >
      <Button
        className={classes.logout}
        startIcon={<LogOutIcon />}
        onClick={handleProfileMenuClose}
        id="btn-logout"
      >
        Log Out
      </Button>
    </Popover>
  );

  const renderLanguageMenu = (
    <Popover
      className={classes.langMenu}
      anchorEl={anchorLanguageMenuEl}
      anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
      keepMounted
      transformOrigin={{ vertical: 'top', horizontal: 'right' }}
      open={isLanguageMenuOpen}
      onClose={handleLanguageMenuClose}
      onClick={handleLanguageMenuClose}
    >
      <Button className={classes.langItem} id="#eng">
        English
      </Button>
      <Button className={classes.langItem} id="#de">
        Deutsch
      </Button>
    </Popover>
  );

  return (
    <>
      <div className={classes.grow}>
        <AppBar position="static">
          <Toolbar>
            <Grid container className={classes.partnersContainer}>
              {partners.map((partner) => (
                <Grid item key={partner.src}>
                  <img src={partner.src} alt={partner.alt} />
                </Grid>
              ))}
            </Grid>
            <div className={classes.grow} />
            <Grid container className={classes.menu}>
              <Grid item>
                <Button
                  onClick={handleLanguageMenuOpen}
                  endIcon={isLanguageMenuOpen ? <ExpandLessIcon /> : <ExpandMoreIcon />}
                >
                  {currentLang}
                </Button>
              </Grid>
              <Grid item>
                <Button
                  onClick={handleProfileMenuOpen}
                  endIcon={isProfileMenuOpen ? <ExpandLessIcon /> : <ExpandMoreIcon />}
                >
                  Matthias Bauch
                </Button>
              </Grid>
            </Grid>
          </Toolbar>
        </AppBar>
        {renderLanguageMenu}
        {renderProfileMenu}
      </div>
    </>
  );
};
export default Header;
