import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/app/user'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  url = 'http://localhost:5165/api/User';
  
  constructor(private httpClient : HttpClient) { }

  createUser(user: User) {
    return this.httpClient.post(this.url, user);
  }
  getUsers() : Observable<User[]> {
    return this.httpClient.get<User[]>(this.url);
  }
}
