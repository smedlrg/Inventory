import { Component, Input } from '@angular/core';
import { item } from '../classes/item';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.css']
})
export class ItemCardComponent {
  @Input()
  item: item = new item;
}
