import { Component, OnInit } from '@angular/core';
import {CalculatorService} from '../Shared/calculator.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnInit {
  screen: string | undefined;
  private value: any;
  testvalue: any;

  constructor(private service: CalculatorService) { }

  ngOnInit(): void {
    this.testvalue = this.service.test();
  }

  tester(): void {
    console.log(this.testvalue);
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
