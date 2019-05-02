using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Yansoft.Rest;

namespace MobRjApp.Pages
{
    public static class Utils
    {
        public static async Task RestRunAsync(Page page, Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (RestException ex) when (ex.Response == null)
            {
                await page.DisplayAlert("Ops!", "Parece que você não se conectou a Internet.", "Ok");
            }
            catch (RestException ex)
            {
                await page.DisplayAlert("Ops!", ex.Message, "Ok");
            }
        }
    }
}
