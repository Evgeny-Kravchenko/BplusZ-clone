const formatter = ({
  id,
  branchOffice,
  constructionType,
  licenseNumber,
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
    licenseNumber,
    brandAndModel: `${manufacturer} ${model}`,
    vehicleClass,
    type,
    info,
    status,
    appointment,
  };
};

export default formatter;
