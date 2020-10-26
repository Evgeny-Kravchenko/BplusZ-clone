const generateVehicleStatusConfig = (t) => ({
  [t('mainPage.checkboxes.onTheRoad')]: false,
  [t('mainPage.checkboxes.exploitation')]: false,
  [t('mainPage.checkboxes.noUse')]: false,
  [t('mainPage.checkboxes.garage')]: false,
  [t('mainPage.checkboxes.all')]: true,
});

export default generateVehicleStatusConfig;
