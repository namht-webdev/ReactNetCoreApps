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
