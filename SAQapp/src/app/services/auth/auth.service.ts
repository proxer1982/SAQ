import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from '../../interfaces/login.interface';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { ApiResponse } from '../../interfaces/response.interface';
import { environment as env } from '../../../environments/environment';
import { endpoint, httpOptions } from '../../shared/apis/endpoints';
import { Sesion } from '../../interfaces/sesion.interface';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private user: BehaviorSubject<ApiResponse | null>;
  private urlApi: string = env.api + endpoint.GENERATE_TOKEN;

  constructor(private _http: HttpClient) {
    this.user = new BehaviorSubject<ApiResponse | null>(null); // Inicializar con null

    const storedUser = JSON.parse(localStorage.getItem('SAQtoken') || 'null');
    if (storedUser) {
      this.user.next(storedUser);
    }
  }

  login(req: Login): Observable<ApiResponse> {
    return this._http.post<ApiResponse>(this.urlApi, req, httpOptions).pipe(
      map((res: ApiResponse) => {
        if (res.isSuccess) {
          localStorage.setItem('SAQtoken', JSON.stringify(res));
          this.user.next(res);
        }

        return res;
      })
    );
  }

  public get isLoggedIn() {
    return !!this.user.value;
  }

  getUserLogged() {
    if (!this.user.value) {
      return null;
    }

    const resp = this.user.value as ApiResponse;
    if (resp.data != null || resp.data != undefined) {
      return JSON.parse(atob(resp.data.split('.')[1]));
    }

  }

  deleteSessionUser() {
    this.user.next(null);
    localStorage.removeItem('SAQtoken');
  }
}
