using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.ViewModels
{
    public class ValidableViewModel : ViewModel, INotifyDataErrorInfo
    {
        //public Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        public Dictionary<string, ICollection<string>> errors = new Dictionary<string, ICollection<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors => (errors.Count > 0);

        //public bool HasErrors
        //{
        //    get => (errors.Count > 0);
        //}

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !errors.ContainsKey(propertyName)) return null;

            return errors[propertyName];
        }

        protected override bool SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            base.SetProperty<T>(ref member, value, propertyName);
            ValidateProperty(propertyName, value);
            return true;
        }

        private void RaiseErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        //private void ValidateProperty<T>(string propertyName, T value)
        //{
        //    if (errors.ContainsKey(propertyName))
        //        errors.Remove(propertyName);

        //    ICollection<ValidationResult> validationResults = new List<ValidationResult>();
        //    ValidationContext validationContext =
        //        new ValidationContext(this, null, null) { MemberName = propertyName };
        //    if (!Validator.TryValidateProperty(value, validationContext, validationResults))
        //    {
        //        errors.Add(propertyName, new List<string>());
        //        foreach (ValidationResult validationResult in validationResults)
        //        {
        //            errors[propertyName].Add(validationResult.ErrorMessage);
        //        }
        //    }
        //    RaiseErrorsChanged(propertyName);

        //}

        protected void ValidateProperty<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();

            ValidationContext context = new ValidationContext(this);
            context.MemberName = propertyName;
            Validator.TryValidateProperty(value, context, results);

            //var validationResults = new List<ValidationResult>();

            //if (!Validator.TryValidateProperty(
            //        GetType().GetProperty(columnName).GetValue(this)
            //        , new ValidationContext(this)
            //        {
            //            MemberName = columnName
            //        }
            //        , validationResults))
            //{
            //    errors[propertyName] = validationResults.First().ErrorMessage;
            //}

            //return validationResults.First().ErrorMessage;

            if (results.Any())
            {
                errors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
            }
            else
            {
                errors.Remove(propertyName);
            }

            RaiseErrorsChanged(propertyName);
        }
    }
}
