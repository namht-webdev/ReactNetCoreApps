import { Person } from './Person';

export interface Student extends Person {
  StudentId: string;
  ClassId: string;
}
