import {Component, Input} from '@angular/core';
import {IAdmin} from "../../models/iadmin";

@Component({
  selector: 'app-card-admin',
  templateUrl: './card-admin.component.html',
  styleUrls: ['./card-admin.component.css']
})
export class CardAdminComponent {
  @Input() entity : IAdmin
}
