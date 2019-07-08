using ECPay.SDK.Logistics.Helpers;
using ECPay.SDK.Logistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECPay.SDK.Logistics.Enumeration;

namespace ECPay.SDK.Logistics.Validator
{
    public class ValidatorChecker
    {
        #region Function

        public static bool ValidateParameter(BaseECPayLogisticsRequest request)
        {
            var parameter = ModelHelper.ToDictionary(request);

            //all the parameter shound be passed
            return parameter.All(validateParameter);
        }


        #endregion

        #region Check Logic

        private static bool validateParameter(KeyValuePair<string, string> parameter)
        {
            switch (parameter.Key.ToLower())
            {
                case "merchantid":
                    validateLegth(parameter.Value, 10, parameter.Key);
                    break;

                case "merchanttradeno":
                    validateLegth(parameter.Value, 20, parameter.Key);
                    break;

                case "merchanttradedate":
                    validateLegth(parameter.Value, 20, parameter.Key);
                    validateDateForm(parameter.Value, parameter.Key);
                    break;

                case "logisticstype":
                    validateLegth(parameter.Value, 20, parameter.Key);
                    validateEnumValue(parameter.Value, typeof(LogisticsType), parameter.Key);
                    break;

                case "logisticssubtype":
                    validateLegth(parameter.Value, 20, parameter.Key);
                    validateEnumValue(parameter.Value, typeof(LogisticsSubType), parameter.Key);
                    break;

                case "goodsamount":
                    validateMoneyValue(parameter.Value, parameter.Key);
                    break;

                case "collectionamount":
                    validateMoneyValue(parameter.Value, parameter.Key);
                    break;

                case "iscollection":
                    validateLegth(parameter.Value, 1, parameter.Key);
                    validateEnumValue(parameter.Value, typeof(CollectionType), parameter.Key);
                    break;

                case "goodsname":
                    validateLegth(parameter.Value, 60, parameter.Key);
                    break;

                case "sendername":
                    validateLegth(parameter.Value.Replace(" ", ""), 10, parameter.Key);
                    break;

                case "sendercellphone":
                    validateLegth(parameter.Value, 20, parameter.Key);
                    break;

                case "receivername":
                    validateLegth(parameter.Value.Replace(" ", ""), 10, parameter.Key);
                    break;

                case "receiverphone":
                    validateLegth(parameter.Value, 20, parameter.Key);
                    break;

                case "receiveremail":
                    validateLegth(parameter.Value, 100, parameter.Key);
                    break;

                case "receivercellphone":
                    validateLegth(parameter.Value, 20, parameter.Key);
                    break;

                case "serverreplyurl":
                    validateLegth(parameter.Value, 200, parameter.Key);
                    break;

                case "clientreplyurl":
                    validateLegth(parameter.Value, 200, parameter.Key);
                    break;

                case "logisticsc2creplyurl":
                    validateLegth(parameter.Value, 200, parameter.Key);
                    break;

                case "remark":
                    validateLegth(parameter.Value, 200, parameter.Key);
                    break;

                case "platformid":
                    validateLegth(parameter.Value, 10, parameter.Key);
                    break;

                case "senderzipcode":
                    validateLegth(parameter.Value, 5, parameter.Key);
                    break;

                case "senderaddress":
                    validateMinMaxLength(parameter.Value, 6, 60, parameter.Key);
                    break;

                case "receiveraddress":
                    validateLegth(parameter.Value, 200, parameter.Key);
                    break;

                case "receiverzipcode":
                    validateLegth(parameter.Value, 5, parameter.Key);
                    break;

                case "temperature":
                    validateLegth(parameter.Value, 4, parameter.Key);
                    break;

                case "distance":
                    validateLegth(parameter.Value, 2, parameter.Key);
                    break;

                case "specification":
                    validateLegth(parameter.Value, 4, parameter.Key);
                    break;

                case "scheduledpickuptime":
                    validateLegth(parameter.Value, 1, parameter.Key);
                    break;

                case "scheduleddeliverytime":
                    validateLegth(parameter.Value, 2, parameter.Key);
                    break;

                case "scheduleddeliverydate":
                    validateLegth(parameter.Value, 10, parameter.Key);
                    validateDateForm(parameter.Value, parameter.Key);
                    break;

                case "packagecount":
                    validateNumberValue(parameter.Value, parameter.Key);
                    break;

                case "receiverstoreid":
                    validateLegth(parameter.Value, 6, parameter.Key);
                    break;

                case "returnstoreid":
                    validateLegth(parameter.Value, 6, parameter.Key);
                    break;

                case "allpaylogisticsid":
                    validateLegth(parameter.Value, 20, parameter.Key);
                    break;

                case "senderphone":
                    validateLegth(parameter.Value, 20, parameter.Key);
                    break;

                case "collectionAmount":
                    validateMoneyValue(parameter.Value, parameter.Key);
                    break;

                case "quantity":
                    validateLegth(parameter.Value, 50, parameter.Key);
                    break;

                case "cost":
                    validateLegth(parameter.Value, 50, parameter.Key);
                    break;

                case "rtnmerchanttradeno":
                    validateLegth(parameter.Value, 13, parameter.Key);
                    break;

                case "cvspaymentno":
                    validateLegth(parameter.Value, 15, parameter.Key);
                    break;

                case "cvsvalidationno":
                    validateLegth(parameter.Value, 10, parameter.Key);
                    break;

                default:
                    break;
            }
            return true;
        }

        #endregion

        #region Check Methods

        private static void validateNull(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception(name + " is null");
            }
        }

        private static void validateLegth(string value, int maxLength, string name)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
            {
                throw new Exception(name + " length can not be more than " + maxLength.ToString() + "!");
            }
        }

        private static void validateMinMaxLength(string value, int minLength, int maxLength, string name)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
            {
                throw new Exception(name + " length can not be more than " + maxLength.ToString() + "!");
            }

            if (!string.IsNullOrEmpty(value) && value.Length < minLength)
            {
                throw new Exception(name + " length can not be less than " + minLength.ToString() + "!");
            }
        }

        private static void validateDateForm(string value, string name)
        {
            validateNull(value, name);
            DateTime result;
            if (!string.IsNullOrEmpty(value) && !DateTime.TryParse(value, out result))
            {
                throw new Exception(name + " is not valid DateTime form(yyyy/MM/dd HH:mm:ss)!");
            }
        }

        private static void validateEnumValue(string value, Type EnumType, string name)
        {
            if (!Enum.GetNames(EnumType).Contains(value))
            {
                //throw new Exception(name + " value error, please check " + name + " Enum!");
            }
        }

        private static void validateMoneyValue(string value, string name)
        {
            decimal result;
            if (!string.IsNullOrEmpty(value) && !decimal.TryParse(value, out result))
            {
                throw new Exception(name + " can only be numbers!");
            }
        }

        private static void validateNumberValue(string value, string name)
        {
            int result;
            if (!string.IsNullOrEmpty(value) && !int.TryParse(value, out result))
            {
                throw new Exception(name + " can only be integers!");
            }
        }

        #endregion
    }
}
