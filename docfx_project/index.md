# Glosharp

Using Glosharp is pretty simple and designed to be low impact, lightweight and fast. That way you can spend more time building your application verus configuring and setting up this plugin.

> Keep in mind, that this is still Early Alpha so it's subject to change.

**Quick Start**

```csharp
var config = new Connection(new Configuration());
var glo = new GloClient(config);
var user = await glo.User.GetAllForCurrent();

Console.WriteLine($"ID: {user.Id} | Name: {user.Name} | Username: {user.Username} | Email: {user.Email}");
```

