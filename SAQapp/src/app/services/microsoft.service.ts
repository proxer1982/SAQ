import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment as env } from '../../environments/environment';
import { endpoint, httpOptions, httpOptionsExt } from '../shared/apis/endpoints';
import { ApiResponse } from '../interfaces/response.interface';
import { Observable, map } from 'rxjs';
import { Usuario } from '../interfaces/usuario.interface';
import { UsuarioDTO } from '../interfaces/userDTOInterface';
import { MapperService } from './mapper.service';
import { requestMS } from '../interfaces/requestMS.interface';

@Injectable({
  providedIn: 'root'
})
export class MicrosoftService {

  getDataUser(email: string): Observable<ApiResponse> {
    email = email.split('@')[0].replace('.', '_') + '@satrack.com';

    var urlApi: string = env.api_PA;
    var data: requestMS = {
      userName: email
    }

    return this._http.post<ApiResponse>(urlApi, data, httpOptionsExt);
  }

  constructor(private _http: HttpClient) { }
}