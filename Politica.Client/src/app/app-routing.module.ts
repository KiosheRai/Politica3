import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomePageComponent} from "./pages/home-page/home-page.component";
import {RulesPageComponent} from "./pages/rules-page/rules-page.component";
import {FractionsPageComponent} from "./pages/fractions-page/fractions-page.component";
import {UnionsPageComponent} from "./pages/unions-page/unions-page.component";
import {AboutUsComponent} from "./components/about-us/about-us.component";
import {AboutUsPageComponent} from "./pages/about-us-page/about-us-page.component";
import {FeedbackPageComponent} from "./pages/feedback-page/feedback-page.component";
import {NotFoundPageComponent} from "./pages/not-found-page/not-found-page.component";
import {FractionPageComponent} from "./pages/fraction-page/fraction-page.component";

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'rules', component: RulesPageComponent },
  { path: 'fractions', component: FractionsPageComponent },
  { path: 'fractions/:id', component: FractionPageComponent },
  { path: 'unions', component: UnionsPageComponent },
  { path: 'about-us', component: AboutUsPageComponent },
  { path: 'feedback', component: FeedbackPageComponent },
  { path: '**', component: NotFoundPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
