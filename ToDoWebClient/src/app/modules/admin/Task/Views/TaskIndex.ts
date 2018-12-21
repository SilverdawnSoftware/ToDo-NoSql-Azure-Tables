// ALLOWOVERWRITE-4AA414865812A8C114246F2D1E89E134

import {Component, OnInit} from '@angular/core';
import {TaskService} from '../Services/TaskService';
import {TaskView,ITaskView} from '../models/TaskView';


@Component({

  templateUrl: `./TaskIndex.html`,
  providers: [
    TaskService  ]
})

export class TaskIndex implements OnInit{

  rows: any;

  constructor(private taskService: TaskService) {

  }


  ngOnInit() {

    this.taskService.getAll().subscribe(value => this.rows=value);
  }

  delete(taskId: number)
  {
    if (confirm('Are you sure you want to delete this?'))
    {
      this.taskService.remove(taskId).subscribe();

      for(var i = this.rows.length - 1; i >= 0; i--) {
        if(this.rows[i].taskId === taskId) {
          this.rows.splice(i, 1);
          break;
        }
      }
    }
  }


}



