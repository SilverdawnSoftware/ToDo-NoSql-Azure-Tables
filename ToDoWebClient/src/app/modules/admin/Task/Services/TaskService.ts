// ALLOWOVERWRITE-A81A285745D7BE875CD2B10B80C83115




import {Injectable} from '@angular/core';
import {RequestOptions, Request, RequestMethod, Headers, Http, Response} from '@angular/http';

import {TaskView} from '../Models/TaskView';
import {Observable} from 'rxjs/Observable';
import {BehaviorSubject} from 'rxjs/BehaviorSubject';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';


@Injectable()
export class TaskService {
  constructor(private http: Http) {
  }



  baseURL: string='';

  getAll(): Promise<TaskView[]> {
    return this.http.get(this.baseURL + `/api/Task/All`)
      .toPromise()
      .then(response => response.json() as TaskView[])
      .catch(this.handleError);
  }
  
  
	 	
  	get(id: number | string): Promise<TaskView> {
     return this.http.get(this.baseURL + `/api/Task/${id}`).toPromise()
       .then(response => response.json() as TaskView)
       .catch(this.handleError);
 	 }
 	 
 	 
 	 add(task: TaskView): Promise<TaskView> {
    return this.http.post(this.baseURL + '/api/Task', task)
      .toPromise()
      .then(response =>  response.json() as TaskView)
      .catch(this.handleError);
  }
 	 
 	 
 	 update(taskId: number,  task: TaskView): Promise<TaskView> {
    return this.http.put(this.baseURL + `/api/Task/${taskId}`, task)
      .toPromise()
      .then(response => response.json() as TaskView)
      .catch(this.handleError);
  }
 	 
 	 remove(taskId: number): Promise<any> {
      return this.http.delete(this.baseURL + `/api/Task/${taskId}`).toPromise();
  }
 	 	 
 	 
  		
		    	
		    	getTasksByUser(userId: number): Promise<TaskView[]> {
    return this.http.get(this.baseURL + `/api/User/${userId}/Tasks`)
      .toPromise()
      .then(response => response.json() as TaskView[])
      .catch(this.handleError);
  }
		    	
  
 private handleError(error: Response | any) {
    // In a real world app, you might use a remote logging infrastructure
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }
  
  }

    
  

	



