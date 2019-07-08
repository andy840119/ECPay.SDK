﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ECPay.Payment.Integration
{
    /// <summary>
    /// 依據課稅類別檢查該欄位是否必填的類別。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class RequiredByTaxTypeAttribute : RequiredAttribute
    {
        /// <summary>
        /// 依據課稅類別檢查該欄位是否必填的類別建構式。
        /// </summary>
        public RequiredByTaxTypeAttribute() : base()
        {
        }

        /// <summary>
        /// 是否檢核通過。
        /// </summary>
        /// <param name="value">要檢核的物件類別。</param>
        /// <returns>驗證成功為 True 否則為 False。</returns>
        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection pdcProperties = null;

            object[] oValues = (object[])value;

            object oPropertyName = oValues[0]; // 屬性的名稱。
            object oPropertyValue = oValues[1]; // 屬性的值。
            object oSourceComponent = oValues[2]; // 該屬性所屬物件。
            object oRelatedComponent = oValues[3]; // 驗證時需要的相關連物件。

            pdcProperties = TypeDescriptor.GetProperties(oSourceComponent);

            object oNeedCheckedValue = pdcProperties.Find("TaxType", true).GetValue(oSourceComponent);

            if (oNeedCheckedValue.Equals(TaxationType.ZeroTaxRate))
                return !oPropertyValue.Equals(CustomsClearance.None);

            return true;
        }
    }
}
