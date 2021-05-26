import { Component } from '@angular/core';
import {CalculatorService} from './Shared/calculator.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'calculator-web';

  constructor(private service: CalculatorService) {
  }

  test(): void {
    this.service.test();
  }
}
