import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@microsoft/signalr';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent   implements OnInit {

  private hubConnection: HubConnection | undefined;
  async: any;
  message = '';
  messages: string[] = [];

  ngOnInit(): void {
    console.log('App Component Init');
    this.init();
  }

  title = 'angular-client';

  private init() {
    
 
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:44341/messageHub")
      .configureLogging(signalR.LogLevel.Information)
      .build();
 
    this.hubConnection.start().catch((err) => console.error(err.toString()));
 
    this.hubConnection.on('SendMessage', (data: any) => {
      console.log(data);
      const received = `Received: ${data}`;
      this.messages.push(received);
    });
  }
}
