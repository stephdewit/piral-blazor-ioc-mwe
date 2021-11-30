# Piral Blazor IoC MWE

There are two pages in this project:
- [Counter.razor](http://localhost:1234/counter) in which a `IClockService` is directly injected and works fine.
- [NotWorkingPage.razor](http://localhost:1234/not-working) which references an `InjectWithinComponent.razor` component. The `IClockService` is injected the same way into this component.

Services are configured within the `ConfigureServices` method. When the `ConfigureShared` method is used instead, none of the two pages are working.

If you run `pilet debug` and go to the [counter page](http://localhost:1234/counter), you can see the time from the injected clock service.

But if you go to the [not working page](http://localhost:1234/not-working), these errors are printed into the Chrome console:

```
crit: Microsoft.AspNetCore.Components.WebAssembly.Rendering.WebAssemblyRenderer[100]
      Unhandled exception rendering component: Cannot provide a value for property 'clockService' on type 'pilet.InjectWithinComponent'. There is no registered service of type 'pilet.IClockService'.
System.InvalidOperationException: Cannot provide a value for property 'clockService' on type 'pilet.InjectWithinComponent'. There is no registered service of type 'pilet.IClockService'.
   at Microsoft.AspNetCore.Components.ComponentFactory.<>c__DisplayClass6_0.<CreateInitializer>g__Initialize|2(IServiceProvider serviceProvider, IComponent component)
   at Microsoft.AspNetCore.Components.ComponentFactory.PerformPropertyInjection(IServiceProvider serviceProvider, IComponent instance)
   at Microsoft.AspNetCore.Components.ComponentFactory.InstantiateComponent(IServiceProvider serviceProvider, Type componentType)
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.InstantiateComponent(Type componentType)
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.InstantiateChildComponentOnFrame(RenderTreeFrame& frame, Int32 parentComponentId)
   at Microsoft.AspNetCore.Components.RenderTree.RenderTreeDiffBuilder.InitializeNewComponentFrame(DiffContext& diffContext, Int32 frameIndex)
   at Microsoft.AspNetCore.Components.RenderTree.RenderTreeDiffBuilder.InitializeNewSubtree(DiffContext& diffContext, Int32 frameIndex)
   at Microsoft.AspNetCore.Components.RenderTree.RenderTreeDiffBuilder.InsertNewFrame(DiffContext& diffContext, Int32 newFrameIndex)
   at Microsoft.AspNetCore.Components.RenderTree.RenderTreeDiffBuilder.AppendDiffEntriesForRange(DiffContext& diffContext, Int32 oldStartIndex, Int32 oldEndIndexExcl, Int32 newStartIndex, Int32 newEndIndexExcl)
   at Microsoft.AspNetCore.Components.RenderTree.RenderTreeDiffBuilder.ComputeDiff(Renderer renderer, RenderBatchBuilder batchBuilder, Int32 componentId, ArrayRange`1 oldTree, ArrayRange`1 newTree)
   at Microsoft.AspNetCore.Components.Rendering.ComponentState.RenderIntoBatch(RenderBatchBuilder batchBuilder, RenderFragment renderFragment)
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.RenderInExistingBatch(RenderQueueEntry renderQueueEntry)
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.ProcessRenderQueue()
```

```
TypeError: Cannot read properties of null (reading 'querySelectorAll')
    at prefixMediaSources (converter.js:10)
    at project (converter.js:16)
    at converter.js:44
```
