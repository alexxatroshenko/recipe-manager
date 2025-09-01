import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component, EventEmitter,
  inject,
  OnDestroy,
  OnInit, Output,
  ViewEncapsulation
} from '@angular/core';
import {delay, from, interval, of, repeat, Subject, Subscription, switchMap, takeUntil, takeWhile} from 'rxjs';

@Component({
  selector: 'app-about',
  imports: [],
  templateUrl: './about.component.html',
  styleUrl: './about.component.scss',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AboutComponent implements OnInit, OnDestroy{
  @Output() close = new EventEmitter<string>();
  private _cdr = inject(ChangeDetectorRef)

  typeWriterLabel: string = "рецепты";
  private recipesLabel: string = this.typeWriterLabel;
  private typeWriterWords: string[] =["Создавай", "Сохраняй", "Выбирай"];
  private typeSpeed: number = 150;
  private pauseAfterWord: number = 100;
  private eraseSpeed: number = 50;
  private isRunning: boolean = false;
  ngOnInit() {
    this.startTypeWriter();
  }

  startTypeWriter(): void {
    this.isRunning = true;

    of(null).pipe(
      switchMap(() => from(this.processTypeWriterWords())),
      delay(this.pauseAfterWord),
      repeat(),
      takeWhile(() => this.isRunning)
    ).subscribe();
  }

  private async processTypeWriterWords(): Promise<void> {
    for (const word of this.typeWriterWords) {
      // Фаза печати слова
      for (let i = 0; i <= word.length; i++) {
        const substring = word.substring(0, i);
        this.updateTypeWriterLabel(substring);
        await this.delay(this.typeSpeed);
      }

      await this.delay(this.pauseAfterWord);

      // Фаза стирания слова
      for (let i = word.length; i >= 0; i--) {
        const substring = word.substring(0, i);
        this.updateTypeWriterLabel(substring);
        await this.delay(this.eraseSpeed);
      }
    }
  }

  private updateTypeWriterLabel(substring: string): void {
    this.typeWriterLabel = `${substring} ${this.recipesLabel}`;
    this._cdr.markForCheck();
  }

  private delay(ms: number): Promise<void> {
    return new Promise(resolve => setTimeout(resolve, ms));
  }

  ngOnDestroy(): void {
    this.isRunning = false;
  }
}
