import { CreateJournalCommandDto, CreateJournalAnswerCommandDto, CreateJournalCommand, ListQuestionsQueryDto } from "./journals-api.models";
import { HttpClient } from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import { environment } from "../../../environments/environment";
import { Observable } from "rxjs";

@Injectable({
    providedIn:'root'
})
export class JournalsApiService{
    private baseUrl=`${environment.apiUrl}/api/journals`;
    private http=inject(HttpClient);


    createJournal(command:CreateJournalCommand):Observable<CreateJournalCommandDto>{
        return this.http.post<CreateJournalCommandDto>(`${this.baseUrl}/create-a-journal`,command);
    }
    getJournalQuestions():Observable<ListQuestionsQueryDto>{
        return this.http.get<ListQuestionsQueryDto>(`${this.baseUrl}/get-journal-questions`);
    }
}