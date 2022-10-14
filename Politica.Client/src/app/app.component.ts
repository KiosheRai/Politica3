import { Component } from '@angular/core';
import { TestData as data} from './data/test-data'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  cards = data.filter((u, i) => i < 12)
}
