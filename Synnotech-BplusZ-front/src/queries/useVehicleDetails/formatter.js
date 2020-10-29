const formatter = (data) => {
  return {
    licenseNumber: data.generalData.licenseNumber,
    generalData: {
      status: data.generalData.status,
      chassisNumber: data.generalData.chassisNumber,
      vehicleClass: data.generalData.vehicleClass,
      manufacturer: data.generalData.manufacturer,
      model: data.generalData.model,
      currentMileage: data.generalData.mileageDate,
    },
    technicalComponents: {
      manufacturerStructure: data.technicalComponents.manufacturerStructure,
      typeOfConstruction: data.technicalComponents.constructionType,
      loadingPlatform: data.technicalComponents.loadingBoard,
      parkingOfConditioner: data.technicalComponents.standClimate,
    },
    technicalContractData: {
      maintainanceAndRepair: data.technicalContractData.maintainanceAndRepair,
      startMaintainanceAndRepair: data.technicalContractData.startMaintainanceAndRepair,
      endOfMaintainanceAndRepair: data.technicalContractData.endOfMaintainanceAndRepair,
    },
    transferData: {
      branchOffice: data.transferData.branchOffice,
      transferRate: data.transferData.transferCosts,
      startOfContract: data.transferData.startOfRental,
      endOfContract: data.transferData.endOfLease,
    },
  };
};

export default formatter;
