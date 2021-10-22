using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TestApp.Model;
using TestApp.UI.ViewModel;

namespace TestApp.UI.Wrapper
{
    public partial class EmployeWrapper : ModelWrapper<Employe>
    {
        public EmployeWrapper(Employe model) : base(model) { }

        public long Id { get => Model.Id; }
        public string FirstName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string LastName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string Email
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string Number
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, "Robot", StringComparison.OrdinalIgnoreCase))
                        yield return "No-no-no";
                    break;
            }
        }
    }
}
