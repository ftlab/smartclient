using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace CMIOR.UI.WF.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IDXDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void GetError(ErrorInfo info)
        {

        }

        public virtual void GetPropertyError(string propertyName, ErrorInfo info)
        {
            var property = GetType().GetProperty(propertyName);

            // if is a custom property descriptor
            if (property == null)
                return;

            List<ValidationResult> validations = new List<ValidationResult>();
            Validator.TryValidateProperty(property.GetValue(this),
                new ValidationContext(this, null, null)
                {
                    MemberName = propertyName,
                },
                validations
            );

            if (validations.Count > 0)
            {
                info.ErrorType = ErrorType.Critical;
                info.ErrorText = string.Join(";\r\n", validations.Select(x => x.ErrorMessage).ToArray());
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected string GetMemberName<T>(Expression<Func<T>> memberSelector)
        {
            if (memberSelector == null)
                throw new ArgumentNullException(nameof(memberSelector));

            var memberExpression = memberSelector.Body as MemberExpression;
            if (memberExpression == null)
                throw new NullReferenceException("Body is not member expression");

            return memberExpression.Member.Name;
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> memberSelector)
        {
            OnPropertyChanged(GetMemberName(memberSelector));
        }


        protected virtual void Set<T>(Expression<Func<T>> memberSelector, ref T field, T newValue)
        {
            bool changed = Object.Equals(field, newValue);
            field = newValue;

            if (changed)
                OnPropertyChanged(memberSelector);
        }
    }
}