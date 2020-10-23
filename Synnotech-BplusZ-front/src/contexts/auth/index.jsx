import React, { useState, useEffect, createContext, useCallback, useContext, useMemo } from 'react';
import PropTypes from 'prop-types';
import { useMutation } from 'react-query';
import { useHistory } from 'react-router-dom';
import jwtDecode from 'jwt-decode';
import axios from 'axios';

import {
  AUTH_TOKEN_LOCAL_STORAGE_PATH,
  LOGIN_DATA_LOCAL_STORAGE_PATH,
  HOME_PAGE_ROUTE,
} from '@/constants';

import loginQuery from './queries';

const persistedToken = localStorage.getItem(AUTH_TOKEN_LOCAL_STORAGE_PATH);
const defaultAuthorized = Boolean(persistedToken && persistedToken !== 'null');

const DEFAULT_STATE = {
  authorized: false,
  logout: () => {},
};

export const AuthContext = createContext(DEFAULT_STATE);
AuthContext.displayName = 'AuthContext';

export const AuthProvider = ({ children }) => {
  const history = useHistory();
  const [authorized, setAuthorized] = useState(defaultAuthorized);
  const [token, setToken] = useState(defaultAuthorized ? persistedToken : null);
  const [userData, setUserData] = useState();

  useEffect(() => {
    if (token && authorized) {
      setUserData(jwtDecode(token));
    } else {
      setUserData(undefined);
    }
  }, [token, authorized]);

  const handleToken = (_token) => {
    const nextToken = _token;
    const nextTokenData = nextToken ? jwtDecode(nextToken) : {};

    localStorage.setItem(AUTH_TOKEN_LOCAL_STORAGE_PATH, _token);

    localStorage.setItem(LOGIN_DATA_LOCAL_STORAGE_PATH, JSON.stringify(nextTokenData));

    setToken(nextToken);
    setAuthorized(true);
  };

  const handleSetToken = useCallback((response) => {
    handleToken(response.token);
  }, []);

  const handleRemoveToken = useCallback(() => {
    setAuthorized(false);
    setToken(null);
    localStorage.removeItem(LOGIN_DATA_LOCAL_STORAGE_PATH);
    localStorage.removeItem(AUTH_TOKEN_LOCAL_STORAGE_PATH);
  }, []);

  const redirect = () => {
    history.push(HOME_PAGE_ROUTE);
  };

  const loginMutation = useMutation(loginQuery, {
    onSuccess: (_token) => {
      handleSetToken(_token);
      redirect();
    },
  });

  const interceptors = useMemo(
    () => ({
      request: (config) => {
        return {
          ...config,
          headers: {
            ...config.headers,
            Authorization: token ? `Bearer ${token}` : '',
          },
        };
      },
      error: (error) => {
        return Promise.reject(error);
      },
      response: (response) => {
        return response;
      },
    }),
    [token]
  );

  useEffect(() => {
    const reqInterceptor = axios.interceptors.request.use(interceptors.request, interceptors.error);

    const resInterceptor = axios.interceptors.response.use(
      interceptors.response,
      interceptors.error
    );

    return () => {
      axios.interceptors.request.eject(reqInterceptor);
      axios.interceptors.response.eject(resInterceptor);
    };
  }, [interceptors]);

  const contextProps = {
    authorized,
    loginMutation,
    token,
    userData,
    handleRemoveToken,
  };

  return <AuthContext.Provider value={contextProps}>{children}</AuthContext.Provider>;
};

AuthProvider.propTypes = {
  children: PropTypes.node.isRequired,
};

export const useAuth = () => useContext(AuthContext);
