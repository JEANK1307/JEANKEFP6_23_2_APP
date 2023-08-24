using JEANKEFP6_23_2_APP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JEANKEFP6_23_2_APP.ViewModels
{
    public class AskViewModel : BaseViewModel
    {

        public Ask MyAsk { get; set; }

        public AskViewModel()
        {
            MyAsk = new Ask();
        }

        public async Task<bool> AddAskAsync(string pAsk1,
                                             string pImageUrl,
                                             string pAskDetail)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {

                MyAsk = new Ask();

                MyAsk.Ask1 = pAsk1;
                MyAsk.ImageUrl = pImageUrl;
                MyAsk.AskDetail = pAskDetail;


                bool R = await MyAsk.AddAskAsync();

                return R;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
