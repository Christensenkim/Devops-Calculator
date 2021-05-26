import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {
  screen: string | undefined;
  private value: any;

  constructor() { }

  ngOnInit(): void {
  }

  entervalue(value: any): void {
    this.value = value;

  }

  condition(s: string): void {
  }

  result(): void {
  }

  clear(): void {
    this.screen = '';
  }
}
