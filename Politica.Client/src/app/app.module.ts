import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BannerComponent } from './components/banner/banner.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { FooterOneComponent } from './components/footer-one/footer-one.component';
import { FooterTwoComponent } from './components/footer-two/footer-two.component';
import { SliderComponent } from './components/slider/slider.component';
import { CardComponent } from './components/card/card.component';
import { HowToStartComponent } from './components/how-to-start/how-to-start.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { RulesPageComponent } from './pages/rules-page/rules-page.component';
import { HeaderBannerComponent } from './components/header-banner/header-banner.component';
import { ListItemsComponent } from './components/list-items/list-items.component';
import { FractionsPageComponent } from './pages/fractions-page/fractions-page.component';
import { UnionsPageComponent } from './pages/unions-page/unions-page.component';
import { AboutUsPageComponent } from './pages/about-us-page/about-us-page.component';
import { TilesComponent } from './components/tiles/tiles.component';
import { CardAdminComponent } from './components/card-admin/card-admin.component';
import { FeedbackPageComponent } from './pages/feedback-page/feedback-page.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { FractionPageComponent } from './pages/fraction-page/fraction-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    BannerComponent,
    AboutUsComponent,
    FooterOneComponent,
    FooterTwoComponent,
    SliderComponent,
    CardComponent,
    HowToStartComponent,
    HomePageComponent,
    RulesPageComponent,
    HeaderBannerComponent,
    ListItemsComponent,
    FractionsPageComponent,
    UnionsPageComponent,
    AboutUsPageComponent,
    TilesComponent,
    CardAdminComponent,
    FeedbackPageComponent,
    NotFoundPageComponent,
    FractionPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
