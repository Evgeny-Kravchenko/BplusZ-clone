import axios from 'axios';

import { LOGIN_ENDPOINT } from '@/constants';

const loginQuery = async (values) => {
  const { data } = await axios.post(LOGIN_ENDPOINT, values);
  return data;
};

export default loginQuery;
