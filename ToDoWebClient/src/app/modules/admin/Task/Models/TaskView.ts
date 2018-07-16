// ALLOWOVERWRITE-A611BD577A147A0AFC726674130AC185


    export interface ITaskView {
      completedDate: string;    	
      dueDate: string;    	
      name: string;    	
      startedDate: string;    	
      status: number;    	
      taskId: number;    	

					    userUserId : number;   
    }
    
    export class TaskView implements ITaskView {
      completedDate: string;    	
      dueDate: string;    	
      name: string;    	
      startedDate: string;    	
      status: number;    	
      taskId: number;    	

					    userUserId : number ;   


	  constructor() {
	  }
    }
