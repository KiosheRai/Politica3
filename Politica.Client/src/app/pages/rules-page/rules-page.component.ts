import { Component } from '@angular/core';
import { faUserGroup, faFaceFrown, faMap, faComments } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-rules-page',
  templateUrl: './rules-page.component.html',
  styleUrls: ['./rules-page.component.css']
})
export class RulesPageComponent{
  userGroup = faUserGroup
  message = faComments
  map = faMap
  faceFrown = faFaceFrown
}
