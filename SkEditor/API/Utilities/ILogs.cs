﻿using System;

namespace SkEditor.API;

/// <summary>
///     Interface for logging.
/// </summary>
public interface ILogs
{
    /// <summary>
    ///     Sends a debug message to the log. If SkEditor's developer mode is
    ///     enabled, this message will be displayed in the bottom bar.
    /// </summary>
    /// <param name="message">The message to log.</param>
    void Debug(string message);

    /// <summary>
    ///     Sends an info message to the log.
    /// </summary>
    /// <param name="message">The message to log.</param>
    void Info(string message);

    /// <summary>
    ///     Sends a warning message to the log.
    /// </summary>
    /// <param name="message">The warning message to log.</param>
    void Warning(string message);

    /// <summary>
    ///     Sends an error message to the log. Optionally informs the user.
    /// </summary>
    /// <param name="message">The error message to log.</param>
    /// <param name="informUser">Whether to inform the user about the error. Default is false.</param>
    void Error(string message, bool informUser = false);

    /// <summary>
    ///     Sends a fatal error message to the log. This type of error is critical and may cause the program to terminate.
    /// </summary>
    /// <param name="message">The fatal error message to log.</param>
    void Fatal(string message);

    /// <summary>
    ///     Sends a fatal exception to the log.
    /// </summary>
    /// <param name="exception">The exception to log.</param>
    void Fatal(Exception exception);


    /// <summary>
    ///     Sends an error message related to an addon to the log. Optionally informs the user.
    /// </summary>
    /// <param name="message">The error message to log.</param>
    /// <param name="informUser">Whether to inform the user about the error. Default is false.</param>
    /// <param name="addon">The addon related to the error. Default is null.</param>
    void AddonError(string message, bool informUser = false, IAddon? addon = null);
}