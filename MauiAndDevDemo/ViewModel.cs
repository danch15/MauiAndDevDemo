using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Rotorsoft.Forms;

namespace MauiAndDevDemo;

public class ViewModel : INotifyPropertyChanged
{
    public CollectionViewSource UserCollectionViewSource { get; set; } = new CollectionViewSource();

    bool isOpenPopup;
    /// <summary>
    /// 呼叫列车弹窗
    /// </summary>
    public bool IsOpenPopup
    {
        get => this.isOpenPopup;
        set
        {
            if (isOpenPopup == value)
                return;
            this.isOpenPopup = value;
            OnPropertyChanged();
        }
    }
    public ICommand ShowPopupCommand { get; set; }

    public ICommand AddItemCommand { get; set; }
    public ICommand DeleteItemCommand { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    private bool keyboardEntryReadOnly = true;
    public bool KeyboardEntryReadOnly
    {
        get => keyboardEntryReadOnly;
        set
        {
            keyboardEntryReadOnly = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<User> Users { get; set; } = new();

    private User currentUser;
    public User CurrentUser
    {
        get => currentUser;
        set
        {
            if (currentUser == value)
                return;
            currentUser = value;
            OnPropertyChanged();
        }
    }

    public ViewModel()
    {
        ShowPopupCommand = new Command(OnShowPopup);
        AddItemCommand = new Command<object>(OnAddItem);
        DeleteItemCommand = new Command<object>(OnDeleteItem, CanDeleteItem);

        for (; i < 10; i++)
        {
            User user = new User()
            {
                UserID = i.ToString(),
                UserName = i.ToString(),
                UserNumber = i.ToString()
            };
            Users.Add(user);
        }

        UserCollectionViewSource.Source = Users;
        UserCollectionViewSource.SortDescriptions = new ObservableCollection<SortDescription>()
        {
            new SortDescription(nameof(User.UserName), ListSortDirection.Descending)
        };
    }

    int i = 0;

    private void OnShowPopup()
    {
        IsOpenPopup = !IsOpenPopup;
    }

    private void OnAddItem(object obj)
    {
        User user = new User()
        {
            UserID = i.ToString(),
            UserName = i.ToString(),
            UserNumber = i.ToString()
        };
        Users.Add(user);
        i++;
    }

    private void OnDeleteItem(object obj)
    {
        if (obj is User user)
        {
            Users.Remove(user);
            CurrentUser = null;
        }
    }

    private bool CanDeleteItem(object arg)
    {
        return arg is User user;
    }
}
