// ALLOWOVERWRITE-F6B971664346DD14880FC4ED0876BD4B




import {Injectable} from '@angular/core';


import {Observable,of} from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import {HttpClient} from '@angular/common/http';

import {TaskView} from '../Models/TaskView';


@Injectable()
export class TaskService {
  constructor(private http: HttpClient) {
  }

  baseURL: string='http://tododotnet.lan:9271';

 getAll(): Observable<TaskView[]> {
    return this.http.get<TaskView[]>(this.baseURL + `/api/Task/All`)
      .pipe(
        catchError(this.handleError('getTasks', [])));
  }  
	 	
 	get(id: number | string): Observable<TaskView> {
		return this.http.get<TaskView>(this.baseURL + `/api/Task/${id}`)
      		.pipe(
         		catchError(this.handleError<TaskView>(`gettaskId=${id}`)
         	)
   		);
 	}
 	 
	add(task: TaskView): Observable<TaskView > {
    	return this.http.post<TaskView>(this.baseURL + '/api/Task', task)
      		.pipe(
    			catchError(this.handleError<TaskView>('addTask')
    		)	
    	);
  	}
 	 
 	 
 	update(taskId: number,  task: TaskView): Observable<TaskView > {
    	return this.http.put<TaskView >(this.baseURL + `/api/Entity/${taskId}`, task)
      		.pipe(
        		catchError(this.handleError<TaskView>('addTask')
        	)
      	);
  	}
 	 
 	 
 	remove(taskId: number): Observable<TaskView > {
     	return this.http.delete<TaskView >(this.baseURL + `/api/Task/${taskId}`)
        	.pipe(
          		catchError(this.handleError<TaskView>('addTask')
          	)
        );
  	} 	  	 
  		  		
		    	
		    	getTasksByUser(userId: number): Observable<TaskView[]> {
    return this.http.get<TaskView[]>(this.baseURL + `/api/User/${userId}/Tasks`)
     .pipe(
        catchError(this.handleError('getTasksByUser', [])));
  }
		    	
   
   	
	/**
	* Handle Http operation that failed.
	* Let the app continue.
	* @param operation - name of the operation that failed
	* @param result - optional value to return as the observable result
	*/
	private handleError<T> (operation = 'operation', result?: T) {
		return (error: any): Observable<T> => {
		
		  // TODO: send the error to remote logging infrastructure
		  console.error(error); // log to console instead
		
		  // TODO: better job of transforming error for user consumption
		 // this.log(`${operation} failed: ${error.message}`);
		
		  // Let the app keep running by returning an empty result.
		  return of(result as T);
		};
	}
   

  }

    
  

	



