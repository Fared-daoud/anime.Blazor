namespace anime.Blazor
{
  using Microsoft.JSInterop;
  using System.Collections.Generic;
  using System.Threading.Tasks;


  /// <summary>
  /// A class to define animation
  /// </summary>
  public class Animation
  {
    /// <summary>
    /// instance Id
    /// </summary>
    private readonly int _id;


    /// <summary>
    /// autoplay
    /// </summary>
    private bool _autoplay = true;

    
    /// <summary>
    /// direction
    /// </summary>
    private Direction _direction;


    /// <summary>
    /// loop
    /// </summary>
    private int _loop;


    /// <summary>
    /// loopIndefinitely
    /// </summary>
    private bool _loopIndefinitely;


    /// <summary>
    /// parameters
    /// </summary>
    private readonly Dictionary<string, object> _parameters = new Dictionary<string, object>();


    /// <summary>
    /// Create new instance of <see cref="Animation"/>
    /// </summary>
    /// <param name="id">instance Id, should be unique in the app</param>
    public Animation(int id)
    {
      _id = id;
    }

    /// <summary>
    /// Gets or sets an array of the targets where to applay the animation
    /// </summary>
    public object[] Targets { get; set; }


    /// <summary>
    /// Gets or sets a value indicating wether an animation should autoplay
    /// </summary>
    public bool Autoplay
    {
      get => _autoplay;
      set
      {
        _autoplay = value;
        _parameters["autoplay"] = _autoplay;
      }
    }


    /// <summary>
    /// Gets or sets direction of the animation.
    /// </summary>
    public Direction Direction
    {
      get => _direction;
      set
      {
        _direction = value;
        _parameters["direction"] = _direction.ToString();
      }
    }


    /// <summary>
    /// Gets or sets the number of iterations of your animation.
    /// </summary>
    public int Loop
    {
      get => _loop;
      set
      {
        _loop = value;
        _parameters["loop"] = _loop;
      }
    }


    /// <summary>
    /// Gets or sets a value indicating wether the animation should loop indefinitely
    /// </summary>
    public bool LoopIndefinitely
    {
      get => _loopIndefinitely;
      set
      {
        _loopIndefinitely = value;
        _parameters["loop"] = _loopIndefinitely;
      }
    }



    /// <summary>
    /// Gets or sets a dictionary of the animation parameters
    /// </summary>
    public Dictionary<string, object> AdditionalParameters { get; set; }
      = new Dictionary<string, object>();


    /// <summary>
    /// Applay animation
    /// </summary>
    /// <param name="jSRuntime">dito</param>
    public async ValueTask AnimateAsync(IJSRuntime jSRuntime)
    {
      await jSRuntime.InvokeVoidAsync("animeBlazor.animation", ToDictonary(), _id);
    }


    /// <summary>
    /// Plays a paused animation, or starts the animation if the autoplay parameters is set to false.
    /// </summary>
    /// <param name="jSRuntime">dito</param>
    public async ValueTask PlayAsync(IJSRuntime jSRuntime)
    {
      await jSRuntime.InvokeVoidAsync("animeBlazor.play", _id);
    }


    /// <summary>
    /// Pauses a running animation.
    /// </summary>
    /// <param name="jSRuntime"></param>
    /// <returns></returns>
    public async ValueTask PauseAsync(IJSRuntime jSRuntime)
    {
      await jSRuntime.InvokeVoidAsync("animeBlazor.pause", _id);
    }


    /// <summary>
    /// Restarts an animation from its initial values.
    /// </summary>
    /// <param name="jSRuntime">dito</param>
    public async ValueTask RestartAsync(IJSRuntime jSRuntime)
    {
      await jSRuntime.InvokeVoidAsync("animeBlazor.restart");
    }


    /// <summary>
    /// Reverses the direction of an animation.
    /// </summary>
    /// <param name="jSRuntime">dito</param>
    public async ValueTask ReverseAsync(IJSRuntime jSRuntime)
    {
      await jSRuntime.InvokeVoidAsync("animeBlazor.reverse");
    }


    /// <summary>
    /// Reverses the direction of an animation.
    /// </summary>
    /// <param name="jSRuntime">dito</param>
    /// <param name="targets">targets to remove</param>
    public async ValueTask RemoveAsync(IJSRuntime jSRuntime, string targets)
    {
      await jSRuntime.InvokeVoidAsync("animeBlazor.remove", targets);
    }


    private Dictionary<string, object> ToDictonary()
    {
      _parameters["targets"] = Targets;

      foreach (var item in AdditionalParameters)
      {
        _parameters.Add(item.Key, item.Value);
      }

      return _parameters;
    }
  }
}
