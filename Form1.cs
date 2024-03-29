﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShredPro
{
    public partial class Form1 : Form
    {
        private bool shreddingInProgress = false;

        public Form1()
        {
            InitializeComponent();
            lbFiles.AllowDrop = true;

            cmbAlgorithms.Items.Add("Random Data");
            cmbAlgorithms.Items.Add("Zeroes");
            cmbAlgorithms.Items.Add("DoD Standard (3 passes)");
            cmbAlgorithms.Items.Add("Gutmann Method (35 passes)");
            cmbAlgorithms.SelectedIndex = 0;

            PopulateAlphabetComboBox();
            comboBoxAlphabet.SelectedIndexChanged += ComboBoxAlphabet_SelectedIndexChanged;
        }

        string currentDriveLetter;

        private void ComboBoxAlphabet_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentDriveLetter = comboBoxAlphabet.SelectedItem.ToString();
        }

        private void PopulateAlphabetComboBox()
        {
            comboBoxAlphabet.Items.Clear();

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                comboBoxAlphabet.Items.Add(letter);
            }
        }

        private void UpdateTotalFileSize()
        {
            long totalSize = 0;

            foreach (var item in lbFiles.Items)
            {
                string path = item.ToString();

                if (File.Exists(path))
                {
                    totalSize += new FileInfo(path).Length;
                }
                else if (Directory.Exists(path))
                {
                    totalSize += GetDirectorySize(path);
                }
            }

            lblTotalSize.Text = $"Total File Size: {FormatFileSize(totalSize)}";
        }

        private long GetDirectorySize(string path)
        {
            long size = 0;

            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                size += new FileInfo(file).Length;
            }

            string[] subdirectories = Directory.GetDirectories(path);
            foreach (string subdirectory in subdirectories)
            {
                size += GetDirectorySize(subdirectory);
            }

            return size;
        }

        private string FormatFileSize(long sizeInBytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;

            while (sizeInBytes >= 1024 && order < sizes.Length - 1)
            {
                order++;
                sizeInBytes = sizeInBytes / 1024;
            }

            return $"{sizeInBytes:0.##} {sizes[order]}";
        }

        private void btnShred_Click(object sender, EventArgs e)
        {
            if (!shreddingInProgress)
            {
                shreddingInProgress = true;
                DialogResult result = MessageBox.Show("Are you sure you want to shred these files?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    ShredFiles();
                }

                shreddingInProgress = false;
            }
        }

        private void lbFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (!lbFiles.Items.Contains(file))
                {
                    lbFiles.Items.Add(file);
                }
            }

            UpdateTotalFileSize();
        }

        private void ShredFiles()
        {
            string selectedAlgorithm = cmbAlgorithms.SelectedItem.ToString();

            foreach (var item in lbFiles.Items)
            {
                string path = item.ToString();

                try
                {
                    if (Directory.Exists(path))
                    {
                        ShredDirectory(path, selectedAlgorithm);
                    }
                    else if (File.Exists(path))
                    {
                        ShredFile(path, selectedAlgorithm);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error shredding {path}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            lbFiles.Items.Clear();

            UpdateTotalFileSize();
        }

        private void ShredFile(string filePath, string algorithm)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                {
                    ShredData(fs, algorithm);
                }

                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error shredding file {filePath}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShredDirectory(string directoryPath, string algorithm)
        {
            // Shred all files in the directory
            foreach (string file in Directory.GetFiles(directoryPath))
            {
                ShredFile(file, algorithm);
            }

            // Recursively shred files in subdirectories
            foreach (string subdirectory in Directory.GetDirectories(directoryPath))
            {
                ShredDirectory(subdirectory, algorithm);
            }

            // Remove the empty directory
            Directory.Delete(directoryPath);
        }


        private void ShredData(FileStream fs, string algorithm)
        {
            switch (algorithm)
            {
                case "Random Data":
                    if (fs != null && fs.Length > 0)
                    {
                        byte[] randomBuffer = new byte[fs.Length];
                        new Random().NextBytes(randomBuffer);

                        try
                        {
                            fs.Write(randomBuffer, 0, randomBuffer.Length);
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("IOException during the Random Data Method, " + ex.Message);
                        }
                    }

                    else if (fs != null && fs.Length == 0)
                    {
                        try
                        {
                            File.Delete(fs.Name);
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("IOException during file deletion, " + ex.Message);
                        }
                    }

                    break;

                case "Zeroes":
                    if (fs != null && fs.Length > 0)
                    {
                        byte[] zeroBuffer = new byte[fs.Length];

                        try
                        {
                            fs.Write(zeroBuffer, 0, zeroBuffer.Length);
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("IOException during the Zeroes Method, " + ex.Message);
                        }
                    }

                    else if (fs != null && fs.Length == 0)
                    {
                        try
                        {
                            File.Delete(fs.Name);
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("IOException during file deletion, " + ex.Message);
                        }
                    }

                    break;

                case "DoD Standard (3 passes)":
                    if (fs != null && fs.Length > 0)
                    {
                        byte[] dodBuffer = new byte[fs.Length];

                        try
                        {
                            fs.Write(dodBuffer, 0, dodBuffer.Length);

                            for (int i = 0; i < dodBuffer.Length; i++)
                            {
                                dodBuffer[i] = 0xFF;
                            }
                            fs.Write(dodBuffer, 0, dodBuffer.Length);

                            new Random().NextBytes(dodBuffer);
                            fs.Write(dodBuffer, 0, dodBuffer.Length);
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("IOException during the DoD Method, " + ex.Message);
                        }
                    }

                    else if (fs != null && fs.Length == 0)
                    {
                        try
                        {
                            File.Delete(fs.Name);
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("IOException during file deletion, " + ex.Message);
                        }
                    }

                    break;

                case "Gutmann Method (35 passes)":
                    if (fs != null || fs.Length != 0)
                    {
                        byte[] gutmannBuffer = new byte[fs.Length];

                        for (int pass = 0; pass < 35; pass++)
                        {
                            for (int i = 0; i < gutmannBuffer.Length; i++)
                            {
                                gutmannBuffer[i] = (byte)pass;
                            }

                            try
                            {
                                fs.Write(gutmannBuffer, 0, gutmannBuffer.Length);
                            }
                            catch (IOException ex)
                            {
                                Console.WriteLine("IOException during the Gutmann Method, " + ex.Message);
                            }
                        }
                    }

                    else if (fs != null && fs.Length == 0)
                    {
                        try
                        {
                            File.Delete(fs.Name);
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("IOException during file deletion, " + ex.Message);
                        }
                    }

                    break;

                default:
                    throw new ArgumentException("Invalid shredding algorithm");
            }
        }

        private void lbFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnZeroData_Click(object sender, EventArgs e)
        {
            if (!shreddingInProgress)
            {
                shreddingInProgress = true;
                DialogResult result = MessageBox.Show("Are you sure you want to overwrite all unallocated space with zeros?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    OverwriteUnallocatedSpace(currentDriveLetter);
                }

                shreddingInProgress = false;
            }
        }

        private void OverwriteUnallocatedSpace(string driveLetter)
        {
            try
            {
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        using (Process process = new Process())
                        {
                            ProcessStartInfo psi = new ProcessStartInfo
                            {
                                FileName = "cmd.exe",  // Use the command prompt
                                Arguments = $"/c sdelete.exe -z {driveLetter.ToLower()}:",
                                RedirectStandardOutput = true,
                                UseShellExecute = false,
                                CreateNoWindow = false  // Show the command prompt window
                            };

                            process.StartInfo = psi;
                            process.Start();

                            string output = process.StandardOutput.ReadToEnd();
                            process.WaitForExit();

                            if (process.ExitCode != 0)
                            {
                                Console.WriteLine($"sdelete.exe process exited with non-zero code: {process.ExitCode}");
                            }

                            Console.WriteLine(output);
                        }
                    }
                    catch (Win32Exception ex)
                    {
                        Console.WriteLine($"Win32Exception: {ex.Message}, NativeErrorCode: {ex.NativeErrorCode}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"InvalidOperationException: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unhandled Exception: {ex}");
                    }
                });

                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled Exception: {ex}");
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            lbFiles.Items.Clear();
        }
    }
}