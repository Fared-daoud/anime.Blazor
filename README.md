# animejs interop with Blazor

[![Build Status](https://dev.azure.com/faredjalel/anime.Blazor/_apis/build/status/anime.Blazor-master?branchName=master)](https://dev.azure.com/faredjalel/anime.Blazor/_build/latest?definitionId=2&branchName=master)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE.md)
[![NuGet](https://img.shields.io/nuget/v/anime.Blazor)](https://www.nuget.org/packages/anime.Blazor/)

# Introduction

This is a Blazor library that wraps [animejs](https://animejs.com/). You can use the library in both client- and server-side projects. See the *Getting Started*, browse the samples for help.


# Getting started

## Installation

There's a NuGet package available: [anime.Blazor](https://www.nuget.org/packages/anime.Blazor/)

In case you prefer the command line:

```bash
Install-Package anime.Blazor
```

## Usage

### Assets
Before you can start creating an animation, you have to add some static assets to your project. These come bundled with anime.Blazor, so you only need to add a few lines to your `Index.html`/`_Host.cshtml`.

In your `_Host.cshtml` (server-side) or in your `index.html` (client-side) add the following lines to the `body` tag **after** the `_framework` reference

```html
<!-- Reference the animeBlazor.js javascript file. -->
<script src="_content/anime.Blazor/animeBlazor.js"></script>
```

### Imports
Now add a reference to `anime.Blazor` in your `_Imports.razor`
```csharp
@using anime.Blazor;
```

### Usage example

```csharp
// Create an instance of `Animation` class with a unique Id
Animation animation = new Animation(1);

// specifies the targets to animate
animation.Targets = new object[] { ".any-css-selector .el1" };

// sets the value for the needed the parameters,
// through setting available properties, like:
animation.Direction = Direction.reverse;
animation.Autoplay = true;
animation.Loop = 5;

// or
animation.AdditionalParameters = new Dictionary<string, object>
{
  { "translateX", 250 },
  { "delay", 500 },
  { "backgroundColor", "#4266f5"},
};

//for more info about the parameters see the original documintation of animejs library

// then call AnimateAsync with an instance of `Microsoft.JSInterop.IJSRuntime` to start the animation
await animation.AnimateAsync(JSRuntime);

// if the Autoplay was set to false you can call `PlayAsync` to start the animation
await animation.PlayAsync(JSRuntime);

// to pause an animation call `PauseAsync`
await animation.PauseAsync(JSRuntime);

// to reverse an animation call `ReverseAsync`
await animation.ReverseAsync(JSRuntime);

// to remove a target from an animation call `RemoveAsync`
await animation.RemoveAsync(JSRuntime, ".any-css-selector .el");
```
