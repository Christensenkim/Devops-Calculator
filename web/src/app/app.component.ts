import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'calculator-web';
  screen = '';

  entervalue(s: string): void {
  }

  condition(s: string): void {
  }

  result(): void {
  }

  clear(): void {
  }
}
