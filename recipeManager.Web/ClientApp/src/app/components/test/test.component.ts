import {Component, OnInit} from '@angular/core';
import {TestService} from './test.service';

@Component({
  standalone: true,
  selector: 'app-test',
  imports: [],
  templateUrl: './test.component.html',
  styleUrl: './test.component.scss'
})
export class TestComponent implements OnInit{

  constructor(private testService: TestService) {
  }
    ngOnInit(): void {
        console.log("+")
        this.testService.testGet().subscribe();
    }

}
