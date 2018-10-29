using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
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
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 500;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
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
            request.TimeMin = new DateTime(1997, 9, 11);
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
                    var newItem = new ListViewItem(new string[] { eventItem.Summary, eventItem.Location, start, end });
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
            if (CheckForInternetConnection())
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
            else
                MessageBox.Show("No internet connection available");
        }

        private void btRelogin_Click(object sender, EventArgs e)
        {
            if (credential != null)
            {
                if (CheckForInternetConnection())
                {
                    var task = GoogleWebAuthorizationBroker.ReauthorizeAsync(credential, CancellationToken.None);
                }
                else
                    MessageBox.Show("No internet connection available");
            }
            else
                MessageBox.Show("You are not logged, press button 'Log In / Load event'");
        }

        private void btDelete_Click(object sender, EventArgs e)
        {

            if (lvEvents.SelectedItems.Count != 0)
            {
                if (CheckForInternetConnection())
                {
                    service.Events.Delete("primary", lvEvents.SelectedItems[0].Tag.ToString()).Execute();
                    lvEvents.Items.Remove(lvEvents.SelectedItems[0]);
                }
                else
                    MessageBox.Show("No internet connection available");
            }

        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            if (credential != null)
            {
                if (CheckForInternetConnection())
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
                else
                    MessageBox.Show("No internet connection available");
            }
            else
                MessageBox.Show("To insert event you need to log in");
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (lvEvents.SelectedItems.Count != 0)
            {
                if (CheckForInternetConnection())
                {
                    var FormInsUpd = new FormInsertUpdate("Update")
                    {
                        Summary = lvEvents.SelectedItems[0].SubItems[0].Text,
                        Location = lvEvents.SelectedItems[0].SubItems[1].Text
                    };
                    if (FormInsUpd.ShowDialog() == DialogResult.OK)
                    {
                        service.Events.Get("primary", lvEvents.SelectedItems[0].Tag.ToString()).Execute();
                        Event newEvent = MakeEvent(FormInsUpd.Summary, FormInsUpd.Location, FormInsUpd.Description, FormInsUpd.StartTime, FormInsUpd.StartHour, FormInsUpd.EndTime, FormInsUpd.EndHour);
                        service.Events.Update(newEvent, "primary", lvEvents.SelectedItems[0].Tag.ToString()).Execute();
                        UpdateList();
                    }
                }
                else
                    MessageBox.Show("No internet connection available");
            }   
        }
    }
}
