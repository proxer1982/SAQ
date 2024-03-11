import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { canActivateTeam } from './shared/guards/auth.guard';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
    },
    {
        path: 'login',
        component: LoginComponent,
    },
    {
        path: 'app',
        loadChildren: () => import('./components/layout/layout.routes').then(m => m.routes),
        canActivate: [canActivateTeam]
    },
    {
        path: '**',
        redirectTo: 'login',
        pathMatch: 'full'
    }
];
