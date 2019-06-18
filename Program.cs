﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace David
class ThreadNaming
{
    static void Main()
    {
        Thread.CurrentThread.Name = "main";
        Thread worker = new Thread(Go);
        worker.Name = "worker";
        worker.Start();
        Go();
    }
    static void Go()
    {
        Console.WriteLine("Hello from " + Thread.CurrentThread.Name);
    }
}



private void someFunc(string line)
{
    
    ProcessStartInfo pc = new ProcessStartInfo("cmd", @"/c script.py " + line);
    pc.StandardOutputEncoding = Encoding.GetEncoding(866);
    pc.WindowStyle = ProcessWindowStyle.Hidden;
    pc.RedirectStandardOutput = true;
    pc.UseShellExecute = false;
    pc.CreateNoWindow = true;
    Process procCommand = Process.Start(pc);
    StreamReader srIncoming = procCommand.StandardOutput;
    string Textt = srIncoming.ReadToEnd();
    procCommand.WaitForExit();



    if (Textt.Contains("good"))
    {
        this.Invoke(new Action(() => { richTextBox1.AppendText(line + " good" + Environment.NewLine); }));
        this.Invoke(new Action(() => { richTextBox1.Refresh(); }));
        StreamWriter myfile = new StreamWriter("goood.txt", true);
        myfile.WriteLine(line);
        myfile.Close();
        count2 = count2 + 1;
        this.Invoke(new Action(() => { label4.Text = count2.ToString(); }));
        this.Invoke(new Action(() => { label4.Refresh(); ; }));
    }
    else
    {
        this.Invoke(new Action(() => { richTextBox1.AppendText(line + " bad" + Environment.NewLine); }));
        this.Invoke(new Action(() => { richTextBox1.Refresh(); }));
        count3 = count3 + 1;
        this.Invoke(new Action(() => { label5.Text = count3.ToString(); }));
        this.Invoke(new Action(() => { label5.Refresh(); ; }));
    };
    count1 = count1 - 1;
    this.Invoke(new Action(() => { label3.Text = count1.ToString(); }));
    this.Invoke(new Action(() => { label3.Refresh(); ; }));
    // }
    // read.Close();
    this.Invoke(new Action(() => { label2.Text = "Готово"; button1.Enabled = true; button2.Enabled = true; pictureBox1.Visible = false; }));

}