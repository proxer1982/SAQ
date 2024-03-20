import { Routes } from '@angular/router';

import { LayoutComponent } from './layout.component';
import { DashBoardComponent } from './pages/dash-board/dash-board.component';
import { ListUsuariosComponent } from './pages/usuarios/list-usuarios/list-usuarios.component';
import { ListUsuariosInactivosComponent } from './pages/usuarios/list-usuarios-inactivos/list-usuarios-inactivos.component';
import { EditUserComponent } from './pages/usuarios/edit-user/edit-user.component';
import { InitComponent } from './pages/usuarios/init/init.component';

export const routes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        children: [
            {
                path: '',
                component: DashBoardComponent,
                data: { title: 'DashBoard' }
            },
            {
                path: 'dashboard',
                component: DashBoardComponent,
                data: { title: 'DashBoard' }
            },
            {
                path: 'init',
                component: InitComponent,
                data: { title: 'Inicio' }
            },
            {
                path: 'usuarios',
                component: ListUsuariosComponent,
                data: { title: 'Usuarios activos' }
            },
            {
                path: 'usuarios/nuevo_usuario',
                component: EditUserComponent,
                data: { title: 'Nuevo usuario' }
            },
            {
                path: 'usuarios/nuevo_usuario/:id',
                component: EditUserComponent,
                data: { title: 'Editar usuario' }
            },
            {
                path: 'usuarios/inactivos',
                component: ListUsuariosInactivosComponent,
                data: { title: 'Usuarios inactivos' }
            }
        ]
    }
];
