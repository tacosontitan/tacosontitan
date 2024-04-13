namespace Sandbox.Core;

/// <summary>
/// Represents the communication level of a message.
/// </summary>
public enum CommunicationLevel
{
    /// <summary>
    /// Specifies that the communication level is public.
    /// </summary>
    Public = 0,
    
    /// <summary>
    /// Specifies that the communication level is private.
    /// </summary>
    Private = 1,
    
    /// <summary>
    /// Specifies that the communication level is a whisper.
    /// </summary>
    Whisper = 2
}
