```c#
@page "/"

<h1>Hello, world!</h1>

Welcome to your new app.

<SurveyPrompt Title="How is Blazor working for you?" />

<div class="btn-group">
    @foreach(var item in types)
    {
        if (Array.IndexOf(types, item) == Selected)
        {
            <button class="btn btn-primary">@item.Name</button>
        }
        else
        {
            <button class="btn btn-secondary" @onclick="() => Selected = Array.IndexOf(types, item)">@item.Name</button>
        }
    }
</div>
@GetRenderFragment(types[Selected])
@code{
    RenderFragment GetRenderFragment(Type type) {
        RenderFragment renderFragment = renderTreeBuilder =>
        {
            renderTreeBuilder.OpenComponent(0, type);
            renderTreeBuilder.CloseComponent();
        };
        return renderFragment;
    }
    int Selected;
    ComponentBase[] components = { new Counter(), new SurveyPrompt(), new FetchData() };
    Type[] types => components.Select(c=>c.GetType()).ToArray();
}
```
