import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment as env } from '../../environments/environment';
import { endpoint, httpOptions } from '../shared/apis/endpoints';
import { ApiResponse } from '../interfaces/response.interface';
import { Observable, map } from 'rxjs';
import { Usuario } from '../interfaces/usuario.interface';
import { UsuarioDTO } from '../interfaces/userDTOInterface';
import { MapperService } from './mapper.service';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private map = inject(MapperService);
  getAllUsersInactive() {
    var urlApi: string = env.api + endpoint.USER_ALL_INACTIVE;
    return this._http.get<ApiResponse>(urlApi);
  }

  constructor(private _http: HttpClient) { }

  getAllUsersActive(): Observable<ApiResponse> {
    var urlApi: string = env.api + endpoint.USER_ALL_ACTIVE;
    return this._http.get<ApiResponse>(urlApi);
  }

  getUserByMail(mail: string): Observable<ApiResponse> {
    var urlApi: string = env.api + endpoint.USER_BY_MAIL + mail;
    return this._http.get<ApiResponse>(urlApi);
  }

  getUserById(userId: string): Observable<ApiResponse> {
    var urlApi: string = env.api + endpoint.USER_BY_ID + userId;
    return this._http.get<ApiResponse>(urlApi);
  }

  createUser(user: UsuarioDTO): Observable<ApiResponse> {
    var urlApi: string = env.api + endpoint.USER_NEW;
    return this._http.post<ApiResponse>(urlApi, user, httpOptions);
  }

  updateUser(user: UsuarioDTO, userId: string): Observable<ApiResponse> {
    var urlApi: string = env.api + endpoint.USER_UPDATE + userId;

    return this._http.put<ApiResponse>(urlApi, user, httpOptions)
  }

  activeUser(usuario: Usuario): Observable<ApiResponse> {
    var urlApi: string = env.api + endpoint.USER_UPDATE + usuario.userId;
    const user = this.map.mapUsuarioToUserDTO(usuario);
    user.status = 1;

    console.log(user);

    return this._http.put<ApiResponse>(urlApi, user, httpOptions);
  }
  deleteUser(id: string): Observable<ApiResponse> {
    var urlApi: string = env.api + endpoint.USER_DELETE + id;
    return this._http.delete<ApiResponse>(urlApi);
  }
}
