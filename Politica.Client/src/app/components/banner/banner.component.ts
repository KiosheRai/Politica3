import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.css']
})
export class BannerComponent implements OnInit {

  ipText = '192.0.0.101'

  constructor() { }

  ngOnInit(): void {
  }

}
