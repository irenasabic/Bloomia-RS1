import {inject, Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {Observable, retry} from "rxjs";
import { AddTherapistToSavedTherapistsCommand, AddTherapistToSavedTherapistsCommandDto, ListSavedTherapistsQuery, ListSavedTherapistsResponse, RemoveAllSavedTherapistsCommand, RemoveSavedTherapistCommand, GetSavedTherapistByNameCommand, GetSavedTherapistByNameCommandDto, GetSavedTherapistByNameResponse } from "./savedTherapists-api.models";
import { buildHttpParams } from "../../core/models/build-http-params";
@Injectable({
    providedIn: 'root'
})
export class SavedTherapistsApiService {

    private baseUrl=`${environment.apiUrl}/api/ClientSavedTherapists`;
    private http=inject(HttpClient);

    //C
    addTherapistToSavedTherapists(command:AddTherapistToSavedTherapistsCommand):Observable <AddTherapistToSavedTherapistsCommandDto>{
        return this.http.post<AddTherapistToSavedTherapistsCommandDto>(`${this.baseUrl}/save-therapist`, command);
    }
    getAllSavedTherapists(command:ListSavedTherapistsQuery):Observable<ListSavedTherapistsResponse>{
        const params=command? buildHttpParams(command as any):undefined;
        return this.http.get<ListSavedTherapistsResponse>(this.baseUrl,{params});
    }
    removeSavedTherapist(therapistId:number):Observable<string>{
        return this.http.delete<string>(`${this.baseUrl}/remove-therapist-by-id/${therapistId}`, {responseType: 'text' as 'json'});
    }
    removeAllSavedTherapists():Observable<string>{
        return this.http.delete<string>(`${this.baseUrl}/remove-all-saved-therapists`, {responseType: 'text' as 'json'});
    }
    getSavedTherapistByName(searchByFullname:string):Observable<GetSavedTherapistByNameResponse>{
        return this.http.get<GetSavedTherapistByNameResponse>(`${this.baseUrl}/search-saved-therapists-by-name`, {params:
                                                                                                                    {search:searchByFullname}
                                                                                                                });
    }
}