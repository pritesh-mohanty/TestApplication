import { FormControl, FormGroup } from '@angular/forms';

export interface User {
    firstName: string;
    lastName: string;
  }
  
export interface IUserFormGroup extends FormGroup {
value: User;

controls: {
    firstName: FormControl;
    lastName: FormControl;
};
}