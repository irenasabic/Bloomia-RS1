import { Component, OnInit,inject } from '@angular/core';
import { JournalsApiService } from '../../../../api-services/journals/journals-api.service';
import { ActivatedRoute } from '@angular/router';
import { ListQuestionsQueryDto,CreateJournalCommand,CreateJournalCommandDto,CreateJournalAnswerCommandDto } from '../../../../api-services/journals/journals-api.models';
@Component({
  selector: 'app-journal-details',
  standalone: false,
  templateUrl: './journal-details.component.html',
  styleUrl: './journal-details.component.scss',
})
export class JournalDetailsComponent implements OnInit {
 
  private apiService=inject(JournalsApiService);
  private route=inject(ActivatedRoute);

//1.zelimo mapirati q_id i answer tipa text
//2.reagujemo na input

  questions:ListQuestionsQueryDto={
        listOfQuestions:[]
  }
  isLoading=false;
  errorMessage:string|null=null;

  journal:CreateJournalCommand|null=null;
  journalTitle:string|null=null;
  answerMap:{[questionId:number]:string}={};
  journalDTO:CreateJournalCommandDto|null=null;
  journalSubmitted=false;

  ngOnInit(): void {
    this.showJournalQuestions();
  }
  showJournalQuestions(){
    this.isLoading=true;
    this.errorMessage=null;

    this.apiService.getJournalQuestions().subscribe({
      next:(response)=>{
        this.questions=response;
        this.isLoading=false;
      },
      error:(err)=>{
        this.errorMessage="Failed to load journal questions";
        console.error(err);
      }
    });
  }

  onAnswerInput(questionId:number, event:Event){
    const answerText=(event.target as HTMLInputElement).value;
    if(answerText.length>0){
      this.answerMap[questionId]=answerText;
    }
    else{
      this.errorMessage="Niste unijeli validan odgovor.";
    }
  }
  onTitleInput(event:Event){
    const title=(event.target as HTMLInputElement).value;
    if(title.length>0){
      this.journalTitle=title;
    }
  }
  submitJournal(){
    if(!this.journalTitle || this.journalTitle.length===0){
       this.errorMessage = 'Unesite naslov journala';
       return;
    }
    
    const journalAnswers:CreateJournalAnswerCommandDto[]=this.questions.listOfQuestions.map(a=>({
      questionId:a.questionId,
      questionText:a.question,
      answerText:this.answerMap[a.questionId]??'//'
    }));

    const command:CreateJournalCommand={
        title:this.journalTitle??'Journal',
        clientsAnswers:journalAnswers
    };

    this.apiService.createJournal(command).subscribe({
      next:(response)=>{
          this.journalDTO=response;
          this.journalSubmitted=true;
      },
      error:(err)=>{
        this.errorMessage="Failed to submit your answers! Try again";
      }
    
    });
  }

  isInputValid():boolean{
    return(
       this.journalTitle!=null && this.questions.listOfQuestions.every(q=> this.answerMap[q.questionId]?.trim.length>0)
    );
  }
}
