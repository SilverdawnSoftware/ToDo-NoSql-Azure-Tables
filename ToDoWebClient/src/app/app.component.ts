import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: ` <router-outlet></router-outlet>
  <router-outlet name="popup"></router-outlet>`,
})
export class AppComponent  {  }
