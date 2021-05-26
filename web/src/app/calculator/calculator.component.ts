import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {
  constructor() { }
  screen: string | undefined;
  number1: string | undefined;
  number2: string | undefined;
  calcCondition: string | undefined;
  calcResult: number | undefined;
  private value: any;

  ngOnInit(): void {
    this.screen = '';
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
  }

  clear(): void {
    this.screen = '';
    this.calcCondition = '';
    this.operand1 = '';
    this.operand2 = '';
    this.value = '';
  }
}
