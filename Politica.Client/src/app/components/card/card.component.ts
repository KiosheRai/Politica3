import { Component, Input } from '@angular/core';
import {IFraction} from "../../models/ifraction";

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent {
  @Input() entity : IFraction
}
