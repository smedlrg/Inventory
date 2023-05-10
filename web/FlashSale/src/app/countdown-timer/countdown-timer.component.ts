import { Component, OnDestroy } from '@angular/core';
import { interval } from 'rxjs';
import { takeWhile } from 'rxjs/operators';

import { apiService } from '../services/api.service';

@Component({
  selector: 'app-countdown-timer',
  templateUrl: './countdown-timer.component.html',
  styleUrls: ['./countdown-timer.component.css']
})
export class CountdownTimerComponent {
  timeDisplay: string | undefined;
  private alive = true;
  constructor(private _apiService: apiService) {

  }

  startCountdown(startTime: Date) {
    interval(1000)
    .pipe(
      takeWhile(() => this.alive),
    )
    .subscribe(() => {
      const now = new Date().getTime();
      const diff = new Date(startTime).getTime() - now;
      if(diff<0){        
        this.alive = false;
        this._apiService.endTimer().subscribe(
          data => {this.timeDisplay = data;}
        );
      } else {
        let seconds = Math.floor(diff / 1000);
         let hour = Math.floor(seconds / 3600);
         let minute = Math.floor((seconds % 3600) / 60);
         let second = seconds % 60;   

       this.timeDisplay = `Sale ends in ${hour} hours ${minute} minutes and ${second} seconds`;

      }
    });
  }

  ngOnInit(){    
    this._apiService.getTimer()
    .subscribe(
      data =>{
        this.startCountdown(data);
      }
    )
  }

  ngOnDestroy(){
    this.alive = false;
  }
}
