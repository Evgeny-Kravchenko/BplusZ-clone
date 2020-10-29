const formatter = ({
  id,
  numberOfInvestment,
  licenseNumber,
  vehicleClass,
  manufacturer,
  model,
  constructionType,
  branchOffice,
  state,
}) => ({
  id,
  numberOfInvestment,
  licenseNumber,
  vehicleClass,
  brandAndModel: `${manufacturer} ${model}`,
  constructionType,
  branchOffice,
  state,
});

export default formatter;
