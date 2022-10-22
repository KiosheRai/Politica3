import { Component } from '@angular/core';
import { faAngleDown } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.css']
})
export class BannerComponent {
  arrowDown = faAngleDown;
}
