import { Component } from '@angular/core';
import {TestData as data} from "../../data/test-data";

@Component({
  selector: 'app-fractions-page',
  templateUrl: './fractions-page.component.html',
  styleUrls: ['./fractions-page.component.css']
})
export class FractionsPageComponent{
  cards = data.filter((u, i) => i < 12)
}
