﻿using System;
using Serilog.Core;
using Serilog.Events;
using SkEditor.API;
using LogsWindow = SkEditor.Views.Windows.LogsWindow;

namespace SkEditor.Utilities;

public class LogsHandler : ILogEventSink
{
    public void Emit(LogEvent logEvent)
    {
        LogsWindow.Logs.Add(logEvent);

        string color = GetColor(logEvent.Level);
        if (logEvent.Level == LogEventLevel.Fatal)
        {
            Console.WriteLine(color + logEvent.Level + " | " + logEvent.RenderMessage());
            Console.WriteLine(color + logEvent.Exception);
        }
        else
        {
            Console.WriteLine(color + logEvent.Level + " | " + logEvent.RenderMessage());
        }

        if (logEvent.Level == LogEventLevel.Debug && SkEditorAPI.Core.IsDeveloperMode())
        {
            SkEditorAPI.Windows.GetMainWindow()?.BottomBar.UpdateLogs(logEvent.RenderMessage());
        }
    }

    private static string GetColor(LogEventLevel level)
    {
        return level switch
        {
            LogEventLevel.Debug => "\u001b[37m",
            LogEventLevel.Information => "\u001b[32m",
            LogEventLevel.Warning => "\u001b[33m",
            LogEventLevel.Error => "\u001b[31m",
            LogEventLevel.Fatal => "\u001b[31m",
            _ => "\u001b[37m"
        };
    }
}