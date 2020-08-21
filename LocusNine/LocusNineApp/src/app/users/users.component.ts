import { Component, OnInit } from '@angular/core';
import { IconService } from '../shared/icon.service';
@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(private iconService :IconService) { 
    this.iconService.registerIcons();
  }

  ngOnInit() {
  }

}
