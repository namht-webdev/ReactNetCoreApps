import { District } from './District';

export interface Province {
  province_id: string;
  province_name: string;
  province_name2: string;
  postal_code: string;
  districts: District[];
}
