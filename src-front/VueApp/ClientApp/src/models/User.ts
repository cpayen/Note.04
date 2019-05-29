import { BaseModel } from './BaseModel';

export class User extends BaseModel {
  public userName!: string;
  public email!: string;
  public fullName!: string;
  public roles!: string[];
  public firstName?: string;
  public lastName?: string;
}
