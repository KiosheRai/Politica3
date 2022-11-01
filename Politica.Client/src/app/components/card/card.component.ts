import {Component, Input, OnInit} from '@angular/core';
import {IFraction} from "../../models/ifraction";

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit{
  @Input() entity : IFraction

  fractionCard : IFraction

  ngOnInit(){
    this.fractionCard = {...this.entity}

    if(this.fractionCard.subtitle.trim().length >= 40){
      this.fractionCard.subtitle = this.fractionCard.subtitle.substring(0,40) + '...'
    }
  }
}
