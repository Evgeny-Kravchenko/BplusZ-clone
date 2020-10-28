import React from 'react';
import PropTypes from 'prop-types';

const DetailsVehicleMain = (props) => {
  const {
    match: { id },
  } = props;
  return <div>{id}</div>;
};

DetailsVehicleMain.propTypes = {
  match: PropTypes.instanceOf(Object).isRequired,
};

export default DetailsVehicleMain;
