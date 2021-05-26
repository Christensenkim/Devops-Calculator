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

  test(): Observable<string[]> {
    return this.http.get<string[]>('https://localhost:44314/Calculator', httpOptions);
  }
}
