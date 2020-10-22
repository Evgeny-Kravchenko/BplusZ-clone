import React from 'react';
import PropTypes from 'prop-types';
import { Route } from 'react-router-dom';

const PublicRoute = ({ component: Component, ...rest }) => {
  const { authorized } = rest;
  const renderComponent = (props) => <Component {...props} authorized={authorized} />;
  return <Route {...rest} render={renderComponent} />;
};

PublicRoute.propTypes = {
  component: PropTypes.instanceOf(Object).isRequired,
};

export default PublicRoute;
