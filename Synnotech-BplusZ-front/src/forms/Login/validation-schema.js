import * as Yup from 'yup';
import { INVALID_EMAIL, REQUIRED } from '@/constants';

export default () =>
  Yup.object().shape({
    email: Yup.string().required(REQUIRED).email(INVALID_EMAIL).nullable(),
    password: Yup.string().required(REQUIRED),
  });
