import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomePageComponent} from "./pages/home-page/home-page.component";
import {RulesPageComponent} from "./pages/rules-page/rules-page.component";

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'rules', component: RulesPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
