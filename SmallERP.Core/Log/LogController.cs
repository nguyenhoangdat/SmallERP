﻿using System;
using System.Diagnostics;
using System.IO;

namespace SmallERP.Core.Log
{
    public static class LogController
    {
        public static void WriteLog(object data)
        {
            Type type = data.GetType();
            Exception exp;

            //string ErrorDate = string.Concat(DateTime.Now.ToString("dd-MM-yyyy"));
            string ErrorPath = AppDomain.CurrentDomain.BaseDirectory;
            ErrorPath = Path.Combine(ErrorPath, "ErrorLog");
            //ErrorPath = Path.Combine(ErrorPath, ErrorDate);
            if (!Directory.Exists(ErrorPath))
            {
                Directory.CreateDirectory(ErrorPath);
            }
            string ErrorFilename = string.Concat(DateTime.Now.ToString("dd-MM-yyyy"), ".txt");
            string FullLogPath = Path.Combine(ErrorPath, ErrorFilename);

            if (type.Name.Contains("Exception"))
            {
                exp = (Exception)data;
                try
                {
                    StackTrace stackTrace = new StackTrace();
                    string MethodName = stackTrace.GetFrame(1).GetMethod().Name;
                    string Content = string.Concat(DateTime.Now.ToString(), "----Object[Method] : ", MethodName, "-----Message : ", exp.Message, "-----Source : ", exp.StackTrace, Environment.NewLine);
                    File.AppendAllText(FullLogPath, Content, System.Text.Encoding.UTF8);
                }
                catch
                {
                    return;
                }
            }
            else
            {
                try
                {
                    string Content = string.Concat(DateTime.Now.ToString(), "-----Message : ", data, Environment.NewLine);
                    File.AppendAllText(FullLogPath, Content, System.Text.Encoding.UTF8);
                }
                catch
                {
                    return;
                }
            }
        }
        public static void WriteLogBuyCard(object data)
        {
            Type type = data.GetType();
            Exception exp;

            string ErrorDate = string.Concat(DateTime.Now.ToString("dd-MM-yyyy"));
            string ErrorPath = AppDomain.CurrentDomain.BaseDirectory;
            ErrorPath = Path.Combine(ErrorPath, "LogBuyCard");
            ErrorPath = Path.Combine(ErrorPath, ErrorDate);
            if (!Directory.Exists(ErrorPath))
            {
                Directory.CreateDirectory(ErrorPath);
            }
            string ErrorFilename = string.Concat(DateTime.Now.ToString("dd-MM-yyyy"), ".txt");
            string FullLogPath = Path.Combine(ErrorPath, ErrorFilename);

            if (type.Name.Contains("Exception"))
            {
                exp = (Exception)data;
                try
                {
                    StackTrace stackTrace = new StackTrace();
                    string MethodName = stackTrace.GetFrame(1).GetMethod().Name;
                    string Content = string.Concat(DateTime.Now.ToString(), "----Object[Method] : ", MethodName, "-----Message : ", exp.Message, "-----Source : ", exp.StackTrace, Environment.NewLine);
                    File.AppendAllText(FullLogPath, Content, System.Text.Encoding.UTF8);
                }
                catch
                {
                    return;
                }
            }
            else
            {
                try
                {
                    string Content = string.Concat("", "", data, Environment.NewLine);
                    File.AppendAllText(FullLogPath, Content, System.Text.Encoding.UTF8);
                }
                catch
                {
                    return;
                }
            }
        }
    }
}


