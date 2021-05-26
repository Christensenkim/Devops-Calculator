import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';

const httpOptions = {
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

  calculate(screen: string | undefined): Observable<string> {
    return this.http.post<string>(environment.webAPIURL + 'api/calculator', screen, httpOptions);
  }
}
