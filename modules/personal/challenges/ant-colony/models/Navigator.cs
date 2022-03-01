internal abstract class Navigator {

    #region Fields

    private readonly int _numberOfPasses;
    private readonly List<Landmark> _landmarks;

    #endregion

    #region Constructor

    public Navigator(List<Landmark> landmarks, int numberOfPasses) {
        _landmarks = landmarks;
        _numberOfPasses = numberOfPasses;
    }
        

    #endregion

    #region Public Methods

    public List<Landmark> FindOptimalPath() {
        List<List<Landmark>> paths = new ();
        for (int i = 0; i < _numberOfPasses; i++)
            paths.Add(GeneratePath(_landmarks));

        return paths.OrderByDescending(path => path.Sum(s => s.Value)).First();
    }

    #endregion

    #region Protected Methods

    protected abstract List<Landmark> GeneratePath(List<Landmark> landmarks);

    #endregion

}