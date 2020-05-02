# animejs interop with Blazor

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE.md)

# Introduction

This is a Blazor library that wraps [animejs](https://animejs.com/). You can use the library in both client- and server-side projects. See the *Getting Started*, browse the samples for help.


# Getting started

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