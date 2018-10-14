import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    template: `
                     <list-employee></list-employee>
              `
})
export class AppComponent {
    onclick(): void {
        console.log('Button Clicked');
    }
}
