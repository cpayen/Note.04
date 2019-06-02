import { BaseModel } from './BaseModel';

export class Space extends BaseModel {
  public name!: string;
  public slug!: string;
  public description?: string;
  public color!: string;
}
