using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

using Volvo.NVS.Core.Diagnostics.Annotations;

namespace Volvo.MaintenanceTool.UserInterface.Common.Extensions
{
    /// <summary>
    /// Provides extensions method to Mvc actions.
    /// </summary>
    public static class ActionExtensions
    {

        /// <summary>
        /// Converts an action with its arguments into a pure action name.
        /// </summary>
        /// <param name="action">An action name with optional arguments to be converted.</param>
        /// <returns>A pure action name with no action argument values.</returns>
        public static string ToActionName([NotNull] this string action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            // When we have a pure action already (with no arguments) then no need to do anything.
            int index = action.IndexOf("/", StringComparison.InvariantCulture);
            if (index == -1)
            {
                return action;
            }
            return action.Substring(0, index);
        }

        /// <summary>
        /// Converts an action with its arguments into an action arguments value string.
        /// </summary>
        /// <param name="action">An action name with optional arguments to be converted.</param>
        /// <returns>An action arguments string (with no action name).</returns>
        public static string ToActionValue(this string action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            // When we have a pure action already (with no arguments) then no need to do anything.
            int index = action.IndexOf("/", StringComparison.InvariantCulture);
            if (index == -1)
            {
                return null;
            }
            return action.Substring(index + 1, action.Length - index - 1);
        }

        public static bool HasNullOrEmptyProperties(this object obj)
        {
            //Step 1: Set the result variable to false;
            bool result = false;

            try
            {
                //Step 2: Check if the incoming object has values or not.
                if (obj != null)
                {
                    //Step 3: Iterate over the properties and check for null values based on the type.
                    foreach (PropertyInfo pi in obj.GetType().GetProperties())
                    {
                        //Step 4: The null check condition only works if the value of the result is false, whenever the result gets true, the value is returned from the method.
                        if (!result)
                        {
                            //Step 5: Different conditions to satisfy different types
                            dynamic value;
                            if (pi.PropertyType == typeof(string))
                            {
                                value = (string)pi.GetValue(obj);
                                result = !(string.IsNullOrEmpty(value) ? true : false || !string.IsNullOrWhiteSpace(value) ? true : false);
                            }
                            else if (pi.PropertyType == typeof(int))
                            {
                                value = (int)pi.GetValue(obj);
                                result = (!(value <= 0) ? true : false || value != null ? true : false);
                            }
                            else if (pi.PropertyType == typeof(bool))
                            {
                                value = pi.GetValue(obj);
                                result = (value != null ? true : false);
                            }
                            else if (pi.PropertyType == typeof(Guid))
                            {
                                value = pi.GetValue(obj);
                                result = (value != Guid.Empty ? true : false || value != null ? true : false);
                            }
                        }
                        //Step 6 - If the result becomes true, the value is returned from the method.
                        else
                            return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Step 7: If the value doesn't become true at the end of foreach loop, the value is returned.
            return result;
        }
    }
}