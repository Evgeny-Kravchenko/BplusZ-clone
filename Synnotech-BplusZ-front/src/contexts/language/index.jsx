import React, { useState, createContext, useContext } from 'react';
import { useTranslation } from 'react-i18next';
import PropTypes from 'prop-types';

const lang = localStorage.getItem('language');

export const LangContext = createContext('en');
LangContext.displayName = 'LangContext';

export const LangProvider = ({ children }) => {
  const { i18n } = useTranslation();
  const [currentLanguage, setCurrentLanguage] = useState(lang || i18n.language);

  const handleChangeLanguage = (newLang) => {
    const contextLang = newLang === 'ENG' ? 'en' : 'de';
    localStorage.setItem('language', contextLang);
    i18n.changeLanguage(contextLang);
    setCurrentLanguage(contextLang);
  };

  const contextProps = {
    lang: currentLanguage,
    handleChangeLanguage,
  };

  return <LangContext.Provider value={contextProps}>{children}</LangContext.Provider>;
};

LangProvider.propTypes = {
  children: PropTypes.node.isRequired,
};

export const useLang = () => useContext(LangContext);
