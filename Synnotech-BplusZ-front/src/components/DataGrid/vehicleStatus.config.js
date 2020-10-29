const generateVehicleStatusConfig = (t) => [
  {
    key: 'auf achse',
    label: t('mainPage.checkboxes.onTheRoad'),
    value: false,
  },
  {
    key: 'in verwertung',
    label: t('mainPage.checkboxes.exploitation'),
    value: false,
  },
  {
    key: 'kein einsatz',
    label: t('mainPage.checkboxes.noUse'),
    value: false,
  },
  {
    key: 'werkstatt',
    label: t('mainPage.checkboxes.garage'),
    value: false,
  },
  {
    key: 'alle',
    label: t('mainPage.checkboxes.all'),
    value: true,
  },
];

export default generateVehicleStatusConfig;
