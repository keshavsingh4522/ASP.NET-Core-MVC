- Service can be registered with the following liftimes
```markdown
- Transient(AddTransient)
    A new instance of service will be created every time it is requested
- Scoped(AddScoped)
    these are created once per client request
- Singleton(AddSingleton)
    same instance for the application
```
