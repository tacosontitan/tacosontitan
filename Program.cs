// Create a module service and register a handler to observe the error occurred event.
var moduleService = new ModuleService();
moduleService.ErrorOccurred += RecordModuleServiceError;

// Discover any defined modules.
moduleService.Discover();

do {

    // Prompt the user for a module.
    Console.Write("Please enter `help` for help, `exit` to exit, or a command key: ");

    // Store the user's response.
    var response = Console.ReadLine();

    // Determine if we should exit.
    if (response?.Equals("exit", ignoreCase: true) == true)
        break;

    // Determine if help was requested.
    else if (response?.Equals("help", ignoreCase: true) == true)
        Console.WriteLine(moduleService.GenerateHelpMessage());

    // Attempt to invoke a module.
    if (!string.IsNullOrWhiteSpace(response)) {
        if (moduleService.ContainsModule(response, out ConsumableModule? module))
            moduleService.Invoke(module);
        else
            Console.WriteLine($"No module found with the key `{response}`.");
    } else
        Console.WriteLine("User response lost.");

} while (true);


#region Local Functions

/// <summary>
/// Records an error message received from the module service.
/// </summary>
/// <param name="sender">The sender of the event.</param>
/// <param name="message">The error message that should be recorded.</param>
void RecordModuleServiceError(object? sender, string message) => Console.WriteLine(message);

#endregion