﻿using System;

namespace DocsPortingTool
{
    public class Log
    {
        private static void WriteLine(string format, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine(format);
            }
            else
            {
                Console.WriteLine(format, args);
            }
        }

        private static void Write(string format, params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.Write(format);
            }
            else
            {
                Console.Write(format, args);
            }
        }

        public static void Print(bool endline, ConsoleColor foregroundColor, string format, params object[] args)
        {
            ConsoleColor initialColor = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;
            if (endline)
            {
                WriteLine(format, args);
            }
            else
            {
                Write(format, args);
            }
            Console.ForegroundColor = initialColor;
        }

        public static void Info(string format)
        {
            Info(format, null);
        }

        public static void Info(string format, params object[] args)
        {
            Info(true, format, args);
        }

        public static void Info(bool endline, string format, params object[] args)
        {
            Print(endline, ConsoleColor.White, format, args);
        }

        public static void Success(string format)
        {
            Success(format, null);
        }

        public static void Success(string format, params object[] args)
        {
            Success(true, format, args);
        }

        public static void Success(bool endline, string format, params object[] args)
        {
            Print(endline, ConsoleColor.Green, format, args);
        }

        public static void Warning(string format)
        {
            Warning(format, null);
        }

        public static void Warning(string format, params object[] args)
        {
            Warning(true, format, args);
        }

        public static void Warning(bool endline, string format, params object[] args)
        {
            Print(endline, ConsoleColor.Yellow, format, args);
        }

        public static void Error(string format)
        {
            Error(format, null);
        }

        public static void Error(string format, params object[] args)
        {
            Error(true, format, args);
        }

        public static void Error(bool endline, string format, params object[] args)
        {
            Print(endline, ConsoleColor.Red, format, args);
        }

        public static void Cyan(string format)
        {
            Cyan(format, null);
        }

        public static void Cyan(string format, params object[] args)
        {
            Cyan(true, format, args);
        }

        public static void Magenta(bool endline, string format, params object[] args)
        {
            Print(endline, ConsoleColor.Magenta, format, args);
        }

        public static void Magenta(string format)
        {
            Magenta(format, null);
        }

        public static void Magenta(string format, params object[] args)
        {
            Magenta(true, format, args);
        }

        public static void Cyan(bool endline, string format, params object[] args)
        {
            Print(endline, ConsoleColor.Cyan, format, args);
        }

        public static void Assert(bool condition, string format, params object[] args)
        {
            Assert(true, condition, format, args);
        }

        public static void Assert(bool endline, bool condition, string format, params object[] args)
        {
            if (condition)
            {
                Success(endline, format, args);
            }
            else
            {
                Error(endline, format, args);
            }
        }

        public static void Line()
        {
            Console.WriteLine();
        }

        public delegate void PrintHelpFunction();

        public static void LogErrorAndExit(string format, params object[] args)
        {
            Error(format, args);
            Environment.Exit(0);
        }

        public static void LogErrorPrintHelpAndExit(string format, params object[] args)
        {
            Error(format, args);
            PrintHelp();
            Environment.Exit(0);
        }

        public static void PrintHelp()
        {
            Cyan(@"
This tool finds and ports triple slash comments found in .NET repos but do not yet exist in the dotnet-api-docs repo.

Change %SourceRepos% to match the location of all your cloned git repos.

Options:

   bool:           -DisablePrompts          Optional. Will avoid prompting the user for input to correct some particular errors. Default is false.

                                                Usage example:
                                                    -disableprompts true



    no arguments:   -h or -Help             Optional. Displays this help message. If used, nothing else will be processed.



    folder path:    -Docs                   Mandatory. The absolute directory root path where your documentation xml files are located.

                                                Known locations:
                                                    > Runtime:      %SourceRepos%\dotnet-api-docs\xml
                                                    > WPF:          %SourceRepos%\dotnet-api-docs\xml
                                                    > WinForms:     %SourceRepos%\dotnet-api-docs\xml
                                                    > ASP.NET MVC:  %SourceRepos%\AspNetApiDocs\aspnet-mvc\xml
                                                    > ASP.NET Core: %SourceRepos%\AspNetApiDocs\aspnet-core\xml

                                                Usage example:
                                                    -docs %SourceRepos%\dotnet-api-docs\xml,%SourceRepos%\AspNetApiDocs\aspnet-mvc\xml



    string list:    -ExcludedAssemblies         Optional. Comma separated list (no spaces) of specific .NET assemblies to ignore. Default is empty.

                                                Usage example:
                                                    -excludedassemblies System.IO.Compression,System.IO.Pipes



    string list:    -IncludedAssemblies         Mandatory. Comma separated list (no spaces) of assemblies to include.

                                                Usage example:
                                                    -includedassemblies System.IO,System.Runtime.Intrinsics


    string list:    -ExcludedTypes              Optional. Comma separated list (no spaces) of specific types to ignore. Default is empty.

                                                Usage example:
                                                    -excludedtypes ArgumentException,Stream



    string list:    -IncludedTypes         Mandatory. Comma separated list (no spaces) of specific types to include. Default is empty and will include all types in the selected assemblies.

                                                Usage example:
                                                    -includedtypes FileStream,DirectoryInfo



    bool:           -PrintUndoc             Optional. Will print a detailed summary of all the docs APIs that are undocumented. Default is false.

                                                Usage example:
                                                    -printundoc true



    bool:           -Save                   Optional. Whether you want to save the changes in the dotnet-api-docs xml files. Default is false.

                                                Usage example:
                                                    -save true



    bool:           -SkipExceptions         Optional. Whether you want exceptions to be ported or not. Setting this to false can result in a lot of noise because there is no way to
                                            detect if an exception has been ported already, but it went through language review and the original text was not preserved. Default is true (skips them).

                                                Usage example:
                                                    -skipexceptions false


    bool:           -SkipRemarks            Optional. Whether you want remarks to be ported or not. Default is false (includes them).

                                                Usage example:
                                                    -skipremarks true


    bool:    -SkipInterfaceImplementations  Optional. Whether you want the original interface documentation to be considered to fill the undocumented API's documentation when the API
                                             itself does not provide its own documentation. This includes Explicit Interface Implementations. Default is false (includes them).

                                                Usage example:
                                                    -skipinterfaceimplementations true


    folder path:   -TripleSlash             Mandatory. A comma separated list (no spaces) of absolute directory paths where we should recursively look for triple slash comment xml files.

                                                Known locations:
                                                    > Runtime:   %SourceRepos%\runtime\artifacts\bin\
                                                    > CoreCLR:   %SourceRepos%\runtime\artifacts\bin\coreclr\Windows_NT.x64.Release\IL\
                                                    > WinForms:  %SourceRepos%\winforms\artifacts\bin\
                                                    > WPF:       %SourceRepos%\wpf\.tools\native\bin\dotnet-api-docs_netcoreapp3.0\0.0.0.1\_intellisense\netcore-3.0\

                                                Usage example:
                                                    -tripleslash %SourceRepos%\corefx\artifacts\bin\,%SourceRepos%\winforms\artifacts\bin\

            ");
        }
    }
}