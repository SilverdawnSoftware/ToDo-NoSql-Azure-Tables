// ALLOWOVERWRITE-F186E4D67CFCF72C7B034F39BA2B5F38

import { Component,OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Params, Router }   from '@angular/router';
import { Location }                 from '@angular/common';

import {ITaskView} from "../Models/TaskView";
import {TaskView} from "../Models/TaskView";
import {TaskService} from "../Services/TaskService";

// Add service imports
    		
//Add Target Assoications    

   					
    		
// Add view Models Imports


// Add  Target Assoications view Models
 

@Component({

  templateUrl: `./TaskEdit.html`,
  providers: [
    TaskService 

]
})





        export class TaskEdit implements OnInit {
  taskForm: FormGroup;
  taskView: ITaskView;
  taskId: number=0;
  userUserId : number;   
    
  constructor(private formBuilder: FormBuilder, private taskService: TaskService, private route: ActivatedRoute, private router: Router, private location: Location
  ) {

    this.taskView=new TaskView();
    //route.params.subscribe(params2 => {console.log(params2['id'])});
  }
        
        
        
         ngOnInit() {
    this.taskForm = this.formBuilder.group({
	    				completedDate: new Date().toISOString().substring(0, 10), 
	    				dueDate: new Date().toISOString().substring(0, 10), 
	    				name: "", 
	    				startedDate: new Date().toISOString().substring(0, 10), 
	    				status: 0, 
      
    });
         
       this.route.params.subscribe(params => {
        this.taskId =params['id'];
          if (this.taskId>0) {
        	this.taskService.get(+params['id']).then(task => this.displayTask(task));
      		}
      	});
      	
    
    	 this.route.queryParams.subscribe( params=>{
         this.userUserId=params['userUserId'];
       });
    
      	
      	
		
    }

  update() {
          const taskModel = this.taskForm.value;
          if (this.taskId>0)
          {
            this.taskService.update(this.taskId,taskModel).then(value => this.displayTask(value));
          }
          else
          {
          
          
            this.taskService.add(taskModel).then(value => this.router.navigateByUrl("/admin/task/edit/"+value.taskId));
          }
      }

    displayTask(taskView: TaskView) {
	 	taskView.completedDate=new Date(taskView.completedDate).toISOString().substring(0, 10);
	 	taskView.dueDate=new Date(taskView.dueDate).toISOString().substring(0, 10);
	 	taskView.startedDate=new Date(taskView.startedDate).toISOString().substring(0, 10);
    this.taskForm.reset(taskView);  	
	this.taskView=taskView;	    
    }
    
 }  
 
 
