import { Injectable } from '@angular/core';
import { endpoint } from '../shared/apis/endpoints';
import { HttpClient } from '@angular/common/http';
import { ApiResponse } from '../interfaces/response.interface';
import { Observable } from 'rxjs';
import { environment as env } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PositionService {

  private urlApi: string = env.api + endpoint.POSITIONS;

  constructor(private _http: HttpClient) { }

  getPositions(): Observable<ApiResponse> {
    return this._http.get<ApiResponse>(this.urlApi);
  }
}
