import { Component, OnInit } from '@angular/core';
import { faCopyright } from '@fortawesome/free-regular-svg-icons'

@Component({
  selector: 'app-footer-two',
  templateUrl: './footer-two.component.html',
  styleUrls: ['./footer-two.component.css']
})
export class FooterTwoComponent implements OnInit {

  date = new Date();

  copyrightIcon = faCopyright

  constructor() { }

  ngOnInit(): void {
  }

}
