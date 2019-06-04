import { BaseModel } from './BaseModel';
import { Page } from './Page';

export class Space extends BaseModel {
  public name!: string;
  public slug!: string;
  public description?: string;
  public color!: string;
  // public ownerId!: string;
  public pages?: Page[];
}
