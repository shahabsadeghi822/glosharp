# Glosharp

A C# SDK for working with Gitkraken Glo Boards

[![Build status](https://ci.appveyor.com/api/projects/status/079vxniq63ema0h6/branch/master?svg=true)](https://ci.appveyor.com/project/wdhodges/glosharp/branch/master) [![Codacy Badge](https://api.codacy.com/project/badge/Grade/be8420c8fd174f9092bc4d31c551e0b8)](https://www.codacy.com/app/glosharp/glosharp?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=glosharp/glosharp&amp;utm_campaign=Badge_Grade)

# Getting Started

There are a couple ways that you can set your Personal Access Token. You can set it in the Environment variable named `GlosharpToken` or you can store it in the `config.json` file. 

```powershell
$env:GlosharpToken=your_personal_token
```
or
```bash
cp config-example.json config.json
```

**Glosharp cannot work with OAuth just yet.**

```csharp
var config = new Connection(new Configuration());
var glo = new GloClient(config);

var boards = glo.Board.GetAllForCurrent();
```