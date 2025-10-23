using System;
using System.IO;
using System.Text;

namespace SdxComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            // Try multiple possible locations for the files
            string? file1Path = args.Length > 0 ? args[0] : FindFile("Channels Original.sdx");
            string? file2Path = args.Length > 1 ? args[1] : FindFile("Channels Copy.sdx");

            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine("      SDX FILE BYTE-BY-BYTE COMPARISON TOOL");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");

            if (string.IsNullOrEmpty(file1Path) || !File.Exists(file1Path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ File not found: Channels Original.sdx");
                Console.WriteLine($"   Searched in:");
                Console.WriteLine($"   - {Path.GetFullPath(".")}");
                Console.WriteLine($"   - {Path.GetFullPath("..")}");
                Console.WriteLine($"   - {Path.GetFullPath("../..")}");
                Console.ResetColor();
                return;
            }

            if (string.IsNullOrEmpty(file2Path) || !File.Exists(file2Path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ File not found: Channels Copy.sdx");
                Console.WriteLine($"   Found File 1 at: {file1Path}");
                Console.WriteLine($"   But File 2 is missing. Please create it by:");
                Console.WriteLine($"   1. Run the main SDX Channel Manager application");
                Console.WriteLine($"   2. Open 'Channels Original.sdx'");
                Console.WriteLine($"   3. Save as 'Channels Copy.sdx' without modifications");
                Console.ResetColor();
                return;
            }

            CompareFiles(file1Path, file2Path);
        }

        private static string? FindFile(string fileName)
        {
            // Try current directory first
            if (File.Exists(fileName))
                return fileName;
            
            // Try parent directory
            string parentPath = Path.Combine("..", fileName);
            if (File.Exists(parentPath))
                return parentPath;
            
            // Try two levels up (for when running from bin/Debug)
            string grandparentPath = Path.Combine("..", "..", fileName);
            if (File.Exists(grandparentPath))
                return grandparentPath;
            
            // Try three levels up
            string greatGrandparentPath = Path.Combine("..", "..", "..", fileName);
            if (File.Exists(greatGrandparentPath))
                return greatGrandparentPath;
            
            // Try in the solution root (common when running from VS)
            string solutionRoot = Path.Combine("..", "..", "..", "..", fileName);
            if (File.Exists(solutionRoot))
                return solutionRoot;
            
            return null;
        }

        private static void CompareFiles(string file1Path, string file2Path)
        {
            // Read both files
            byte[] file1Bytes = File.ReadAllBytes(file1Path);
            byte[] file2Bytes = File.ReadAllBytes(file2Path);
            string file1Text = File.ReadAllText(file1Path, Encoding.UTF8);
            string file2Text = File.ReadAllText(file2Path, Encoding.UTF8);

            // File info
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("📁 FILE INFORMATION:");
            Console.ResetColor();
            Console.WriteLine($"   File 1: {Path.GetFileName(file1Path)}");
            Console.WriteLine($"   Size:   {file1Bytes.Length:N0} bytes ({file1Text.Length:N0} chars)");
            Console.WriteLine($"\n   File 2: {Path.GetFileName(file2Path)}");
            Console.WriteLine($"   Size:   {file2Bytes.Length:N0} bytes ({file2Text.Length:N0} chars)");

            // Size comparison
            Console.WriteLine();
            if (file1Bytes.Length == file2Bytes.Length)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ File sizes MATCH");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                long diff = file2Bytes.Length - file1Bytes.Length;
                Console.WriteLine($"❌ File sizes DIFFER by {Math.Abs(diff):N0} bytes");
                Console.WriteLine($"   File 2 is {(diff > 0 ? "LARGER" : "SMALLER")}");
                Console.ResetColor();
            }

            Console.WriteLine("\n" + new string('─', 55) + "\n");

            // Byte-by-byte comparison
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("🔍 BYTE-BY-BYTE COMPARISON:");
            Console.ResetColor();

            int minLength = Math.Min(file1Bytes.Length, file2Bytes.Length);
            int differenceCount = 0;
            int firstDifferencePos = -1;

            for (int i = 0; i < minLength; i++)
            {
                if (file1Bytes[i] != file2Bytes[i])
                {
                    if (firstDifferencePos == -1)
                    {
                        firstDifferencePos = i;
                    }
                    differenceCount++;
                }
            }

            if (file1Bytes.Length != file2Bytes.Length)
            {
                differenceCount += Math.Abs(file1Bytes.Length - file2Bytes.Length);
            }

            Console.WriteLine($"   Comparing first {minLength:N0} bytes...\n");

            if (differenceCount == 0 && file1Bytes.Length == file2Bytes.Length)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═══════════════════════════════════════════════════╗");
                Console.WriteLine("║                                                   ║");
                Console.WriteLine("║     ✅ FILES ARE BYTE-IDENTICAL! ✅              ║");
                Console.WriteLine("║                                                   ║");
                Console.WriteLine("║     Perfect match - no differences found!         ║");
                Console.WriteLine("║                                                   ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════╝");
                Console.ResetColor();
                return;
            }

            // Show differences
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ DIFFERENCES FOUND: {differenceCount:N0} byte(s) differ");
            Console.ResetColor();
            Console.WriteLine($"   First difference at byte position: {firstDifferencePos:N0}\n");

            // Show first 5 differences in detail
            Console.WriteLine(new string('─', 55) + "\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("📊 DETAILED ANALYSIS (First 5 differences):\n");
            Console.ResetColor();

            int diffCount = 0;
            for (int i = 0; i < minLength && diffCount < 5; i++)
            {
                if (file1Bytes[i] != file2Bytes[i])
                {
                    diffCount++;
                    ShowDifference(i, file1Text, file2Text, file1Bytes, file2Bytes);
                }
            }

            // Show if one file is longer
            if (file1Bytes.Length != file2Bytes.Length)
            {
                Console.WriteLine(new string('─', 55));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n⚠️  File length difference:");
                Console.ResetColor();
                
                if (file2Bytes.Length > file1Bytes.Length)
                {
                    int extraBytes = file2Bytes.Length - file1Bytes.Length;
                    Console.WriteLine($"   File 2 has {extraBytes:N0} EXTRA bytes at the end");
                    Console.WriteLine($"\n   Extra content preview:");
                    ShowExtraContent(file2Text, file1Text.Length, Math.Min(200, extraBytes));
                }
                else
                {
                    int missingBytes = file1Bytes.Length - file2Bytes.Length;
                    Console.WriteLine($"   File 2 is MISSING {missingBytes:N0} bytes");
                    Console.WriteLine($"\n   Missing content preview:");
                    ShowExtraContent(file1Text, file2Text.Length, Math.Min(200, missingBytes));
                }
            }

            Console.WriteLine("\n" + new string('═', 55));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n💡 RECOMMENDATION:");
            Console.ResetColor();
            Console.WriteLine("   Check the differences above to identify the pattern.");
            Console.WriteLine("   Look for missing/extra commas, quotes, or properties.\n");
        }

        private static void ShowDifference(int position, string text1, string text2, byte[] bytes1, byte[] bytes2)
        {
            Console.WriteLine($"Difference #{position:N0}:");
            Console.WriteLine(new string('─', 55));

            // Show byte values
            Console.Write("   Byte value: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"File1=0x{bytes1[position]:X2} ");
            Console.ResetColor();
            Console.Write("vs ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"File2=0x{bytes2[position]:X2}");
            Console.ResetColor();

            // Show character values
            char char1 = position < text1.Length ? text1[position] : '\0';
            char char2 = position < text2.Length ? text2[position] : '\0';
            
            Console.Write("   Character:  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"File1='{GetDisplayChar(char1)}' ");
            Console.ResetColor();
            Console.Write("vs ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"File2='{GetDisplayChar(char2)}'");
            Console.ResetColor();

            // Show context (100 chars before and after)
            int contextStart = Math.Max(0, position - 100);
            int contextLength = Math.Min(200, Math.Min(text1.Length - contextStart, text2.Length - contextStart));

            if (contextStart < text1.Length && contextStart < text2.Length)
            {
                Console.WriteLine("\n   Context (100 chars before and after):");
                
                // File 1 context
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("   File1: ");
                Console.ResetColor();
                string context1 = text1.Substring(contextStart, Math.Min(contextLength, text1.Length - contextStart));
                int highlightPos1 = position - contextStart;
                if (highlightPos1 >= 0 && highlightPos1 < context1.Length)
                {
                    Console.Write(EscapeForDisplay(context1.Substring(0, highlightPos1)));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(GetDisplayChar(context1[highlightPos1]));
                    Console.ResetColor();
                    if (highlightPos1 + 1 < context1.Length)
                    {
                        Console.Write(EscapeForDisplay(context1.Substring(highlightPos1 + 1)));
                    }
                }
                Console.WriteLine();

                // File 2 context
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("   File2: ");
                Console.ResetColor();
                string context2 = text2.Substring(contextStart, Math.Min(contextLength, text2.Length - contextStart));
                int highlightPos2 = position - contextStart;
                if (highlightPos2 >= 0 && highlightPos2 < context2.Length)
                {
                    Console.Write(EscapeForDisplay(context2.Substring(0, highlightPos2)));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(GetDisplayChar(context2[highlightPos2]));
                    Console.ResetColor();
                    if (highlightPos2 + 1 < context2.Length)
                    {
                        Console.Write(EscapeForDisplay(context2.Substring(highlightPos2 + 1)));
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void ShowExtraContent(string text, int startPos, int length)
        {
            if (startPos >= text.Length) return;
            
            string extra = text.Substring(startPos, Math.Min(length, text.Length - startPos));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"   \"{EscapeForDisplay(extra)}...\"");
            Console.ResetColor();
        }

        private static string GetDisplayChar(char c)
        {
            if (c == '\0') return "\\0";
            if (c == '\n') return "\\n";
            if (c == '\r') return "\\r";
            if (c == '\t') return "\\t";
            if (char.IsControl(c)) return $"\\u{(int)c:X4}";
            return c.ToString();
        }

        private static string EscapeForDisplay(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                sb.Append(GetDisplayChar(c));
            }
            return sb.ToString();
        }
    }
}
