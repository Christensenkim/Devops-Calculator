import { Component, OnInit } from '@angular/core';
import {CalculatorService} from '../Shared/calculator.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {
  constructor(private service: CalculatorService) { }
  screen: string | undefined;
  number1: string | undefined;
  number2: string | undefined;
  calcCondition: string | undefined;
  calcResult: number | undefined;
  private value: any;
  calcHistory: string[] | undefined;

  ngOnInit(): void {
    this.screen = '';
    this.getCalcHistory();
  }

  entervalue(value: any): void {
    if ((this.calcCondition === '+') || (this.calcCondition === '-') || (this.calcCondition === '*') || (this.calcCondition === '/')) {
      this.calcResult = this.calcResult + value;
      this.screen = this.screen + value;
      this.number1 = this.screen;
    }
    else{
      this.screen = this.screen + value;
      this.number2 = this.screen;
    }
  }

  condition(value: any): void {
    this.screen = this.screen + value;
    this.calcCondition = value;
  }

  result(): void {
    this.service.calculate(this.screen).subscribe(answer => {
      this.screen = answer;
    });
    this.getCalcHistory();
  }

  clear(): void {
    this.screen = '';
    this.calcCondition = '';
    this.number1 = '';
    this.number2 = '';
    this.value = '';
  }

  testBackend(): void {
    this.service.test().subscribe(answer => {
      this.screen = answer[0];
    });
  }

  getCalcHistory(): void{
    this.service.test().subscribe(value => {
      this.calcHistory = value;
    });
  }
}
