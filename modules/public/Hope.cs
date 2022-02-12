internal sealed class Hope : ConsumableModule {
    public Hope() : base("hope", "Emily Dickinson", "Prints a shot poem by Emily Dickinson.") { }
    public override void Invoke() => PostMessage("\"Hope\" is the thing with feathers, that perches in the soul; and sings the tune without words, and never stops, at all.");
}