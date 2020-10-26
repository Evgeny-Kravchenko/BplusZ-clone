const generateVehicleClassConfig = ( t ) => ({
  [t('mainPage.checkboxes.truck')]: false,
  [t('mainPage.checkboxes.car')]: false,
  [t('mainPage.checkboxes.semitrailer')]: false,
  [t('mainPage.checkboxes.van')]: false,
  [t('mainPage.checkboxes.changeVanBody')]: false,
  [t('mainPage.checkboxes.truckTrailer')]: false,
  [t('mainPage.checkboxes.all')]: true,
});

export default generateVehicleClassConfig;
