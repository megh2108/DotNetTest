import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalstorageService {

  constructor() { }

  private isLocalStorageAvailable(): boolean {
    try {
      return typeof localStorage !== 'undefined';
    } catch {
      return false;
    }
  }

  setItem(key: string, value: string): void {
    if (this.isLocalStorageAvailable()) {
      localStorage.setItem(key, value);
    } else {
      console.warn('localStorage is not available.');
    }
  }

  getItem(key: string): string | null | undefined {
    if (this.isLocalStorageAvailable()) {
      return localStorage.getItem(key);
    } else {
      console.warn('localStorage is not available.');
      return null;
    }
  }

  hasItem(key: string): boolean {
    return this.isLocalStorageAvailable() && localStorage.getItem(key) !== null;
  }

  removeItem(key: string): void {
    if (this.isLocalStorageAvailable()) {
      localStorage.removeItem(key);
    } else {
      console.warn('localStorage is not available.');
    }
  }
}
