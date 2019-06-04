import { BaseModel } from './BaseModel';

export class Page extends BaseModel {
  public title!: string;
  public slug!: string;
  public description?: string;
  public content?: string;
}
