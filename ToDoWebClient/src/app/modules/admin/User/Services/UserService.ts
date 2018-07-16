// ALLOWOVERWRITE-328751262044EAC01FA5791CAF88A0AA




import {Injectable} from '@angular/core';
import {RequestOptions, Request, RequestMethod, Headers, Http, Response} from '@angular/http';

import {UserView} from '../Models/UserView';
import {Observable} from 'rxjs/Observable';
import {BehaviorSubject} from 'rxjs/BehaviorSubject';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';


@Injectable()
export class UserService {
  constructor(private http: Http) {
  }



  baseURL: string='http://localhost:7071';

  getAll(): Promise<UserView[]> {
    return this.http.get(this.baseURL + `/api/User/All`)
      .toPromise()
      .then(response => response.json() as UserView[])
      .catch(this.handleError);
  }
  
  
	 	
  	get(id: number | string): Promise<UserView> {
     return this.http.get(this.baseURL + `/api/User/${id}`).toPromise()
       .then(response => response.json() as UserView)
       .catch(this.handleError);
 	 }
 	 
 	 
 	 add(user: UserView): Promise<UserView> {
    return this.http.post(this.baseURL + '/api/User', user)
      .toPromise()
      .then(response =>  response.json() as UserView)
      .catch(this.handleError);
  }
 	 
 	 
 	 update(userId: number,  user: UserView): Promise<UserView> {
    return this.http.put(this.baseURL + `/api/User/${userId}`, user)
      .toPromise()
      .then(response => response.json() as UserView)
      .catch(this.handleError);
  }
 	 
 	 remove(userId: number): Promise<any> {
      return this.http.delete(this.baseURL + `/api/User/${userId}`).toPromise();
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

    
  

	



