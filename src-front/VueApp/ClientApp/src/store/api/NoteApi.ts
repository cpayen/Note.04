import { BaseApi } from './BaseApi';
import Axios from 'axios';

export class NoteApi extends BaseApi {

  public static async loadSpaces() {
    try {
      const response = await Axios.get(`${BaseApi.BASE_URL}/spaces/`, BaseApi.getConfig());
      return await Promise.resolve(response.data);
    } catch (error) {
      return await Promise.reject(error);
    }
  }

}
