using yListesiMaui_SQLite.Data;
using yListesiMaui_SQLite.Models;

namespace yListesiMaui_SQLite.Views;

[QueryProperty("Item", "Item")]
public partial class TodoItemPage : ContentPage
{
    TodoItem item;
    public TodoItem Item
    {
        get => BindingContext as TodoItem;
        set => BindingContext = value;
    }
    TodoItemDatabase database;
    public TodoItemPage(TodoItemDatabase todoItemPage)
    {
        InitializeComponent();
        database = todoItemPage;
    }
    private async void OnSave_Clicked(object sender, EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(item.Name))
        {
            await DisplayAlert("Name Required", "Please enter a name for the todo item.", "ok");
            return;
        }

        await database.SaveItemAsync(item);
        await Shell.Current.GoToAsync("..");
    }
    async void OnDelete_Clicked(object sender, EventArgs e)
    {
        if (item.ID == 0)
            return;
        await database.DeleteItemAsync(item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}