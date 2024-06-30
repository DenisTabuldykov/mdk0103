using DynamicData;
using Practica13_33.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;

namespace Practica13_33.ViewModels;

public class MainViewModel : ViewModelBase
{

    [Reactive]
    public Tovar Selected { get; set; }


    [Reactive]
    public string Price { get; set; }
    [Reactive]
    public string Description { get; set; }



    [Reactive]
    public ObservableCollection<Tovar> Tovars { get; set; }

    [Reactive]
    public string Name { get; set; }

    public MainViewModel()
    {
        Tovars = new ObservableCollection<Tovar>();
        using (DataBase dataBase = new DataBase())
        {
            Tovars.AddRange(dataBase.Tovars.ToList());
        }


        AddTovar = ReactiveCommand.Create(() =>
        {
            if (Name != ""
                && Description != "" 
                && Price != "")
            {
                using DataBase dataBase = new DataBase();
                Tovar product = new Tovar()
                {
                    Name = Name,
                    Description = Description,
                    Price = Price
                };
                Tovars.Add(product);
                dataBase.Tovars.Add(product);
                dataBase.SaveChanges();
            }
        });

        RemoveTovar = ReactiveCommand.Create(() =>
        {
            if (Selected != null)
            {
                using DataBase dataBase = new DataBase();
                dataBase.Tovars.Remove(Selected);
                Tovars.Remove(Selected);
                dataBase.SaveChanges();
            }
        });
    }

    public ReactiveCommand<Unit, Unit> RemoveTovar { get; set; }
    public ReactiveCommand<Unit, Unit> AddTovar { get; set; }
}
