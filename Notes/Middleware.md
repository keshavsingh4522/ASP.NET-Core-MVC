- What is middleware
```
- when we send a request from browser to server it directly goes to the controller,
  then all process happens on controller and we got a response as a view on the browser
- but before actually hitting to the controller the request has to pass through some components,
  these components are known as *http pipline or middleware.*
- Asp.Net Core create an http application pipline that process the request
- Http application pipline 
  * it is responsible for all request and response
  * it is configures in Configure method of Startup.cs
- All the request to the application goes through the Http pipeline
- A middleware is a piece of code(Component) which is used in Http Pipeline.
- In an Application we use Multiple Middleware
- A middleware has access to all the request and response.

```

<details>
  <summary>Middlewre Configure</summary>
  
![Middleware](https://user-images.githubusercontent.com/43788985/115658711-ea65ff00-a356-11eb-9dec-f66a5898cfb8.png)
  
</details>
