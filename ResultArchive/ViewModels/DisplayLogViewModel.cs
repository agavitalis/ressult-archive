using Microsoft.AspNetCore.Routing;
using ResultArchive.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultArchive.ViewModels
{
    public class DisplayLogViewModel
    {
        public IEnumerable<ExamLog> ExamLogs { get; set; }
        public IEnumerable<string> Sessions { get; set; }
        public IEnumerable<string> Schools { get; set; }
        public IEnumerable<string> Semesters { get; set; }

        //dynamic document type
        public IEnumerable<ExpandoObject> ExamLogSearch { get; set; }


    }

    public static class DisplayDynamicLogViewModel
    {
        public static ExpandoObject ToExpando(this object anonymousObject)
        {
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(anonymousObject))
            {
                var obj = propertyDescriptor.GetValue(anonymousObject);
                expando.Add(propertyDescriptor.Name, obj);
            }

            return (ExpandoObject)expando;
        }

    }

}
