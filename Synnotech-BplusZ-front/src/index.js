import React, { Suspense } from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router } from 'react-router-dom';

import { CssBaseline, ThemeProvider } from '@material-ui/core';

import '@/translations';
import theme from '@/theme';
import App from '@/App';

ReactDOM.render(
  <React.StrictMode>
    <Suspense fallback="Loading...">
      <Router>
        <ThemeProvider theme={theme}>
          <CssBaseline />
          <App />
        </ThemeProvider>
      </Router>
    </Suspense>
  </React.StrictMode>,
  document.getElementById('root')
);
