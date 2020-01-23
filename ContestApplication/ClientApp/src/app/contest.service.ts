import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable()
export class ContestService {

  constructor(private http: HttpClient) { }

  public baseUrl:string ='/api/Contest';

  getUser() {
    return this.http.get(this.baseUrl+'/'+1);
  }

  getAllMovies()
  {
    return this.http.get(this.baseUrl+'/getMovies');
  }

  getQuestions(mId)
  {
    return this.http.get(this.baseUrl+'/getQuestions/'+mId);
  }

  getContestTaken(mId)
  {
    return this.http.get(this.baseUrl+'/isContestTaken/1/'+mId);
  }

  setContestTaken(mId)
  {
    return this.http.post(this.baseUrl+'?userId=1&movieId='+mId,mId);
  }
}
