using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TestApp.Model;
using TestApp.UI.ViewModel;

namespace TestApp.UI.Wrapper
{
    public partial class EmployeWrapper : ViewModelBase, INotifyDataErrorInfo
    {
        public Employe Model;

        public long Id { get => Model.Id; }
        public string FirstName
        {
            get => Model.FirstName;
            set
            {
                Model.FirstName = value;
                OnPropertryChanged();
                ValidateProperty(nameof(FirstName));
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);
            switch(propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, "Robot", StringComparison.OrdinalIgnoreCase))
                        AddError(propertyName, "No-no-no");
                    break;
            }
        }

        public string LastName
        {
            get => Model.LastName;
            set
            {
                Model.LastName = value;
                OnPropertryChanged();
            }
        }
        public string Email
        {
            get => Model.Email;
            set
            {
                Model.Email = value;
                OnPropertryChanged();
            }
        }
        public string Number
        {
            get => Model.Number;
            set
            {
                Model.Number = value;
                OnPropertryChanged();
            }
        }

        public EmployeWrapper(Employe employe)
        {
            Model = employe;
        }
    }
}
