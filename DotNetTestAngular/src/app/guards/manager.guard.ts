import { CanActivateFn, Router } from '@angular/router';
import { LocalstorageService } from '../services/helpers/localstorage.service';
import { LocalStorageKeys } from '../services/helpers/localstoragekeys';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';

export const managerGuard: CanActivateFn = (route, state) => {

  const authService = inject(AuthService);
  const localStorageHelper = inject(LocalstorageService);
  const router = inject(Router);

  const userRoleIdString = localStorageHelper.getItem(LocalStorageKeys.UserRoleId);
  const userRoleId = userRoleIdString ? Number(userRoleIdString) : undefined;

  if (userRoleId == 2) {
    return true;
  }
  else {
    authService.signOut();
    router.navigate(['/signin']);
    return false;

  }
};
