import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { LocalstorageService } from '../services/helpers/localstorage.service';
import { inject } from '@angular/core';
import { LocalStorageKeys } from '../services/helpers/localstoragekeys';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const localStorageHelper = inject(LocalstorageService);
  const router = inject(Router);

  const token = localStorageHelper.getItem(LocalStorageKeys.TokenName);

  if (token) {
    return true;
  }
  else {
    authService.signOut();
    router.navigate(['/signin']);
    return false;

  }
};
