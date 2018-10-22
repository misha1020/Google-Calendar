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
    public partial class FormCalendar : Form
    {
        static string[] Scopes = { CalendarService.Scope.CalendarEvents };
        UserCredential credential;
        CalendarService service;

        public FormCalendar()
        {
            InitializeComponent();

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

        private Event MakeEvent(string summary, string location, string description, DateTime startTime, DateTime startHour, DateTime endTime, DateTime endHour)
        {
            Event newEvent = new Event()
            {
                Summary = summary,
                Location = location,
                Description = description
            };
            
            DateTime inTheStart = new DateTime(startTime.Year, startTime.Month, startTime.Day,  startHour.Hour, startHour.Minute, startHour.Second);
            EventDateTime start = new EventDateTime()
            {
                DateTime = inTheStart
            };
            newEvent.Start = start;

            DateTime inTheEnd = new DateTime(endTime.Year, endTime.Month, endTime.Day, endHour.Hour, endHour.Minute, endHour.Second);
            EventDateTime end = new EventDateTime()
            {
                DateTime = inTheEnd
            };
            newEvent.End = end;

            return newEvent;            
        }

        private void btAuth_Click(object sender, EventArgs e)
        {
            try
            {
                OAuth2();
                UpdateList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Authentication failed!");
                lvEvents.Items.Clear();
            }

        }

        private void btRelogin_Click(object sender, EventArgs e)
        {
            GoogleWebAuthorizationBroker.ReauthorizeAsync(credential, CancellationToken.None);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lvEvents.SelectedItems.Count != 0)
            {
                service.Events.Delete("primary", lvEvents.SelectedItems[0].Tag.ToString()).Execute();
                lvEvents.Items.Remove(lvEvents.SelectedItems[0]);
            }
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            var FormInsUpd = new FormInsertUpdate("Insert");
            if (FormInsUpd.ShowDialog() == DialogResult.OK)
            {
                {
                    Event newEvent = MakeEvent(FormInsUpd.Summary, FormInsUpd.Location, FormInsUpd.Description, FormInsUpd.StartTime, FormInsUpd.StartHour, FormInsUpd.EndTime, FormInsUpd.EndHour);
                    service.Events.Insert(newEvent, "primary").Execute();
                    UpdateList();
                }
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (lvEvents.SelectedItems.Count != 0)
            {
                var FormInsUpd = new FormInsertUpdate("Update")
                {
                    Summary = lvEvents.SelectedItems[0].Text
                };
                if (FormInsUpd.ShowDialog() == DialogResult.OK)
                {
                    service.Events.Get("primary", lvEvents.SelectedItems[0].Tag.ToString()).Execute();
                    Event newEvent = MakeEvent(FormInsUpd.Summary, FormInsUpd.Location, FormInsUpd.Description, FormInsUpd.StartTime, FormInsUpd.StartHour, FormInsUpd.EndTime, FormInsUpd.EndHour);
                    service.Events.Update(newEvent, "primary", lvEvents.SelectedItems[0].Tag.ToString()).Execute();
                    UpdateList();
                }
            }
        }
    }
}
