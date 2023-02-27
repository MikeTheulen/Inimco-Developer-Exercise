import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  baseApiUrl = "https://localhost:7004/api/user";

  add(user: User): Observable<User> {
    return this.http.post<User>(this.baseApiUrl, user);
  }
}
