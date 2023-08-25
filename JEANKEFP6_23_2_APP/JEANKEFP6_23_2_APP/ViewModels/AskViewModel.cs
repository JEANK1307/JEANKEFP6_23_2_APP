using JEANKEFP6_23_2_APP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                                             string pDetail)
        {
            if (IsBusy) return false;
            IsBusy = true;
            try
            {

                MyAsk = new Ask();

                MyAsk.Ask1 = pAsk1;
                MyAsk.ImageUrl = pImageUrl;
                MyAsk.AskDetail = pDetail;


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

        public async Task<ObservableCollection<Ask>> GetAskAsync(int pUserID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<Ask> protocols = new ObservableCollection<Ask>();

                MyAsk.UserId = pUserID;

                protocols = await MyAsk.GetAskListByUserID();

                if (protocols == null)
                {
                    return null;
                }
                return protocols;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

    }
}
