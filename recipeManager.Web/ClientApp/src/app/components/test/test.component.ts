import {Component, inject, OnInit} from '@angular/core';
import {TestService} from './test.service';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

@Component({
  standalone: true,
  selector: 'app-test',
  imports: [MatSlideToggleModule],
  templateUrl: './test.component.html',
  styleUrl: './test.component.scss'
})
export class TestComponent implements OnInit{

    private testService = inject(TestService);
    ngOnInit(): void {
        console.log("+")
        this.testService.testGet().subscribe();
    }

}
