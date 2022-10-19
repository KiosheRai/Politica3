import { Component, OnInit } from '@angular/core';
import {TestData as data} from "../../data/test-data";

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent {
  cards = data.filter((u, i) => i < 12)
}
