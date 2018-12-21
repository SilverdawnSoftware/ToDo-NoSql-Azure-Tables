// ALLOWOVERWRITE-74EA90030308A11B8D9890091E13E5FF

import {Component, OnInit} from '@angular/core';
import {UserService} from '../Services/UserService';
import {UserView,IUserView} from '../models/UserView';


@Component({

  templateUrl: `./UserIndex.html`,
  providers: [
    UserService  ]
})

export class UserIndex implements OnInit{

  rows: any;

  constructor(private userService: UserService) {

  }


  ngOnInit() {

    this.userService.getAll().subscribe(value => this.rows=value);
  }

  delete(userId: number)
  {
    if (confirm('Are you sure you want to delete this?'))
    {
      this.userService.remove(userId).subscribe();

      for(var i = this.rows.length - 1; i >= 0; i--) {
        if(this.rows[i].userId === userId) {
          this.rows.splice(i, 1);
          break;
        }
      }
    }
  }


}



