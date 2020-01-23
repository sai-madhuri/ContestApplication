import { Component } from '@angular/core';
import { ContestService } from '../contest.service';
import {SharedService} from '../shared.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})
export class HomeComponent {

  data: any = []
  Movies = {
   MId : '',
   Name  : '',
   CoverPhoto :''
  }

  constructor(public contestService : ContestService,private sharedService : SharedService) { }

  ngOnInit() {
    this.ContestPage();
  }

  ContestPage() {
    this.contestService.getAllMovies()
      .subscribe(resp => {
        this.data = resp
      });
}

specifyMovie(mId,movieName)
{
  this.sharedService.movieId = mId;
  this.sharedService.movieName=movieName;
}
}
