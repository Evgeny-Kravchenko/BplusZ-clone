import React, { Suspense } from 'react';
import { Switch } from 'react-router-dom';

import { LinearProgress } from '@material-ui/core';

import Routes from '@/components/Routes';

import { useAuth } from '@/contexts/auth';

import routes from './routes';

function App() {
  const { authorized } = useAuth();
  return (
    <Suspense fallback={<LinearProgress />}>
      <Switch>
        {routes.map((route) => {
          const routeType = route.private ? 'Private' : 'Public';
          const Route = Routes[routeType];
          return <Route key={route.path} {...route} authorized={authorized} />;
        })}
      </Switch>
    </Suspense>
  );
}

export default App;
