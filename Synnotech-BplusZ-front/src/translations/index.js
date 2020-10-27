import { initReactI18next } from 'react-i18next';
import i18n from 'i18next';
import LanguageDetector from 'i18next-browser-languagedetector';
import Backend from 'i18next-http-backend';

import commonEn from './en';
import commonDe from './de';

const resources = {
  en: {
    translation: commonEn,
  },
  de: {
    translation: commonDe,
  },
};

i18n
  .use(LanguageDetector)
  .use(Backend)
  .use(initReactI18next)
  .init({
    resources,
    fallbackLng: 'de',
    supportedLngs: ['en', 'de'],
    preload: ['de'],
    detection: {
      order: ['cookie'],
      cache: ['cookie'],
    },
  });

export default i18n;
