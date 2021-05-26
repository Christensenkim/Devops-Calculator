import { Component } from '@angular/core';
import {CalculatorService} from './Shared/calculator.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'calculator-web';
  screen = '';

  constructor(private service: CalculatorService) {
  }

  test(): void {
    console.log(this.service.test());
  }

  entervalue(s: string): void {
  }

  condition(s: string): void {
  }

  result(): void {
  }

  clear(): void {
  }
}
