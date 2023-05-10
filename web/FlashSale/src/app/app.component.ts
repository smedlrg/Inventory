import { Component, OnDestroy } from '@angular/core';
import { interval } from 'rxjs';
import { takeWhile } from 'rxjs/operators';

import { apiService } from './services/api.service';
import { item } from './classes/item';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FlashSale';
  items: item[] | undefined;
  timeDisplay: string | undefined;

  constructor(private _apiService: apiService) {
  }
 
  ngOnInit(){
    this._apiService.getItems()
    .subscribe(
      data =>{        
        this.items = data;
      }
    );   
  } 
}
