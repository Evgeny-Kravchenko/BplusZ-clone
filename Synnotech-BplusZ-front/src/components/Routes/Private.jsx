import React, { useCallback } from 'react';
import PropTypes from 'prop-types';
import { Redirect, Route } from 'react-router-dom';

import { AUTH_PAGE_ROUTE } from '@/constants';

const PrivateRoute = ({ component: Component, authorized, ...rest }) => {
  const renderComponent = useCallback(
    (props) => (authorized ? <Component {...props} /> : <Redirect to={AUTH_PAGE_ROUTE} />),
    [authorized]
  );
  return <Route {...rest} render={renderComponent} />;
};

PrivateRoute.propTypes = {
  component: PropTypes.instanceOf(Object).isRequired,
  authorized: PropTypes.bool,
};

PrivateRoute.defaultProps = {
  authorized: false,
};

export default PrivateRoute;
