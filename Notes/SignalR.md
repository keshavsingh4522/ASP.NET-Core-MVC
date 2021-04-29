- What SignalR Does
```
- Establish and manage the connections for you
- Hide the complexity "Under Hood"
- Transports message from client to the server
- Transports messsage from server to one or many clients
```
- Use case for SignalR
```
- Communication Apps
- Notification and Updates
- Collaboration tools
- Games
```
- What SignalR is Not
```
- Data Store
- Useramanager
```
```
signar is actuaaaly for connection , so it can not be used for data store
  ex. it can not store message of client, it forgots message after sending
aslo it is not used for user authentication.
```
- SignalR vs WebSockets vs WebRTC

<details>
  <summary></summary>
  
![2021-04-29 (1)](https://user-images.githubusercontent.com/43788985/116506127-39bda980-a8da-11eb-828e-683510508c87.png)

</details>

- When to use WebRTC
```
- Streaming audio and ideo
- Extreme latency requirements
```
- SignalR and Asp.Net Core
```
- Inherits web features and Security from Asp.Net Core
- Deploy anywhere
```
- How SignalR Works
```
- The Core Component of SignalR is Hub
- All message transferred from Client to Server or Server to Cilent is flow from the HUB
```

<details>
  <summary></summary>
  
![2021-04-29 (3)](https://user-images.githubusercontent.com/43788985/116511646-624aa100-a8e4-11eb-805e-a26bea522bf9.png)

</details>

--------------
- Create Aps.net Core Web Empty App
```bash
dotnet new razor
```
- most important part of signalr is hub so creata Hub
```
crate a class and inherit from Hub
```
```
client access method which is defined in hub, so create a sendmessage method in hub
```

<details>
  <summary>Hub Class ==> ChatHub.cs</summary>
  
```using Microsoft.AspNetCore.SignalR;
using SignalRHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string name, string text)
        {
            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SendAt = DateTimeOffset.UtcNow
            };

            // Broadcast to all clients
            await Clients.All.SendAsync(
                "ReceiveMessage",
                message.SenderName,
                message.SendAt,
                message.Text);

        }
    }
}

```

<details>
  <summar>when user connceted -> chathub.cs code</summary>
  
  ```c#
  using Microsoft.AspNetCore.SignalR;
using SignalRHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync(
                "ReceiveMessage",
                "Keshav Singh",
                DateTimeOffset.UtcNow,
                "hello what can we help with you today!");
            await base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(string name, string text)
        {
            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SendAt = DateTimeOffset.UtcNow
            };

            // Broadcast to all clients
            await Clients.All.SendAsync(
                "ReceiveMessage",
                message.SenderName,
                message.SendAt,
                message.Text);

        }
    }
}
  ```
  
</details>

</details>


- to save the history of message create model class

<details>
  <summary>model class ==> ChatMessage.cs</summary>

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub.Models
{
    public class ChatMessage
    {
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTimeOffset SendAt { get; set; }
    }
}
```

</details>

- add some code startup class
```C#
- Configure service
    services.AddSignalR();

- Configure
    app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
            })
```
- Add javascript files
```html
<script src="https://unpkg.com/@@aspnet/signalr@@1.0.2/dist/browser/signalr.js" integrity="sha384-gjN8HGdgW45EWYHOqrWrZ8XHLv1zKBralQ9UU94n//6MvoCdsF3NJrBt9FssrFK3" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.22.2/moment.min.js" integrity="sha256-CutOzxCRucUsn6C6TcEYsauvvYilEniTXldPa6/wu0k=" crossorigin="anonymous"></script>
```
- in Index.chtml dialog code
```html
<div id="chatDialog" title="Chat with support">
    <div id="chatMainPanel">
        <ul id="chatHistory"></ul>
        <div id="bottomPanel">
            <form id="chatForm">
                <input autocomplete="off"  id="messageTextbox" type="text" placeholder="Type a message" />
                <button type="submit">Send</button>
            </form>
        </div>
    </div>
</div>
```
- JS Code
<details>
  <summary></summary>
  
```js
var chatterName = 'Visitor';

// Initialize the SignalR client
var connection = new signalR.HubConnectionBuilder()
    .withUrl('/chatHub')
    .build();

connection.on('ReceiveMessage', renderMessage);

connection.start();


function showChatDialog() {
    var dialogEl = document.getElementById('chatDialog');
    dialogEl.style.display = 'block';
}

function sendMessage(text) {
    if (text && text.length) {
        connection.invoke('SendMessage', chatterName, text);
    }
}

function ready() {
    setTimeout(showChatDialog, 750);

    var chatFormEl = document.getElementById('chatForm');
    chatFormEl.addEventListener('submit', function (e) {
        e.preventDefault();

        var text = e.target[0].value;
        e.target[0].value = '';
        sendMessage(text);
    })
}


function renderMessage(name, time, message) {
    var nameSpan = document.createElement('span');
    nameSpan.className = 'name';
    nameSpan.textContent = name;

    var timeSpan = document.createElement('span');
    timeSpan.className = 'time';
    var friendlyTime = moment(time).format('H:mm');
    timeSpan.textContent = friendlyTime;

    var headerDiv = document.createElement('div');
    headerDiv.appendChild(nameSpan);
    headerDiv.appendChild(timeSpan);

    var messageDiv = document.createElement('div');
    messageDiv.className = 'message';
    messageDiv.textContent = message;

    var newItem = document.createElement('li');
    newItem.appendChild(headerDiv);
    newItem.appendChild(messageDiv);

    var chatHistoryEl = document.getElementById('chatHistory');
    chatHistoryEl.appendChild(newItem);
    chatHistoryEl.scrollTop = chatHistoryEl.scrollHeight - chatHistoryEl.clientHeight;
}

document.addEventListener('DOMContentLoaded', ready);
```  
  
</details>

- How groups work in SignalR
```
```

<details>
  <summary></summary>
  
  ![2021-04-29 (4)](https://user-images.githubusercontent.com/43788985/116580490-0c501a80-a931-11eb-9b59-91dd56a12dbf.png)
  
</details>

- what to use groups for
```
- caht rooms and channels
- Topic subscriptions
- Any other collection of connections
```
- create a different group for each visitor so that they any other cannot see message.
