export class BaseApi {

  public static BASE_URL: string = 'http://localhost:5000/api';

  // protected static getCurrentUserId = () => {
  //   const user: string = sessionStorage.getItem('Note.currentUser') || '';
  //   const jsonUser: any = JSON.parse(user);
  //   return jsonUser.id;
  // }

  protected static getConfig = () => {
    const token: string = sessionStorage.getItem('Note.currentUserToken') || '';
    return {
      headers: {
        Authorization: 'bearer ' + token,
      },
    };
  }
}
