import { Component } from '@angular/core';
import { faHome } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  homeIcon = faHome
}
