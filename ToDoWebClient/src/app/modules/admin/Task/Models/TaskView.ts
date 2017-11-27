// ALLOWOVERWRITE-C3273BADD266A6B39F944DC297BADD58


    export interface ITaskView {
      completedDate: string;    	
      dueDate: string;    	
      name: string;    	
      startedDate: string;    	
      status: number;    	
      taskId: number;    	

					    userEmail : string;   
					    userUserId : number;   
    }
    
    export class TaskView implements ITaskView {
      completedDate: string;    	
      dueDate: string;    	
      name: string;    	
      startedDate: string;    	
      status: number;    	
      taskId: number;    	

					    userEmail : string;   
					    userUserId : number ;   


	  constructor() {
	  }
    }
