import Axios from 'axios';

const BaseUrl = 'http://localhost:5000/api';

function getConfig() {
  const token: string = sessionStorage.getItem('Note.currentUserToken') || '';
  return {
    headers: {
      Authorization: 'bearer ' + token,
    },
  };
}

const Url = {
  Auth: {
    Login: `${BaseUrl}/auth/login`,
  },
  Profile: {
    Login: `${BaseUrl}/profile/`,
  },
  Spaces: {
    LoadSpaces: `${BaseUrl}/spaces/`,
  },
};

export default {
  async login(userName: string, password: string) {
    try {
      const response = await Axios.post(Url.Auth.Login, {
        userName,
        password,
      });
      return await Promise.resolve(response.data);
    } catch (error) {
      return await Promise.reject(error);
    }
  },
  async setProfileInfo(id: string, email: string, firstName: string, lastName: string) {
    try {
      const response = await Axios.put('http://localhost:5000/api/profile/' + id + '/info', {
        email,
        firstName,
        lastName,
      }, getConfig());
      return await Promise.resolve(response.data);
    } catch (error) {
      return await Promise.reject(error);
    }
  },
  async loadSpaces() {
    try {
      const response = await Axios.get(Url.Spaces.LoadSpaces, getConfig());
      return await Promise.resolve(response.data);
    } catch (error) {
      return await Promise.reject(error);
    }
  },
};
