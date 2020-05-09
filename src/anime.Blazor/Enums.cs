namespace anime.Blazor
{
  /// <summary>
  /// Defines the direction of the animation.
  /// </summary>
  public enum Direction
  {
    /// <summary>
    /// Animation progress goes from 0 to 100%
    /// </summary>
    normal,

    /// <summary>
    /// Animation progress goes from 100% to 0%
    /// </summary>
    reverse,

    /// <summary>
    /// Animation progress goes from 0% to 100% then goes back to 0%
    /// </summary>
    alternate,
  }
}
