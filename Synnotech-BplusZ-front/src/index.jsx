import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router } from 'react-router-dom';

import { CssBaseline, ThemeProvider } from '@material-ui/core';

import { AuthProvider } from '@/contexts/auth';
import { LangProvider } from '@/contexts/language';

import App from '@/App';
import '@/translations';

import theme from '@/theme';

const Root = () => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Router>
        <LangProvider>
          <AuthProvider>
            <App />
          </AuthProvider>
        </LangProvider>
      </Router>
    </ThemeProvider>
  );
};

ReactDOM.render(<Root />, document.getElementById('root'));
