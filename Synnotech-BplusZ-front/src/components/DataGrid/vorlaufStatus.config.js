const generateVorlaufStatusConfig = ( t ) => ({
  [t('mainPage.checkboxes.needsReview')]: false,
  [t('mainPage.checkboxes.inVerificationByGF')]: false,
  [t('mainPage.checkboxes.inProposalStage')]: false,
  [t('mainPage.checkboxes.ordered')]: false,
  [t('mainPage.checkboxes.activating')]: false,
  [t('mainPage.checkboxes.processCanceled')]: false,
  [t('mainPage.checkboxes.toBeReplaced')]: false,
  [t('mainPage.checkboxes.all')]: true,
});

export default generateVorlaufStatusConfig;
