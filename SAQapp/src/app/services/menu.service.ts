import { Injectable } from '@angular/core';
import { endpoint } from '../shared/apis/endpoints';
import { environment as env } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ApiResponse } from '../interfaces/response.interface';
import { Observable, map } from 'rxjs';
import { Menu } from '../interfaces/menu.interface';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  private urlApi: string = env.api + endpoint.MENU;

  constructor(private _http: HttpClient) { }

  getMenus(): Observable<ApiResponse> {
    return this._http.get<ApiResponse>(this.urlApi).pipe(
      map((res: ApiResponse) => {
        const menus: Menu[] = [];

        res.data.forEach((menuData: Menu) => {
          const menu: Menu = {
            title: menuData.title,
            url: menuData.url,
            icon: menuData.icon,
            submenus: null,
            permissionMenus: menuData.permissionMenus,
            parent: menuData.parent,
            status: menuData.status,
            menuId: menuData.menuId,
            // Otras propiedades del menú según la estructura de tu interfaz Menu
          };

          // Verificar si el menú tiene un menú padre
          if (menuData.parent != 0) {

            // Buscar el menú padre en la lista de menús
            const parentMenu = menus.find(m => m.menuId === menuData.parent);

            // Si se encuentra el menú padre, agregar este menú como menú secundario
            if (parentMenu) {
              if (!parentMenu.submenus) {
                parentMenu.submenus = []; // Inicializar la lista de submenús si aún no existe
              }
              parentMenu.submenus.push(menu);
            }
          } else {
            // Si no tiene menú padre, agregarlo directamente a la lista de menús
            menus.push(menu);
          }
        });

        res.data = menus;
        return res;
      })
    );
  }
}
