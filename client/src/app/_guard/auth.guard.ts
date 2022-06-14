import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { map, Observable } from 'rxjs';
import { AccountService } from '../account/account.service';
import { IUser } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private accountService: AccountService, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map((auth: IUser) => {
        if (auth === null || auth.token === '') {
          this.router.navigate(['account/login'], {queryParams: {returnUrl: state.url}});
        }
        return true;
      })
    );
  }
  
}
