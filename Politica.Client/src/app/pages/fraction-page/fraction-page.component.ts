import { Component } from '@angular/core';
import {TestData as data} from "../../data/test-data";
import {IFraction} from "../../models/ifraction";

@Component({
  selector: 'app-fraction-page',
  templateUrl: './fraction-page.component.html',
  styleUrls: ['./fraction-page.component.css']
})
export class FractionPageComponent {
  entity = <IFraction>data.find(value => value.id === "1")

  constructor() {
    console.log(this.entity)
  }
}
