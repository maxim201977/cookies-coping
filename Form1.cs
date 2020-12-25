using System;
using System.IO;
using System.Windows.Forms;

namespace Cookies_Hack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //string[] browsers_list = {"Google Chrome", "Mozilla Firefox", "Microsoft Edge", "Opera", "Internet Explorer"};
            string[] browsers_list = { "Google Chrome" };
            foreach (string name in browsers_list) {
                checkedListBox1.Items.Add(name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                progressBar1.Value = 0;
                richTextBox1.Clear();

                button1.Enabled = false;
                progressBar1.Step = 25;
                progressBar1.PerformStep();
                string user_name = Environment.UserName;
                outToLog("Search coockies for user " + user_name);
                progressBar1.PerformStep();

                for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                {
                    Console.WriteLine(checkedListBox1.CheckedItems[x].ToString());
                    switch (checkedListBox1.CheckedItems[x].ToString())
                    {
                        case "Google Chrome":
                            string path_to_coocki = @"C:\Users\" + user_name + @"\AppData\Local\Google\Chrome\User Data\Default\Cookies";
                            if (File.Exists(path_to_coocki))
                            {
                                outToLog("Сookies found");
                                progressBar1.PerformStep();
                                outToLog("Start coping");
                                string exe_path = Environment.CurrentDirectory;
                                if (File.Exists(exe_path + @"\" + Path.GetFileName(path_to_coocki))) {
                                    File.Delete(exe_path + @"\" + Path.GetFileName(path_to_coocki));
                                    File.Copy(path_to_coocki, exe_path + @"\" + Path.GetFileName(path_to_coocki));
                                }
                                else
                                {
                                    File.Copy(path_to_coocki, exe_path + @"\" + Path.GetFileName(path_to_coocki));
                                }
                                outToLog("Coping successful");
                                progressBar1.PerformStep();
                                button1.Enabled = true;
                            }
                            else
                            {
                                outToLog("No cookies found");
                                progressBar1.Value = 0;
                            }
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select browser", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = true;
            }

        }

        void outToLog(string output)
        {
            richTextBox1.AppendText(output + "\r\n");
            richTextBox1.ScrollToCaret();
        }
    }
}
