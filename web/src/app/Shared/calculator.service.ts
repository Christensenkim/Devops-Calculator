import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';

const httpoptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {
  constructor(private http: HttpClient) {
  }

  test(): void {
    console.log(this.http.get(environment.webAPIURL + 'api/calculator'));
  }
}
