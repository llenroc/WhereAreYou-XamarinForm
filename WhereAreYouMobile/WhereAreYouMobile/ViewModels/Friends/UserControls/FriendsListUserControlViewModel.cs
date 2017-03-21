﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WhereAreYouMobile.Abstractions.Repositories;
using WhereAreYouMobile.Data;
using WhereAreYouMobile.Services.ManagerServices;
using WhereAreYouMobile.ViewModels.User;
using Xamarin.Forms;

namespace WhereAreYouMobile.ViewModels.Friends.UserControls
{
    public class FriendsListUserControlViewModel : BaseViewModel
    {
        #region Services

        private readonly IFriendsManageService _friendsManageService;

        #endregion

        #region Properties

        public ObservableCollection<UserProfile> UsersFound { get; set; } = new ObservableCollection<UserProfile>();
        private ObservableCollection<UserProfile> _tmpUsersFound { get; set; } = new ObservableCollection<UserProfile>();
        private string _info;
        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;

                this.UsersFound.Clear();
                var info = value.ToLower();

                var list = this._tmpUsersFound.Where(x => x.Email.ToLower().Contains(info)
                || x.DisplayName.ToLower().Contains(info)
                || x.FirstName.ToLower().Contains(info)
                   || x.LastName.ToLower().Contains(info))?.Select(s => s);

                foreach (var item in list)
                    this.UsersFound.Add(item);


                OnPropertyChanged();
            }
        }
        #endregion

        #region  Commands

        #endregion

        public FriendsListUserControlViewModel()
        {
            _friendsManageService = DependencyService.Get<IFriendsManageService>();
	MessagingCenter.Subscribe<InvitationReceivedUserControlViewModel>(this, "Hi", (sender) =>
					{
						var a = "";
					});
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {

            await this.CallWithLoadingAsync(async () =>
            {
                var list = await _friendsManageService.GetAllFriendsAsync();
                this.UsersFound.Clear();
                this._tmpUsersFound.Clear();
                foreach (var item in list)
                {
                    this.UsersFound.Add(item);
                    _tmpUsersFound.Add(item);
                }
            });
        }

    }
}
