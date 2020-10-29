const generateVorlaufStatusConfig = (t) => [
  {
    key: 'bedarfsanalyse',
    label: t('mainPage.checkboxes.needsReview'),
    value: false,
  },
  {
    key: 'prüfung GF',
    label: t('mainPage.checkboxes.inVerificationByGF'),
    value: false,
  },
  {
    key: 'angebotsphase',
    label: t('mainPage.checkboxes.inProposalStage'),
    value: false,
  },
  {
    key: 'bestellung',
    label: t('mainPage.checkboxes.ordered'),
    value: false,
  },
  {
    key: 'aktivierung',
    label: t('mainPage.checkboxes.activating'),
    value: false,
  },
  {
    key: 'storniert',
    label: t('mainPage.checkboxes.processCanceled'),
    value: false,
  },
  {
    key: 'wird ersetzt',
    label: t('mainPage.checkboxes.toBeReplaced'),
    value: false,
  },
  {
    key: 'alle',
    label: t('mainPage.checkboxes.all'),
    value: true,
  },
];

export default generateVorlaufStatusConfig;
