import { Ward } from './Ward';

export interface District {
  district_id: string;
  district_name: string;
  district_name2: string;
  province_id: string;
  wards: Ward[];
}
