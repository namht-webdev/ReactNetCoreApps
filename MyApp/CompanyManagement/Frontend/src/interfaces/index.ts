export interface Level {
  level_id: string;
  level_name: string;
}

export interface Role {
  role_id: string;
  role_name: string;
}

export interface Student {
  user_id: string;
  full_name: string;
  password_hash: string;
  birth_date: string;
  gender: string;
  address_id: string;
  phone_number: string;
  email: string;
  avatar: string;
  date_start: string;
  date_end: string;
  salary: number;
  department_id: string;
  level_id: string;
  role_id: string;
  is_deleted: boolean;
}

export interface Department {
  department_id: string;
  department_name: string;
  floor: number;
}

export interface Requirement {
  requirement_id: string;
  from_user: string;
  to_user: string;
  date: Date;
  request_message: string;
}

export interface Schedule {
  schedule_id: string;
  user_id: string;
  date: Date;
  note: string;
  time_start: string;
  time_end: string;
}

export interface User {
  user_id: string;
  full_name: string;
  password_hash: string;
  birth_date: Date;
  gender: string;
  ward_id?: string;
  street: string;
  phone_number: string;
  email: string;
  avatar?: string;
  date_start: Date;
  date_end?: Date;
  salary: number;
  department_id: string;
  level_id: string;
  role_id: string;
  is_deleted: boolean;
}

export interface Province {
  province_id: string;
  province_name: string;
}

export interface District {
  province_id: string;
  district_id: string;
  district_name: string;
}

export interface Ward {
  district_id: string;
  ward_id: string;
  ward_name: string;
}

export interface Location {
  ward_id: string;
  district_id: string;
  province_id: string;
}
