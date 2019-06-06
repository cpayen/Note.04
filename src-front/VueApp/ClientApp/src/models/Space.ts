import { BaseModel } from './BaseModel';
import { Page } from './Page';

export class Space extends BaseModel {
  public id!: string;
  public name!: string;
  public slug!: string;
  public description?: string;
  // public owner!: UserLightDTO;
  public pages?: Page[];
}
