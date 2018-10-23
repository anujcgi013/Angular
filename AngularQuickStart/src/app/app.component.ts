import { Component } from '@angular/core';

@Component({
    selector: "my-app",
    template: `<list-employee></list-employee>`
})
export class AppComponent {
    userText: string = 'Anuj';
    //onclick(): void {
    //    console.log('Button Clicked');
    //}
}

//Your Text: <input type="text"[(ngModel)] = "userText" />
//    <br/>
//    < simple[simpleInput]="userText" > </simple>