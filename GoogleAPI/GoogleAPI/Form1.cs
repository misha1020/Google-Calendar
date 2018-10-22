using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleAPI
{
    public partial class Form1 : Form
    {
        static string[] Scopes = { CalendarService.Scope.CalendarEvents };
        UserCredential credential;
        CalendarService service;

        public Form1()
        {
            InitializeComponent();

        }

        public void Read()
        {

        }

        public void OAuth2()
        {
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
                MessageBox.Show("Credential file saved!");
            }
        }

        private void UpdateList()
        {
            lvEvents.Items.Clear();
            // Create Google Calendar API service.
            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Calendar API",
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 100;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = request.Execute();
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string start = eventItem.Start.DateTime.ToString();
                    string end = eventItem.End.DateTime.ToString();
                    if (String.IsNullOrEmpty(start))
                    {
                        start = eventItem.Start.Date;
                    }
                    if (String.IsNullOrEmpty(end))
                    {
                        end = eventItem.Start.Date;
                    }
                    var newItem = new ListViewItem(new string[] { eventItem.Summary, start, end });
                    newItem.Tag = eventItem.Id;
                    lvEvents.Items.Add(newItem);
                }
                lvEvents.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            }
            else
            {
                MessageBox.Show("No upcoming events found.");
            }
        }

        private void AddEvent()
        {

            Event newEvent = new Event()
            {
                Summary = "New SANjsf",
                Location = "800 Howard St., San Francisco, CA 94103",
                Description = "asjhfkajshf"
            };

            DateTime startTime = new DateTime(2018, 10, 22, 16, 30, 0);
            EventDateTime start = new EventDateTime()
            {
                DateTime = startTime,
                TimeZone = "America/Los_Angeles"
            };
            newEvent.Start = start;

            DateTime endTime = new DateTime(2018, 10, 22, 18, 30, 0);
            EventDateTime end = new EventDateTime()
            {
                DateTime = endTime,
                TimeZone = "America/Los_Angeles"
            };
            newEvent.End = end;

            service.Events.Insert(newEvent, "primary").Execute();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OAuth2();
                UpdateList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка аутентификации");
                lvEvents.Items.Clear();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GoogleWebAuthorizationBroker.ReauthorizeAsync(credential, CancellationToken.None);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // Delete an event
            if (lvEvents.SelectedItems.Count != 0)
            {
                service.Events.Delete("primary", lvEvents.SelectedItems[0].Tag.ToString()).Execute();
                lvEvents.Items.Remove(lvEvents.SelectedItems[0]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEvent();

            UpdateList();

        }
    }
}
