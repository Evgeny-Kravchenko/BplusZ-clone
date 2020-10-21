import React, { Suspense } from 'react';
import { Switch } from 'react-router-dom';

import { LinearProgress } from '@material-ui/core';

import Routes from '@/components/Routes';
import routes from './routes';

function App() {
  return (
    <Suspense fallback={<LinearProgress />}>
      <Switch>
        {routes.map((route) => {
          const routeType = route.private ? 'Private' : 'Public';
          const Route = Routes[routeType];
          return <Route key={route.path} authorized {...route} />;
        })}
      </Switch>
    </Suspense>
  );
}

export default App;
