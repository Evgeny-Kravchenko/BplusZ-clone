const formatter = ({
  id,
  numberOfInvestment,
  licenceNumber,
  vehicleClass,
  manufacturer,
  model,
  constructionType,
  branchOffice,
  state,
}) => ({
  id,
  numberOfInvestment,
  licenceNumber,
  vehicleClass,
  brandAndModel: `${manufacturer} ${model}`,
  constructionType,
  branchOffice,
  state,
});

export default formatter;
