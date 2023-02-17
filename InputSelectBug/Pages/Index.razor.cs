using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics;

namespace InputSelectBug.Pages;

public partial class Index
{
    private EditContext MyContext;

    private MyCalendar currentCalendar { get; set; }
    private List<MyCalendar> myCalendars { get; set; }
    private bool showAllCalendars { get; set; }

    protected override void OnInitialized()
    {
        myCalendars = new List<MyCalendar>();
        showAllCalendars = false;
        LoadCalendars();

        currentCalendar = myCalendars[5]; // This is Calendar 11

        MyContext = new EditContext(myCalendars);
        MyContext.OnFieldChanged += MyContext_OnFieldChanged;
    }

    private void MyContext_OnFieldChanged(object sender, FieldChangedEventArgs args)
    {
        Debug.WriteLine(args.FieldIdentifier.FieldName);
        switch (args.FieldIdentifier.FieldName)
        {
            case "showAllCalendars":
                LoadCalendars();
                break;
        }
    }

    private void LoadCalendars()
    {
        myCalendars.Clear();

        if (showAllCalendars == false)
        {
            myCalendars.Add(new MyCalendar(1));
            myCalendars.Add(new MyCalendar(3));
            myCalendars.Add(new MyCalendar(4));
            myCalendars.Add(new MyCalendar(5));
            myCalendars.Add(new MyCalendar(9));
            myCalendars.Add(new MyCalendar(11));
            myCalendars.Add(new MyCalendar(13));
            myCalendars.Add(new MyCalendar(14));
        }
        else
        {
            myCalendars.Add(new MyCalendar(1));
            myCalendars.Add(new MyCalendar(2));
            myCalendars.Add(new MyCalendar(3));
            myCalendars.Add(new MyCalendar(4));
            myCalendars.Add(new MyCalendar(5));
            myCalendars.Add(new MyCalendar(6));
            myCalendars.Add(new MyCalendar(7));
            myCalendars.Add(new MyCalendar(8));
            myCalendars.Add(new MyCalendar(9));
            myCalendars.Add(new MyCalendar(10));
            myCalendars.Add(new MyCalendar(11));
            myCalendars.Add(new MyCalendar(12));
            myCalendars.Add(new MyCalendar(13));
            myCalendars.Add(new MyCalendar(14));
        }

    }

}

public class MyCalendar
{
    public MyCalendar(int calendar_index)
    {
        Calendar_Name = $"CALENDAR {calendar_index.ToString().PadLeft(2, '0')}";
        Calendar_Group = $"GROUP {calendar_index.ToString().PadLeft(2, '0')}";
    }

    public string Calendar_Name { get; set; } = "";
    public string Calendar_Group { get; set; } = "";
}