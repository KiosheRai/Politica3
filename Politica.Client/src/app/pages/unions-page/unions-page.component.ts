import { Component } from '@angular/core';
import {TestData as data} from "../../data/test-data";

@Component({
  selector: 'app-unions-page',
  templateUrl: './unions-page.component.html',
  styleUrls: ['./unions-page.component.css']
})
export class UnionsPageComponent {
  cards = data.filter((u, i) => i < 12)
}
