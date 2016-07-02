
using EtransfertBackend.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace EtransfertBackend.RolesUserModules.ViewModels
{
    public class EntityObjectToInt : IValueConverter
    {
        public String fullName;
        public object Convert(object value, Type targetType, object parameter,
                              CultureInfo culture)
        {

            if (value is AspNetUsers)
            {
                var rec = (AspNetUsers)value;
               
                return rec.Id;
            }

         

            

            if (value is AspNetUsers)
            {
                var rec = (AspNetUsers)value;
                return rec.Id;
            }

            if (value is AspNetRoles)
            {
                var rec = (AspNetRoles)value;
                return rec.Id;
            }



            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  CultureInfo culture)
        {

            if (value is AspNetRoles)
            {
                var rec = (AspNetRoles)value;
                return rec.Id;
            }



            return 0;
        }
    }


}
