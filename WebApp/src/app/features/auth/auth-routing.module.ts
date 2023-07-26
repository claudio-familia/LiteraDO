import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPage } from './pages/login/login.page';
import { SignInPage } from './pages/sign-in/sign-in.page';

const routes: Routes = [
    {
        path: 'login',
        component: LoginPage
    },
    {
        path: 'sign-in',
        component: SignInPage
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
