import { BaseApi } from './BaseApi';
import { CreateSpace } from '@/models/CreateSpace';
import { UpdateSpace } from '@/models/UpdateSpace';
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

  public static async loadSpaceBySlug(slug: string) {
    try {
      const response = await Axios.get(`${BaseApi.BASE_URL}/spaces/${slug}`, BaseApi.getConfig());
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

  public static async updateSpace(id: string, space: UpdateSpace) {
    try {
      const response = await Axios.put(`${BaseApi.BASE_URL}/spaces/${id}`, space, BaseApi.getConfig());
      return await Promise.resolve(response.data);
    } catch (error) {
      return await Promise.reject(error);
    }
  }

  public static async deleteSpace(id: string) {
    try {
      const response = await Axios.delete(`${BaseApi.BASE_URL}/spaces/${id}`, BaseApi.getConfig());
      return await Promise.resolve(response.data);
    } catch (error) {
      return await Promise.reject(error);
    }
  }

}
