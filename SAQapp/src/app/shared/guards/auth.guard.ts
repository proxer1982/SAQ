import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';


export const canActivateTeam: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot,
) => {
  const router = inject(Router);
  const auth = inject(AuthService);

  if (auth.isLoggedIn) {
    return true;
  }

  router.navigate(['/login']);
  return false;
};
