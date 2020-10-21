import { initReactI18next } from 'react-i18next';
import i18n from 'i18next';
import LanguageDetector from 'i18next-browser-languagedetector';
import Backend from 'i18next-http-backend';

import commonEn from './en';

const resources = {
  en: {
    translation: commonEn,
  },
};

i18n
  .use(LanguageDetector)
  .use(Backend)
  .use(initReactI18next)
  .init({
    resources,
    fallbackLng: 'en',
    supportedLngs: ['en', 'de'],
    preload: ['en'],
    detection: {
      order: ['cookie'],
      cache: ['cookie'],
    },
  });

export default i18n;
