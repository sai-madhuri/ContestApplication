import { Component } from '@angular/core';
import {ContestService} from '../contest.service';
import {SharedService} from '../shared.service';

@Component({
  selector: 'app-contest-component',
  templateUrl: './contest.component.html',
  styleUrls:['/contest.component.css']
})
export class ContestComponent {
 
  data: any = []
  Questions = {
   QId : '',
   Question  : '',
   Option1  : '',
   Option2  : '',
   Option3  : '',
   Option4  : '',
   CorrectOption  : '',
  }
  
  isContestTaken : any = []
  ContestTaken={
    UserId : '',
    MovieId : ''
  }

  MId : string = "";
  MovieName : string ="";
  correctOption : string = "";
  questionNumber = 0;
  correctAnswers = 0;
  public contestSuccess : boolean = false;
  public contestFailure : boolean = false;
  successCode : string = "";
  alreadyContestTaken : boolean;

  constructor(public contestService : ContestService,private sharedService : SharedService) { }

  ngOnInit() {
    this.MId = this.sharedService.movieId;
    this.MovieName = this.sharedService.movieName;
    this.IsContestTaken();
  }

  IsContestTaken()
  {
    this.contestService.getContestTaken(this.MId)
      .subscribe(resp => {
        this.isContestTaken = resp,
        console.log("Array : "+this.isContestTaken);
      },
      error => {
        console.log("Not successful");
      });
      this.ContestPage();
  }

  ContestPage() {
    if(this.isContestTaken.length==0)
    {
      this.contestService.getQuestions(this.MId)
      .subscribe(resp => {
        this.data = resp
      },
      error => {
        console.log("Not successful");
      });
      this.contestService.setContestTaken(this.MId);
      this.alreadyContestTaken=false;
    }
    else this.alreadyContestTaken=true;
  }

addAnswer(questionNumber,answer)
{
   this.correctOption = this.data[questionNumber].correctOption;
   if(answer==this.correctOption) this.correctAnswers+=1;
   this.questionNumber+=1;
   if(this.correctAnswers==5 && this.questionNumber==5)
   {
     this.contestSuccess=true;
     this.successCode = this.randomString(12, '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ');
     this.contestService.setContestTaken(this.MId);
   }
   else if(this.questionNumber==5 && this.correctAnswers!=5)
   {
     this.contestFailure = true;
     this.contestService.setContestTaken(this.MId);
   }
}

randomString(length, chars) {
  var result  = '';
  for (var i = length; i > 0; --i) result += chars[Math.floor(Math.random() * chars.length)];
  return result;
}
}
