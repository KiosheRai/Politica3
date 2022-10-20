import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomePageComponent} from "./pages/home-page/home-page.component";
import {RulesPageComponent} from "./pages/rules-page/rules-page.component";
import {FractionsPageComponent} from "./pages/fractions-page/fractions-page.component";
import {UnionsPageComponent} from "./pages/unions-page/unions-page.component";

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'rules', component: RulesPageComponent },
  { path: 'fractions', component: FractionsPageComponent },
  { path: 'unions', component: UnionsPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
