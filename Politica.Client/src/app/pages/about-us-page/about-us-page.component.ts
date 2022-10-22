import { Component } from '@angular/core';
import {adminsList} from "../../data/admins-list";


@Component({
  selector: 'app-about-us-page',
  templateUrl: './about-us-page.component.html',
  styleUrls: ['./about-us-page.component.css']
})
export class AboutUsPageComponent{
  admins = adminsList.filter((u, i) => i < 12)
}
