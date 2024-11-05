import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { LocalstorageService } from '../services/helpers/localstorage.service';
import { LocalStorageKeys } from '../services/helpers/localstoragekeys';

export const employeeGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const localStorageHelper = inject(LocalstorageService);
  const router = inject(Router);

  const userRoleIdString = localStorageHelper.getItem(LocalStorageKeys.UserRoleId);
  const userRoleId = userRoleIdString ? Number(userRoleIdString) : undefined;

  if (userRoleId == 3) {
    return true;
  }
  else {
    authService.signOut();
    router.navigate(['/signin']);
    return false;

  }
};
