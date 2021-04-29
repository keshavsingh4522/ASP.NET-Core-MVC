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
  
```c#
using Microsoft.AspNetCore.SignalR;
using SignalRHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHub
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string name, string text)
        {
            var message = new ChatMessage
            {
                SenderName=name,
                Text=text,
                SendAt=DateTimeOffset.UtcNow
            };

            // BroadCast to all Clients
            await Clients.All.SendAsync(
                "ReceiveMessgae",
                message.SenderName,
                message.SendAt,
                message.Text);
        }
    }
}

```

</details>


```
to save the history of message create model class
```

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
