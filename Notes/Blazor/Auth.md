- When authentication is done
- use below in Razor page for any page authorization
```C#
@attribute [Authorize]
```
```C#
// use below code if you dont wan to use @attribue
<AuthorizeView>
    <Authorized>
        <p>This component demonstrates fetching data from a service.</p
    </Authorized>
    <NotAuthorized>
        <h4>Oops Something went wrong</h4>
        <p>You are not authorized to this page please contact Admin</p>
    </NotAuthorized>
</AuthorizeView>
```
- Global Authorized View
```C#
// goto App.razor file here in AuthorizeViewAdd code like below 
<AuthorizeRouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" >
  <NotAuthorized>
    <h3>You dont have permission to access this page please contact admin</h3>
  </NotAuthorized>
</AuthorizeRouteView>
```
- Show user details
```c#
@page "/"

<h1>Hello, world!</h1>
@if (authState != null)
{
    <h5>Welcome <b>@authState.User.Identity.Name</b> to your new app.</h5>
<p>user details</p>
<ul>
    @foreach (var c in authState.User.Claims) {
        <li>@c.Type : @c.Value</li>
    }
</ul>
}
@code{ 
    [CascadingParameter]
    private Task<AuthenticationState> _authState { get; set; }

    private AuthenticationState authState;
    protected override async Task OnInitializedAsync()
    {
        authState = await _authState;
    }
}
```
