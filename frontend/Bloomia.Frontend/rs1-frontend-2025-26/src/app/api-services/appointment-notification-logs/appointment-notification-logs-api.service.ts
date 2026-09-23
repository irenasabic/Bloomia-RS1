import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { AppointmentNotificationLogDto } from './appointment-notification-logs-api.model';

@Injectable({
  providedIn: 'root'
})
export class AppointmentNotificationLogsApiService {

  private readonly http = inject(HttpClient);

  private readonly baseUrl =
    `${environment.apiUrl}/api/AppointmentNotificationLogs`;

  getAll(): Observable<AppointmentNotificationLogDto[]> {
    return this.http.get<AppointmentNotificationLogDto[]>(this.baseUrl);
  }
}