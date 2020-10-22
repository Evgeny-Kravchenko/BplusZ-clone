import * as Yup from 'yup';

export default (t) =>
  Yup.object().shape({
    email: Yup.string().required(t('authPage.requiredField')).email(t('authPage.invalidEmail')).nullable(),
    password: Yup.string()
      .required(t('authPage.requiredField'))
      .min(4, t('authPage.notEnoughPasswordLength'))
      // .matches(/(?=.*[0-9])/, t('authPage.requiredAtLeastOneNumber'))
      // .matches(/(?=.*[a-z])/, t('authPage.requiredAtLeastOneLowercaseLetter'))
      // .matches(/(?=.*[A-Z])/, t('authPage.requiredAtLeastOneUppercaseLetter')),
  });
