import { BaseApi } from './BaseApi';
import Axios from 'axios';

export class AuthApi extends BaseApi {

  public static async login(userName: string, password: string) {
    try {
      const response = await Axios.post(`${BaseApi.BASE_URL}/auth/login`, {
        userName,
        password,
      });
      return await Promise.resolve(response.data);
    } catch (error) {
      return await Promise.reject(error);
    }
  }

  public static async setProfileInfo(id: string, email: string, firstName: string, lastName: string) {
    try {
      const response = await Axios.put(`${BaseApi.BASE_URL}/profile/${id}/info`, {
        email,
        firstName,
        lastName,
      }, BaseApi.getConfig());
      return await Promise.resolve(response.data);
    } catch (error) {
      return await Promise.reject(error);
    }
  }

}
