namespace sandbox;

public static class SandboxUtilities
{

    #region Public Methods

    public static void WriteConsoleProgressBar(int percentage, bool update = false)
    {
        int numberOfBars = percentage / 10;
        string progressBarCharacters = string.Empty;
        for (int i = 0; i < 10; i++)
            progressBarCharacters += i < numberOfBars ? "█" : " ";


        Console.Write($"\r[{progressBarCharacters}] {percentage}%");
    }


    #endregion

}