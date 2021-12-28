using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{



    public  class NotepadPrintHelper
    {

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint GetShortPathName(
           [MarshalAs(UnmanagedType.LPTStr)]
   string lpszLongPath,
           [MarshalAs(UnmanagedType.LPTStr)]
   StringBuilder lpszShortPath,
           uint cchBuffer);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint GetShortPathName(string lpszLongPath, char[] lpszShortPath, int cchBuffer);

        private StreamWriter sw;
        public   enum FontStyles
        {
            Regular = 1,
            Big = 2,
            Compressed = 3
        }

        [DefaultValue(PrintAlign.Left)]
        public  PrintAlign PrintAlignment { get; set; }
        [DefaultValue(FontStyles.Regular)]
        public  FontStyles FontStyle { get; set; }

     
      private int _lineNo=0;
      private int _colNo=0;
      private bool _newline;
      private string  _path;
      public NotepadPrintHelper( )
      {
          PrintAlignment = PrintAlign.Left;
          FontStyle = FontStyles.Regular;
          NewLine = true;
      }

      public bool OpenWriter(string path)
      {
          try
          {
              string str="";
              sw = File.CreateText(path);
             
              _path = path;
          }
          catch (Exception ex)
          {
          }
          if (sw != null)
              return true;
          else
              return false;
      }


      public void CloseWriter()
      {
          sw.Close();
          sw.Dispose();
      }

      public bool NewLine
      {
          get
          {
              return _newline;
          }
          set
          {
              _newline = value;
              if (value)
              {
                  if(sw!=null)
                  sw.WriteLine();
                  _colNo = 0;
              }
          }
      }

      

           public void PrintString(string outputstring,int Width=0)
      {
          if (NewLine)
          {
              _lineNo++; 
          }

       

         string s = "";
         if (Width == 0)
         {
             Width = GetCpi();

         }

         int padlength = 0;
         if (FontStyle == FontStyles.Big)
         {


             if (outputstring.Length > GetCpi() - _colNo)
             {
                 s = (char)(14) + outputstring.Substring(0, GetCpi() - _colNo) + (char)(20);
             }
             else
             {
                 s = (char)(14) + outputstring + (char)(20);
             }
             _colNo += s.Length - 2;
         }

         else if (FontStyle == FontStyles.Compressed)
         {
             if (outputstring.Length > GetCpi() - _colNo)
             {
                 s = (char)(15) + outputstring.Substring(0, GetCpi() - _colNo) + (char)(18);
             }
             else
             {
                 s = (char)(15) + outputstring + (char)(18);
             }
             _colNo += s.Length - 2;
         }
         else
         {
             if (outputstring.Length > GetCpi() - _colNo)
             {
                 s = outputstring.Substring(0, GetCpi() - _colNo);
             }
             else
             {
                 s = outputstring;
             }
             _colNo += s.Length;
         }
         if (PrintAlignment == PrintAlign.Center)
         {
            

             if (s.Length < Width)
             {
                 padlength = (int)(Width - s.Length) / 2;

                 s = new string(' ', padlength) + s + new string(' ', Width - (padlength + s.Length));
             }
         }
         else if (PrintAlignment == PrintAlign.Right)
         {
             if (s.Length < Width)
             {
                 padlength = (int)(Width - s.Length);
                 s = new string(' ', padlength) + s;
             }
            
            
         }
         else
         {
             if (s.Length < Width)
             {
                 padlength = (int)(Width - s.Length);
                 s += new string(' ', padlength)  ;
             }

         }


         if (NewLine)
         {
             sw.WriteLine(s);
             _colNo = 0;
         }
         else
         {
             sw.Write(s);
         }
      }
          

      public  int GetCpi()
      {
          if (FontStyle == FontStyles.Big)
          {
              return 40;
          }
          else if (FontStyle == FontStyles.Compressed)
          {
              return 120;
          }
          else
          {
              return 80;
          }
      }
        public void PrintLine(char chr,int length=0)
        {
            if (length == 0)
            {
                PrintString(new string(chr,GetCpi()));
            }
            else
            {
                PrintString(new string(chr,length ));
            }
        }

        public void Print()
        {

            for (int i=0;i<=10;i++)
            {
                        PrintString(" ");
 
            }

             CloseWriter();

             if (File.Exists(Application.StartupPath + "RollBack.txt"))
             {
                 project.Classes.Common.ExecuteCommand(@"copy " + ToShortPathName(Application.StartupPath + "RollBack.txt") + " LPT1");

             }
             project.Classes.Common.ExecuteCommand(@"copy " + ToShortPathName(_path) + " LPT1");
                 
            
            
        }

        /// <summary>
        /// The ToLongPathNameToShortPathName function retrieves the short path form of a specified long input path
        /// </summary>
        /// <param name="longName">The long name path</param>
        /// <returns>A short name path string</returns>
        public static string ToShortPathName(string longName)
        {
            uint bufferSize = 256;

            // don´t allocate stringbuilder here but outside of the function for fast access
            StringBuilder shortNameBuffer = new StringBuilder((int)bufferSize);

            uint result = GetShortPathName(longName, shortNameBuffer, bufferSize);

            return shortNameBuffer.ToString();
        }

        public string ShortPath(string longpath)
        {
            char[] buffer = new char[256];

            GetShortPathName(longpath, buffer, buffer.Length);

            return new string(buffer);
        }
    }
}
