﻿using System;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceTags
{
    static void Main()
    {
        string text = Console.ReadLine();
        var builder = new StringBuilder(text.Length);
        int pos = 0;
        while (true)
        {
            if (text.IndexOf("<a href=\"", pos) != -1)
            {
                int foundIndex = text.IndexOf("<a href=\"", pos);
                builder.Append(text.Substring(pos, foundIndex - pos));
                pos = foundIndex + 9;

                string url = string.Empty;
                int endIndex = text.IndexOf("\">", pos);
                url = text.Substring(pos, endIndex - pos);
                pos = endIndex + 2;

                string target = string.Empty;
                endIndex = text.IndexOf("</a>", pos);
                target = text.Substring(pos, endIndex - pos);
                builder.Append("[");
                builder.Append(target);
                builder.Append("](");
                builder.Append(url);
                builder.Append(")");
                pos = endIndex + 4;
                if (pos >= text.Length)
                {
                    break;
                }

            }
            else
            {
                builder.Append(text.Substring(pos, text.Length - pos));
                break;
            }
        }
        Console.WriteLine(builder.ToString());
    }
}
