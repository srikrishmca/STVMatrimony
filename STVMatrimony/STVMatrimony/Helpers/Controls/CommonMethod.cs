using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace STVMatrimony.Helpers.Controls
{
    public class CommonMethod
    {
        private static CustomActivityLoader customLoader { get; set; }

        public async static Task ShowLoading(string message = null)
        {
            try
            {
                if (customLoader != null && PopupNavigation.Instance.PopupStack.Count > 0)
                {
                    customLoader.Message = (string.IsNullOrEmpty(message) ? "Loading..." : message);

                    return;
                }
                customLoader = new CustomActivityLoader(string.IsNullOrEmpty(message) ? "Loading.." : message);
                await PopupNavigation.Instance.PushAsync(customLoader);
            }
            catch (Exception)
            {
            }
        }

        public async static Task HideLoading()
        {
            try
            {
                if (PopupNavigation.Instance.PopupStack.Count > 0)
                {
                    if (customLoader != null)
                    {
                        await PopupNavigation.Instance.RemovePageAsync(customLoader);
                        await Task.Run(() =>
                        {
                            customLoader = null;
                        });
                    }
                    else
                    {
                        var item = PopupNavigation.Instance.PopupStack[PopupNavigation.Instance.PopupStack.Count - 1];
                        if (item is CustomActivityLoader)
                        {
                            await PopupNavigation.Instance.PopAsync();
                        }
                    }
                }
                else
                {
                    await Task.Run(() =>
                    {
                        customLoader = null;
                    });
                }

            }
            catch (Exception)
            {

            }
        }

    }
}
