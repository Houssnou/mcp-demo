﻿using mcp_demo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<CountryService>();

await builder.Build().RunAsync();

// [McpServerToolType]
// public static class EchoTool
// {
//     [McpServerTool, Description("Echoes the message back to the client.")]
//     public static string Echo(string message) => $"Hello from C#: {message}";

//     [McpServerTool, Description("Echoes back the message in reverse.")]
//     public static string Reverse(string message) => new string((char[]?)message.Reverse());

//     [McpServerTool, Description("Returns the length of the message.")]
//     public static int Length(string message) => message.Length;
// }

