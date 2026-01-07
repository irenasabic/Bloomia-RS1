import { Component, inject,OnInit } from '@angular/core';
import { CurrentUserService } from '../../../core/services/auth/current-user.service';
import { ClientsApiService } from '../../../api-services/clients/clients-api.service';
import { GetClientProfileByIdQueryDTO } from '../../../api-services/clients/clients-api.models';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit{

  private apiService=inject(ClientsApiService);
  private router=inject(Router);
  client:GetClientProfileByIdQueryDTO|null=null;


  isLoading=false;
  errorMessage:string|null=null;

  ngOnInit(): void {
    this.getClientBasicInfo();
  }

  getClientBasicInfo(){
    this.isLoading=true;
    this.errorMessage=null;

    this.apiService.getMyProfile().subscribe({
      next:(response)=>{
        this.client=response;
        this.isLoading=false;
      },
      error:(err)=>{
        this.errorMessage="failed to load home page";
      }
    });
  }

  showJournalDetails(){
    this.router.navigate(['client/journals']);
  }
  
}
