import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.scss']
})
export class PopupComponent {

  @Input() width = '400px';
  visible = false;

  show() {
    this.visible = true;
  }

  hide() {
    this.visible = false;
  }



}
