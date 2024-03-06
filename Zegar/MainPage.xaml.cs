using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Zegar
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            StartClock();
        }

        private void StartClock()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                lbl_clock.Text = DateTime.Now.ToString("T");
                lbl_date.Text = DateTime.Now.ToString("D");

                return true;
            });
        }

        private async void SetAlarm(object sender, EventArgs e)
        {
            var time = timePicker_time.Time;
            var alarmTime = DateTime.Today + time;

            if (alarmTime < DateTime.Now)
            {
                alarmTime.AddDays(1);
            }

            var timeToAlarm = alarmTime - DateTime.Now;

            await Task.Delay(timeToAlarm);

            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Alarm", "Czas się skończył", "OK");
            });
        }

        private async void SetTimer(object sender, EventArgs e)
        {
            try
            {
                int timeInSeconds = int.Parse(entry_timerTime.Text);
                var alarmTime = DateTime.Today.AddSeconds(timeInSeconds);

                var timeToAlarm = alarmTime - DateTime.Now;

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                while (stopWatch.Elapsed < TimeSpan.FromSeconds(600))
                {
                    //
                }

                stopWatch.Stop();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
