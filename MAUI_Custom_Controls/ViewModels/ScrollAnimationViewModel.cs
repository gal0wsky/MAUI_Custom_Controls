using System;
using MvvmHelpers;

namespace MAUI_Custom_Controls.ViewModels
{
    public partial class ScrollAnimationViewModel : BaseViewModel
    {
        List<Person> people;
        public List<Person> People { get => people; set => SetProperty(ref people, value); }

        public ScrollAnimationViewModel()
        {
            People = new List<Person>()
            {
                new Person()
                {
                    FirstName = "John",
                    LastName = "Doe"
                },
                new Person()
                {
                    FirstName = "Joe",
                    LastName = "Schmoe"
                },
                new Person()
                {
                    FirstName = "John",
                    LastName = "Doe"
                },
                new Person()
                {
                    FirstName = "Joe",
                    LastName = "Schmoe"
                },
                new Person()
                {
                    FirstName = "John",
                    LastName = "Doe"
                },
                new Person()
                {
                    FirstName = "Joe",
                    LastName = "Schmoe"
                },
                new Person()
                {
                    FirstName = "John",
                    LastName = "Doe"
                },
                new Person()
                {
                    FirstName = "Joe",
                    LastName = "Schmoe"
                },
                new Person()
                {
                    FirstName = "John",
                    LastName = "Doe"
                },
                new Person()
                {
                    FirstName = "Joe",
                    LastName = "Schmoe"
                }
            };
        }
    }

    public class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

