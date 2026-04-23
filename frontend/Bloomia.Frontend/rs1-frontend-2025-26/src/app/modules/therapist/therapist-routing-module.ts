import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TherapistLayoutComponent } from './therapist-layout/therapist-layout.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { MyClientsComponent } from './my-clients/my-clients.component';

const routes: Routes = [
  {
    path:'',
    component: TherapistLayoutComponent,
    children: [
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
      },
      {
        path: 'home', 
        component: HomeComponent
      },
      {
        path: 'profile',
        component: ProfileComponent
      },
      {
        path: 'my-clients',
        component: MyClientsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TherapistRoutingModule { }
