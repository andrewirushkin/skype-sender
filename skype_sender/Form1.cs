using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SKYPE4COMLib;

namespace skype_sender
{
    using System.Threading;
using System.Collections;
    public delegate void AsyncOperationInvoker(AsyncOperation operation);

    public partial class Form1 : Form
    {
        private Skype skype;
        private Boolean notOffline = false;
        private Boolean isDelay = false;
        private String message = "";
        private String sentTo = "";
        private Boolean autorespond = false;
        private Boolean continueSend = false;
        private  _ISkypeEvents_MessageStatusEventHandler handler;
        private List<int> answered = new List<int>();
        private List<String> answeredStr = new List<String>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                skype = new Skype();
                AsyncOperation ao = AsyncOperationManager.CreateOperation(skype);
                new AsyncOperationInvoker(initLaunch).BeginInvoke(ao, null, null);
                label1.BackColor = Color.PeachPuff;
                //handler = new _ISkypeEvents_MessageStatusEventHandler(messageHandler);
                ((_ISkypeEvents_Event)skype).MessageStatus += messageHandler;
                ((_ISkypeEvents_Event)skype).AttachmentStatus += OurAttachmentStatus;
            }
            catch
            {
                MessageBox.Show("Блиин, что-то пошло не так, попробуй перезапустить программу.", "Ошибка однако", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                output.Text = "Надо что-то написать, чтобы отправить)";
                return;
            }
            if (button1.Text == "Отправить")
            {
                button1.Text = "Остановить";
                continueSend = true;
                sentTo = "";
                message = richTextBox1.Text;
                notOffline = notSendToOffline.Checked;
                isDelay = delay.Checked;
                AsyncOperation ao = AsyncOperationManager.CreateOperation(skype);
                new AsyncOperationInvoker(send).BeginInvoke(ao, null, null);
            }
            else
            {
                button1.Text = "Отправить";
                continueSend = false;
            }
            linkLabel1.Visible = true;

        }

        

        // initialization
        private void initLaunch(AsyncOperation operation)
        {
            // в теле этого метода можно обращаться к любому контролу в UI.
            SendOrPostCallback callback = delegate(object state)
            {
                waiting.Text = (String)state;
            };
            try
            {               
                if (!skype.Client.IsRunning)
                {
                    skype.Client.Start(true, true);
                    operation.Post(callback, "Запускаем скайп...");
                    //Thread.Sleep(4000);
                }
                // Use skype protocol version 9 
                skype.Attach(9, true);
                SKYPE4COMLib.UserCollection users = skype.Friends;
                int total = users.Count;
                int online = 0;
                foreach (SKYPE4COMLib.User user in users)
                {
                    if (user.OnlineStatus != TOnlineStatus.olsOffline)
                    {
                        online += 1;
                    }
                }
                operation.Post(callback, "Контактов " + total + ", в сети - " + online);
            }
            catch 
            {
                MessageBox.Show("Блиин, что-то пошло не так, попробуй перезапустить программу.", "Ошибка однако", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }

        private void send(AsyncOperation operation)
        {
            // в теле этого метода можно обращаться к любому контролу в UI.
            SendOrPostCallback callback = delegate(object state)
            {
                if ((int)state == 10000)
                {
                    button1.Text = "Отправить";
                    return;
                }
                output.Text = String.Concat("Послано " , (int)state);
            };

            SKYPE4COMLib.UserCollection users = skype.Friends;
            List<SKYPE4COMLib.User> friends = new List<SKYPE4COMLib.User>();
            IEnumerator en = users.GetEnumerator();
            while (en.MoveNext())
            {
                friends.Add((SKYPE4COMLib.User)en.Current);
            }
            friends.Sort((x,y)=>x.Handle.CompareTo(y.Handle));
            int count = 0;
            foreach (SKYPE4COMLib.User user in friends)
            {
                if (!continueSend)
                {
                    break;
                }
                if (notOffline)
                {
                    if (user.OnlineStatus != TOnlineStatus.olsOffline)
                    {
                        skype.SendMessage(user.Handle, message);
                        sentTo += user.Handle + " (" + user.FullName + ")\n";
                    }
                }
                else
                {
                    skype.SendMessage(user.Handle, message);
                    sentTo += user.Handle + " (" + user.FullName + ")\n";
                }
                count += 1;
                operation.Post(callback, count);
                if (isDelay)
                {
                    Thread.Sleep(1000);
                }
            }
            operation.Post(callback, 10000);
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.setText(sentTo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                label1.Text = "Нужно что-то написать для автоответчика:";
                return;
            }
            if (button2.Text == "Включить")
            {
                label1.Text = "Автоответчик включен";
                label1.BackColor = Color.GreenYellow;
                button2.Text = "Отключить";
                autorespond = true;                
            }
            else
            {
                label1.Text = "Автоответчик отключен";
                label1.BackColor = Color.PeachPuff;
                button2.Text = "Включить";
                autorespond = false;
            }
        }



        private void messageHandler(ChatMessage msg, TChatMessageStatus status)
        {
            if (answered.Contains(msg.Id) 
                || answeredStr.Contains(msg.Sender.Handle+":"+msg.Body)
                || (DateTime.Now - msg.Timestamp)>TimeSpan.FromMinutes(1) )
            {
                return;
            }
            if (autorespond)
            {
                skype.SendMessage(msg.Sender.Handle, richTextBox2.Text);
                answered.Add(msg.Id);
                answeredStr.Add(msg.Sender.Handle + ":" + msg.Body);
            }
        }

        public void OurAttachmentStatus(TAttachmentStatus status)
        {
            try
            {
                if (status == TAttachmentStatus.apiAttachAvailable)
                {
                    skype.Attach(9, false);
                }
                if (status == TAttachmentStatus.apiAttachSuccess)
                {
                    AsyncOperation ao = AsyncOperationManager.CreateOperation(skype);
                    new AsyncOperationInvoker(wakeUpSkype).BeginInvoke(ao, null, null);
                }
            }
            catch (Exception)
            {
            }
        }

        private void wakeUpSkype(AsyncOperation operation)
        {
            try
            {
                while (true)
                {
                    if (true)
                    {
                        skype.SendMessage("echo123", "Скайп, не спи... Не упускай мои сообщения... " + DateTime.Now);
                        //skype.Attach(9, false);
                        Thread.Sleep(60000);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Блиин, что-то пошло не так, попробуй перезапустить программу.", "Ошибка однако", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
