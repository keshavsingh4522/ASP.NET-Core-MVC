- Blazor Hosting Model
```
- 1. Blazor WebAssembly(client side)
- 2. Blazor Server
```
- Blazor WebAssembly
```
===> PROS
- After downloading files -- Active Server Not Requirred
- Client Resources and Capabilities are Used
- Full blown asp.net core web server not requirred
- can be hosted on our own server, cloud, Azure and CDN(Contact delivery network)

===> CONS
- first very request takes usually longer( because its should be fully downloaded from server) 
- after next visit it will run faster
- Restricted the capabilities of browser
- capable client hardware and software requirred
```
- Blazor
  - connection is established using **SignalR** between server and client
```
===> PROS
- the application loads much faster
- can take full advantage of server capabilities
- All the Client needs, to use the app is browser
- more secure as the app code is not sent to the client

===>CONS
- Asp.net core server is requirred
- an active connection to the server is always requirred
- higher latency due to the round trip to the server
- scability can be challanging
```
