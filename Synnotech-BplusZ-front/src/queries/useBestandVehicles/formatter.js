const formatter = ({
  id,
  branchOffice,
  constructionType,
  licenceNumber,
  manufacturer,
  model,
  type,
  vehicleClass,
  info,
  status,
  appointment,
}) => {
  return {
    id,
    branchOffice,
    constructionType,
    licenceNumber,
    brandAndModel: `${manufacturer} ${model}`,
    vehicleClass,
    type,
    info,
    status,
    appointment,
  };
};

export default formatter;
