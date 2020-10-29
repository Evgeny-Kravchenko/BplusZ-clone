const generateVehicleClassConfig = (t) => [
  {
    key: 'lkw',
    label: t('mainPage.checkboxes.truck'),
    value: false,
  },
  {
    key: 'pkw',
    label: t('mainPage.checkboxes.car'),
    value: false,
  },
  {
    key: 'auflieger',
    label: t('mainPage.checkboxes.semitrailer'),
    value: false,
  },
  {
    key: 'transporter',
    label: t('mainPage.checkboxes.van'),
    value: false,
  },
  {
    key: 'wechselkoffer',
    label: t('mainPage.checkboxes.changeVanBody'),
    value: false,
  },
  {
    key: 'anhänger',
    label: t('mainPage.checkboxes.truckTrailer'),
    value: false,
  },
  {
    key: 'alle',
    label: t('mainPage.checkboxes.all'),
    value: true,
  },
];

export default generateVehicleClassConfig;
