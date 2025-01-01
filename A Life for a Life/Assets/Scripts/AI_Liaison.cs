using System;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class AI_Liason : MonoBehaviour
{
    private Process process; // Keep a reference to the cmd process
    private bool processInitialized = false;

    /// <summary>
    /// Initializes a cmd process if not already initialized.
    /// </summary>
    private void InitializeProcess(bool readData)
    {
        if (process == null || process.HasExited)
        {
            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,  // Allows sending commands to cmd
                    RedirectStandardOutput = true, // Capture output
                    RedirectStandardError = true,  // Capture errors
                    CreateNoWindow = false         // Shows the cmd window
                },
                EnableRaisingEvents = true
            };

            if (readData)
            {
                // Attach event handlers for output and error streams
                process.OutputDataReceived += (sender, args) =>
                {
                    if (!string.IsNullOrEmpty(args.Data))
                    {
                        print("[CMD Output]: " + args.Data);
                    }
                };

                process.ErrorDataReceived += (sender, args) =>
                {
                    if (!string.IsNullOrEmpty(args.Data))
                    {
                        print("[CMD Error]: " + args.Data);
                    }
                };

                // Start the process
                process.Start();

                // Begin reading output and error streams
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                processInitialized = true;

            }
            else
            {
                // Start the process
                process.Start();
                processInitialized = true;
            }


        }
    }

    /// <summary>
    /// Sends a command to the cmd process.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    public void RunCommand(string command, bool readData)
    {
        try
        {
            // Ensure the process is initialized
            InitializeProcess(readData);

            // Write the command to the standard input
            process.StandardInput.WriteLine(command);
            process.StandardInput.Flush(); // Ensure the command is sent immediately
        }
        catch (Exception ex)
        {
            print("Exception while running command: " + ex);
        }
    }

    /// <summary>
    /// Closes the cmd process when done.
    /// </summary>
    public void CloseProcess()
    {
        if (process != null && !process.HasExited)
        {
            process.StandardInput.WriteLine("exit"); // Gracefully exit cmd
            process.Close();
            process.Dispose();
            process = null;
            processInitialized = false;
        }
    }

    private void Start()
    {
        // Example usage: Send multiple commands to the same cmd instance
        RunCommand("echo first", false);
        RunCommand("repeat hi to me only", true);
    }
}
