import { BaseApi } from './BaseApi';
import { CreateSpace } from '@/models/CreateSpace';
import Axios from 'axios';

export class NoteApi extends BaseApi {

  public static async loadSpaces() {
    try {
      const response = await Axios.get(`${BaseApi.BASE_URL}/spaces`, BaseApi.getConfig());
      return await Promise.resolve(response.data);
    } catch (error) {
      return await Promise.reject(error);
    }
  }

  public static async createSpace(space: CreateSpace) {
    try {
      const response = await Axios.post(`${BaseApi.BASE_URL}/spaces`, space, BaseApi.getConfig());
      return await Promise.resolve(response.data);
    } catch (error) {
      return await Promise.reject(error);
    }
  }

}
