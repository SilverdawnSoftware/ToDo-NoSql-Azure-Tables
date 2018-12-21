// ALLOWOVERWRITE-C2345B952C81DC641B1D4CA5BB8DDB2A




import {Injectable} from '@angular/core';


import {Observable,of} from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import {HttpClient} from '@angular/common/http';

import {UserView} from '../Models/UserView';


@Injectable()
export class UserService {
  constructor(private http: HttpClient) {
  }

  baseURL: string='http://tododotnet.lan:9271';

 getAll(): Observable<UserView[]> {
    return this.http.get<UserView[]>(this.baseURL + `/api/User/All`)
      .pipe(
        catchError(this.handleError('getUsers', [])));
  }  
	 	
 	get(id: number | string): Observable<UserView> {
		return this.http.get<UserView>(this.baseURL + `/api/User/${id}`)
      		.pipe(
         		catchError(this.handleError<UserView>(`getuserId=${id}`)
         	)
   		);
 	}
 	 
	add(user: UserView): Observable<UserView > {
    	return this.http.post<UserView>(this.baseURL + '/api/User', user)
      		.pipe(
    			catchError(this.handleError<UserView>('addUser')
    		)	
    	);
  	}
 	 
 	 
 	update(userId: number,  user: UserView): Observable<UserView > {
    	return this.http.put<UserView >(this.baseURL + `/api/Entity/${userId}`, user)
      		.pipe(
        		catchError(this.handleError<UserView>('addUser')
        	)
      	);
  	}
 	 
 	 
 	remove(userId: number): Observable<UserView > {
     	return this.http.delete<UserView >(this.baseURL + `/api/User/${userId}`)
        	.pipe(
          		catchError(this.handleError<UserView>('addUser')
          	)
        );
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

    
  

	



