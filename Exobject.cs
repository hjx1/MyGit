using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exobject
{
    public static class Exobject
    {
        public static T CastTo<T>(this object data)
        {
            T val = default(T);
            if (data != null)
            {
                var type = typeof(T);
                var obj = CastTo(data, type);
                if (obj != null)
                    val = (T)obj;
            }
            return val;
        }

        public static object CastTo(this object data, Type type)
        {
            object val = null;
            try
            {
                if (data != null)
                {
                    if (type.IsGenericTypeDefinition && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                        val = Convert.ChangeType(data, Nullable.GetUnderlyingType(type));
                    else
                        val = System.Convert.ChangeType(data, type);
                }
            }
            catch (Exception)
            {
            }
            return val;
        }



    }
}
