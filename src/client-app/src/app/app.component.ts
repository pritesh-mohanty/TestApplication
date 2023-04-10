import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IUserFormGroup, User } from 'src/app/user'
import { UserService } from 'src/service/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})

export class AppComponent implements OnInit {
  form: IUserFormGroup;
  title = 'bidone-app';
  users: User[] | undefined;

  constructor(private _formBuilder: FormBuilder, private userService : UserService) {
    this.form = this._formBuilder.group({
      firstName: [''],
      lastName: ['']
    }) as IUserFormGroup;
  }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(data => {
      this.users = data;      
    });
  }

  onSubmit() {
    if (this.form.valid) {
      const newUser : User = {
        firstName: this.form.value.firstName,
        lastName: this.form.value.lastName
      }
      this.userService.createUser(newUser).subscribe(data => {
        this.users?.push(newUser);
      });
    }
  }
}
