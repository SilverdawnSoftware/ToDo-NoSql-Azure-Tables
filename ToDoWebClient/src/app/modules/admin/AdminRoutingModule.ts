// ALLOWOVERWRITE-E8D99C3EC0CB822AE5AD686C8B30E7CC


import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {UserIndex} from './User/Views/UserIndex'
import {UserEdit} from './User/Views/UserEdit'
import {TaskIndex} from './Task/Views/TaskIndex'
import {TaskEdit} from './Task/Views/TaskEdit'

const appRoutes: Routes = [
  
  {
    path: 'admin/user/',
    component: UserIndex,

  },
  {
    path: 'admin/user/edit/:id',
    component: UserEdit
  },
  {
    path: 'admin/user/add',
    component: UserEdit
  },
  
  
  {
    path: 'admin/task/',
    component: TaskIndex,

  },
  {
    path: 'admin/task/edit/:id',
    component: TaskEdit
  },
  {
    path: 'admin/task/add',
    component: TaskEdit
  },
  
  { path: '',   redirectTo: '/admin/user', pathMatch: 'full' },
  { path: '**', component: UserIndex }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes )
  ],
  exports: [
    RouterModule
  ],
  providers: [
  ]
})
export class AdminRoutingModule { }


