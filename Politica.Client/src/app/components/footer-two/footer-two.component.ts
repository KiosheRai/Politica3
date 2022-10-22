import { Component } from '@angular/core';
import { faCopyright } from '@fortawesome/free-regular-svg-icons'

@Component({
  selector: 'app-footer-two',
  templateUrl: './footer-two.component.html',
  styleUrls: ['./footer-two.component.css']
})
export class FooterTwoComponent {
  date = new Date();
  copyrightIcon = faCopyright
}
